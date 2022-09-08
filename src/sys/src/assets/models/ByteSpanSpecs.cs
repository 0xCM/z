//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ByteSpanSpecs
    {
        [MethodImpl(Inline), Op]
        public static ByteSize size(ReadOnlySpan<ByteSpanSpec> src)
        {
            var size = ByteSize.Zero;
            var count = src.Length;
            for(var i=0; i<count; i++)
                size += sys.skip(src,i).DataSize;
            return size;
        }

        readonly Index<ByteSpanSpec> Data;

        [MethodImpl(Inline)]
        public ByteSpanSpecs(ByteSpanSpec[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<ByteSpanSpec> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ByteSpanSpec> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref ByteSpanSpec First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ByteSize TotalSize
        {
            [MethodImpl(Inline)]
            get => size(Data);
        }

        [MethodImpl(Inline)]
        public static implicit operator ByteSpanSpecs(ByteSpanSpec[] src)
            => new ByteSpanSpecs(src);
    }
}