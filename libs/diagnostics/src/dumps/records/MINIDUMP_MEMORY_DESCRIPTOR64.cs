//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        // DESCRIPTOR64 is used for full-memory minidumps where
        // all of the raw memory is laid out sequentially at the
        // end of the dump.  There is no need for individual RVAs
        // as the RVA is the base RVA plus the sum of the preceeding
        // data blocks.
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_MEMORY_DESCRIPTOR64 : IRecord<MINIDUMP_MEMORY_DESCRIPTOR64>
        {
            public ulong StartOfMemoryRange;

            public ulong DataSize;
        }
    }
}