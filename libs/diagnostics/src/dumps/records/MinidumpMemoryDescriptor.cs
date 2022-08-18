//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct MinidumpMemoryDescriptor : IRecord<MinidumpMemoryDescriptor>
        {
            [FieldOffset(0)]
            public MemoryAddress StartAddress;

            // MINIDUMP_MEMORY_DESCRIPTOR64
            [FieldOffset(8)]
            public MemoryAddress DataSize64;

            // MINIDUMP_MEMORY_DESCRIPTOR
            [FieldOffset(8)]
            public uint DataSize32;

            [FieldOffset(12)]
            public uint Rva;
        }
    }
}