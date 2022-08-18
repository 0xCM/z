//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_function_table_descriptor
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_FUNCTION_TABLE_DESCRIPTOR : IRecord<MINIDUMP_FUNCTION_TABLE_DESCRIPTOR>
        {
            public ulong MinimumAddress;

            public ulong MaximumAddress;

            public ulong BaseAddress;

            public uint EntryCount;

            public uint SizeOfAlignPad;
        }
    }
}