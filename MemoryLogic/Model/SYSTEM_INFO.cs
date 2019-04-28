using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryLogic.Model
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        public ProcessorArchitecture processorArchitecture;
        ushort reserved;
        public uint pageSize;
        //public IntPtr minimumApplicationAddress;  // minimum address
        public UIntPtr minimumApplicationAddress;
        //public IntPtr maximumApplicationAddress;  // maximum address
        public UIntPtr maximumApplicationAddress;  // maximum address
        public IntPtr activeProcessorMask;
        public uint numberOfProcessors;
        public uint processorType;
        public uint allocationGranularity;
        public ushort processorLevel;
        public ushort processorRevision;
    }
    public enum ProcessorArchitecture
    {
        X86 = 0,
        X64 = 9,
        @Arm = -1,
        Itanium = 6,
        Unknown = 0xFFFF,
    }
}
