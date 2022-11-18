//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct EcmaStreamHeader
    {
        public Address32 Offset;
        
        public uint Size;
        
        public string Name;
    }

    public enum MetadataStreamKind : byte
    {
        Illegal,

        Compressed,

        Uncompressed,
    }

    public sealed record class EcmaStreams(
        MetadataStreamKind StreamKind, 
        ReadOnlySeq<EcmaStreamHeader> Headers, 
        MemoryBlock MetadataRoot, 
        MemoryBlock Tables, 
        MemoryBlock Pdb
        );
}