using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryLogic.Logic;
using MemoryLogic.Model;
using System.Diagnostics;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Summary description for ProcessHelperTests
    /// </summary>
    [TestClass]
    public class SystemInfoHelperTests
    {
        [TestMethod]
        public void TestGetSysInfo()
        {
            SYSTEM_INFO Info = SystemInfoHelper.GetSysInfo();          
            Assert.IsTrue(Info.ProcessorArchitecture == ProcessorArchitecture.X64);
            Assert.IsTrue((uint)Info.MaximumApplicationAddress > (uint)Info.MinimumApplicationAddress);

        }
        [TestMethod]
        public void TestGetMemInfo()
        {
            MEMORY_BASIC_INFORMATION64 Info = SystemInfoHelper.GetMemInfo32(Process.GetProcessesByName("ditto").FirstOrDefault().Handle, SystemInfoHelper.GetSysInfo().MinimumApplicationAddress);
        }
    }
}
