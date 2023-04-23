//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableName)]
    public record struct MetadataRoot : IComparable<MetadataRoot>
    {
        const string TableName = "ecma.roots";

        [Render(64)]
        public AssemblyKey Assembly;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(16)]
        public Hex32 Signature;

        [Render(16)]
        public ushort MajorVersion;

        [Render(16)]
        public ushort MinorVersion;

        [Render(12)]
        public uint Reserved;
        
        [Render(16)]
        public uint IdentitySize;

        [Render(16)]
        public @string MetadataVersion;

        [Render(16)]
        public ushort StreamCount;

        [Render(24)]
        public EcmaStreamHeader TableStreamHeader;

        [Render(24)]
        public EcmaStreamHeader StringStreamHeader;

        [Render(24)]
        public EcmaStreamHeader UserStringStreamHeader;

        [Render(24)]
        public EcmaStreamHeader BlobStreamHeader;

        [Render(24)]
        public EcmaStreamHeader GuidStreamHeader;

        [Render(1)]
        public Hex32 TableOffset;

        public int CompareTo(MetadataRoot other)
            => Assembly.CompareTo(other.Assembly);

    }   
}