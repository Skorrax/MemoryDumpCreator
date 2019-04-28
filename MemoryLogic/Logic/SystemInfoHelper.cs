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
        private static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION32 lpBuffer, uint dwLength);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION64 lpBuffer, uint dwLength);
        public static SYSTEM_INFO GetSysInfo()
        {
            SYSTEM_INFO Info = new SYSTEM_INFO();
            GetNativeSystemInfo(out Info);
            return Info;
        }
        public static MEMORY_BASIC_INFORMATION64 GetMemInfo32(IntPtr ProcessHandle, IntPtr MinAddress)
        {
            var MemInfo = new MEMORY_BASIC_INFORMATION32();
            int QueryResult = VirtualQueryEx(ProcessHandle, MinAddress, out MemInfo,(uint) Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION32)));
            if (QueryResult == 0)
                Debug.WriteLine("Error on VirtualQueryEx, returned 0!");
            return MapMemInfo(MemInfo);
        }

        public static MEMORY_BASIC_INFORMATION64 GetMemInfo64(IntPtr ProcessHandle, IntPtr MinAddress)
        {
            var MemInfo = new MEMORY_BASIC_INFORMATION64();
            int QueryResult = VirtualQueryEx(ProcessHandle, MinAddress, out MemInfo, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION64)));
            if (QueryResult == 0)
                Debug.WriteLine("Error on VirtualQueryEx, returned 0!");
            return MemInfo;
        }
        private static MEMORY_BASIC_INFORMATION64 MapMemInfo(MEMORY_BASIC_INFORMATION32 memInfo)
        {
            MEMORY_BASIC_INFORMATION64 result = new MEMORY_BASIC_INFORMATION64();
            result.AllocationBase = (ulong)memInfo.AllocationBase;
            result.AllocationProtect = (uint)memInfo.AllocationProtect;
            result.BaseAddress = (ulong)memInfo.BaseAddress;
            result.Protect = (uint)memInfo.Protect;
            result.RegionSize = (ulong)memInfo.RegionSize;
            result.State = (uint)memInfo.State;
            result.Type = (uint)memInfo.Type;
            return result;
        }
    }
}
