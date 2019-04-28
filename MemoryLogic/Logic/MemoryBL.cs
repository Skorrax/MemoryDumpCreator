using MemoryLogic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MemoryLogic.Logic
{
    public class MemoryBL
    {
        private const int MEM_COMMIT = 0x00001000;
        private const int PAGE_READ = 0x02;
        private const int PAGE_READWRITE = 0x04;

        public void GetMemoryDump(string ProcessName)
        {
            IntPtr processHandle = ProcessHelper.GetProcessHandle(ProcessName);
            GetMemoryDump(processHandle);

        }
        public void GetMemoryDump(int ProcessId)
        {
            IntPtr processHandle = ProcessHelper.GetProcessHandle(ProcessId);
            GetMemoryDump(processHandle);
        }

        private void GetMemoryDump(IntPtr processHandle)
        {
            SYSTEM_INFO sysInfo = SystemInfoHelper.GetSysInfo();

            IntPtr proc_min_address = sysInfo.MinimumApplicationAddress;
            IntPtr proc_max_address = sysInfo.MaximumApplicationAddress;

            // saving the values as long ints so I won't have to do a lot of casts later
            long proc_min_address_l = (long)proc_min_address;
            long proc_max_address_l = (long)(uint)proc_max_address;
            StreamWriter sw = new StreamWriter("dump.txt");
            int bytesRead = 0;
            long lastminAddress = 0;
            while (proc_min_address_l < proc_max_address_l)
            {
                MEMORY_BASIC_INFORMATION memInfo = SystemInfoHelper.GetMemInfo(processHandle, proc_min_address);
                //if ((memInfo.Protect == PAGE_READ || memInfo.Protect ==  PAGE_READWRITE) && memInfo.State == MEM_COMMIT)
                if (memInfo.Protect == PAGE_READWRITE && memInfo.State == MEM_COMMIT)
                {
                    int maxRowSize = 64;
                    byte[] buffer = new byte[(int)memInfo.RegionSize];
                    ProcessHelper.ReadProcessMemory((int)processHandle, (int)memInfo.BaseAddress, buffer, (int)memInfo.RegionSize, ref bytesRead);
                    string resultRow = string.Empty;
                    bool hasValues = false;
                    for (int i = 0; i < (int)memInfo.RegionSize; i++)
                    {
                        if (i % 64 == 0)
                        {
                            if (hasValues)
                            {
                                sw.WriteLine(resultRow);
                            }
                            hasValues = false;
                            resultRow = $"0x{((int)memInfo.BaseAddress + i).ToString("X")} : ";

                        }

                        if (buffer[i] != 0)
                        {
                            resultRow += ((char)buffer[i] + " ");
                            hasValues = true;
                        }
                    }

                }
                if ((int)memInfo.RegionSize == 0)
                {
                    break;
                }

                lastminAddress = proc_min_address_l;
                proc_min_address_l += (long)memInfo.RegionSize;
                if (proc_min_address_l < lastminAddress)
                {
                    break;
                }

                try
                {
                    proc_min_address = new IntPtr((long)proc_min_address_l);
                }
                catch
                {
                    break;
                }

                Debug.Print($"Progress {(double)proc_min_address_l / ((double)proc_max_address_l / 100.0)}%");
            }

            sw.Close();
        }
    }
}
