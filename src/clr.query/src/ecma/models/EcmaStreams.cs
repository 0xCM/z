//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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