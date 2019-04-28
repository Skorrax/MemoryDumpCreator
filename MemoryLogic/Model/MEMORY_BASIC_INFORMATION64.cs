using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryLogic.Model
{
    //public struct MEMORY_BASIC_INFORMATION64
    //{

    //    //public long BaseAddress;
    //    //public long AllocationBase;
    //    //public long AllocationProtect;
    //    //public long RegionSize;   // size of the region allocated by the program
    //    //public long State;   // check if allocated (MEM_COMMIT)
    //    //public long Protect; // page protection (must be PAGE_READWRITE)
    //    //public long lType;
    //    //public ulong BaseAddress;
    //    //public ulong AllocationBase;
    //    //public uint AllocationProtect;
    //    //public uint __alignment1;
    //    //public ulong RegionSize;
    //    //public uint State;
    //    //public uint Protect;
    //    //public uint Type;
    //    //public uint __alignment2;
    //}
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public IntPtr RegionSize;
        public uint State;
        public uint Protect;
        public uint Type;
    }
}
