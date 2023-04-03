//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe record struct PROCESS_BASIC_INFORMATION
    {
        public NTSTATUS ExitStatus;

        public MemoryAddress PebBaseAddress;

        public BitVector64 AffinityMask;

        public uint BasePriority;

        public ulong UniqueProcessId;

        public ulong InheritedFromUniqueProcessId;
    }
}