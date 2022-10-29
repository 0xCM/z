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

    public sealed record class EcmaStreams(MetadataStreamKind StreamKind, ReadOnlySeq<EcmaStreamHeader> Headers, MemoryBlock MetadataRoot, MemoryBlock Tables, MemoryBlock Pdb);

    [ApiHost]
    public unsafe partial class EcmaReader
    {
        public static EcmaReader create(EcmaFile src)
            => new EcmaReader(src);
        [Op]
        public static EcmaReader create(Assembly src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(MetadataReader src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(MemorySeg src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(PEMemoryBlock src)
            => new EcmaReader(src);

        readonly MetadataReader MD;

        public ref readonly MetadataReader MetadataReader
        {
            [MethodImpl(Inline)]
            get => ref MD;
        }

        readonly MemorySeg Segment;

        [MethodImpl(Inline)]
        public EcmaReader(Assembly src)
        {
            Segment = ClrAssembly.metadata(src);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public EcmaReader(MemorySeg src)
        {
            Segment = src;
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public EcmaReader(PEMemoryBlock src)
        {
            Segment = MemorySegs.define(src.Pointer, src.Length);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);        
        }

        [MethodImpl(Inline)]
        public EcmaReader(MetadataReader src)
        {
            Segment = MemorySegs.define(src.MetadataPointer, src.MetadataLength);
            MD = src;
        }

        [MethodImpl(Inline)]
        public EcmaReader(EcmaFile src)
        {
            Segment = MemorySegs.define(src.MetadataReader.MetadataPointer, src.MetadataReader.MetadataLength);
            MD = src.MetadataReader;
        }

        public ByteSize MetaSize
        {
            [MethodImpl(Inline)]
            get => Segment.Size;
        }

        public ReadOnlySpan<byte> MetaBytes
        {
            [MethodImpl(Inline)]
            get => MemorySegs.view<byte>(Segment);
        }

        public static EcmaStreams streams(in MemoryBlock root, ReadOnlySeq<EcmaStreamHeader> headers)
        {
            return default;

        }
    }
}