//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class EcmaTableStream : EcmaStream
    {
        public EcmaTableStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.CompressedTable)
        {

        }

        public uint Reserved1;

        public byte MajorVersion;

        public byte MinorVersion;

        public byte HeapSizes;

        public byte Reserved2;

        public EcmaTableMask Present;

        public ulong Sorted;

        public byte TableCount;

        public ReadOnlySeq<uint> RowCounts;
    }
}