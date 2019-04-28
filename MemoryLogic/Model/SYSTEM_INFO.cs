using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryLogic.Model
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        public ProcessorArchitecture ProcessorArchitecture; 
        public uint PageSize; 
        public IntPtr MinimumApplicationAddress; 
        public IntPtr MaximumApplicationAddress; 
        public IntPtr ActiveProcessorMask; 
        public uint NumberOfProcessors; 
        public uint ProcessorType; 
        public uint AllocationGranularity; 
        public ushort ProcessorLevel; 
        public ushort ProcessorRevision;
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
