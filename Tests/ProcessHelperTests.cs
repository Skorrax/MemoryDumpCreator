using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryLogic.Logic;
using System.Diagnostics;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Summary description for ProcessHelperTests
    /// </summary>
    [TestClass]
    public class ProcessHelperTests
    {
    
        [TestMethod]
        public void TestIsProcessWow64()
        {
            bool IsDebugProcessWow64 = ProcessHelper.IsProcessWow64(Process.GetCurrentProcess().Handle);
            Assert.IsTrue(IsDebugProcessWow64);
        }
        /// <summary>
        /// Requires to have ditto installed and running (best tool on earth!)
        /// </summary>
        [TestMethod]
        public void TestIsDittoProcessWow64()
        {
            bool IsDebugProcessWow64 = ProcessHelper.IsProcessWow64(Process.GetProcessesByName("ditto").FirstOrDefault().Handle);
            Assert.IsFalse(IsDebugProcessWow64);
        }
    }
}
