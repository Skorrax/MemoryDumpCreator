using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryLogic.Logic
{
    public class ProcessHelper
    {
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess (int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory (int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public static IntPtr GetProcessHandle(string ProcessName)
        {
            Process process = Process.GetProcessesByName(ProcessName).FirstOrDefault();
            if (process == null)
                throw new Exception($"WARNING! Process {ProcessName} not found!");
            IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);
            return processHandle;
        }
        public static IntPtr GetProcessHandle(int ProcessId)
        {
            Process process = Process.GetProcessById(ProcessId);
            if (process == null)
                throw new Exception($"WARNING! Process {ProcessId} not found!");
            IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);
            return processHandle;
        }
    }
}
