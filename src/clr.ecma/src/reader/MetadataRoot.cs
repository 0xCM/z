//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct MetadataRoot
    {
        public Hex32 Signature;

        public ushort MajorVersion;

        public ushort MinorVersion;

        public uint Reserved;
        
        public uint IdentitySize;

        public @string MetadataVersion;

        public ushort StreamCount;

        public ReadOnlySeq<EcmaStreamHeader> StreamHeaders;
    }
}