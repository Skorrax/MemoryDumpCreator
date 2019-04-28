using MemoryLogic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryLogic.Logic
{
    public class SystemInfoHelper
    {
        [DllImport("kernel32.dll")]
        private static extern void GetNativeSystemInfo(out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION64 lpBuffer, uint dwLength);

        public static SYSTEM_INFO GetSysInfo()
        {
            SYSTEM_INFO Info = new SYSTEM_INFO();
            GetNativeSystemInfo(out Info);
            return Info;
        }
        public static MEMORY_BASIC_INFORMATION64 GetMemInfo(IntPtr ProcessHandle, IntPtr MinAddress)
        {
            var MemInfo = new MEMORY_BASIC_INFORMATION64();
            VirtualQueryEx(ProcessHandle, MinAddress, out MemInfo, 48);
            return MemInfo;
        }
    }
}
