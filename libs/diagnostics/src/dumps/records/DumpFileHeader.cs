//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MinidumpRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public unsafe struct DumpFileHeader : IRecord<DumpFileHeader>
        {
            public const string TableId = "image.minidump-header";

            public CharBlock4 Signature;

            public ushort Version;

            ushort _Filler1;

            /// <summary>
            /// The number of streams in the minidump directory.
            /// </summary>
            public Count StreamCount;

            /// <summary>
            /// The base RVA of the minidump directory
            /// </summary>
            public Address32 Streams;

            public ulong Timestamp;

            public MinidumpType Properties;
        }
    }
}