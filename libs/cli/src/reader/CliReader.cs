//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public unsafe partial class CliReader
    {
        [Op]
        public static CliReader create(Assembly src)
            => new CliReader(src);

        [Op]
        public static CliReader create(MetadataReader src)
            => new CliReader(src);

        [Op]
        public static CliReader create(MemorySeg src)
            => new CliReader(src);

        [Op]
        public static CliReader create(PEMemoryBlock src)
            => new CliReader(src);

        readonly MetadataReader MD;

        public ref readonly MetadataReader MetadataReader
        {
            [MethodImpl(Inline)]
            get => ref MD;
        }

        readonly MemorySeg Segment;

        [MethodImpl(Inline)]
        public CliReader(Assembly src)
        {
            Segment = Clr.metadata(src);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public CliReader(MemorySeg src)
        {
            Segment = src;
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public CliReader(PEMemoryBlock src)
        {
            Segment = MemorySegs.define(src.Pointer, src.Length);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public CliReader(MetadataReader src)
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