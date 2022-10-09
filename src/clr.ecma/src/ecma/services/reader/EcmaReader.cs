//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public unsafe partial class EcmaReader
    {
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
    }
}