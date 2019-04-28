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
        private static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll")]
        private static extern void GetNativeSystemInfo(out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        public static SYSTEM_INFO GetSysInfo()
        {
            SYSTEM_INFO Info = new SYSTEM_INFO();
            GetSystemInfo(out Info);
            return Info;
        }
        public static MEMORY_BASIC_INFORMATION GetMemInfo(IntPtr ProcessHandle, IntPtr MinAddress)
        {
            var MemInfo = new MEMORY_BASIC_INFORMATION();
            VirtualQueryEx(ProcessHandle, MinAddress, out MemInfo,(uint) Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
            return MemInfo;
        }
    }
}
