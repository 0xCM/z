//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class EcmaStream
    {        
        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize Size;

        public readonly EcmaStreamKind Kind;

        public EcmaStream(MemoryAddress @base, ByteSize size, EcmaStreamKind kind)
        {
            BaseAddress = @base;
            Size = size;
            Kind = kind;
        }
        
    }

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

    public record class EcmaStringStream : EcmaStream
    {
        public EcmaStringStream(MemoryAddress @base, ByteSize size, bool user)
            : base(@base,size,user ? EcmaStreamKind.UserString : EcmaStreamKind.String)
        {

        }
    }

    public record class EcmaBlobStream : EcmaStream
    {
        public EcmaBlobStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.Blob)
        {

        }
    }

    public record class EcmaGuidStream : EcmaStream
    {
        public EcmaGuidStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.Blob)
        {

        }
    }        

}