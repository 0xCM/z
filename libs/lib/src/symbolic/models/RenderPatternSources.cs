//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct RenderPatternSources
    {
        [Op]
        public static RenderPatternSources from(Type src)
        {
            var values = src.LiteralFieldValues<string>(out var fields);
            var count = values.Length;
            var buffer = sys.alloc<RenderPatternSource>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new RenderPatternSource(skip(fields,i), skip(values,i));
            return buffer;
        }

        readonly Index<RenderPatternSource> Data;

        [MethodImpl(Inline)]
        public RenderPatternSources(RenderPatternSource[] src)
            => Data = src;

        public Count Count
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ReadOnlySpan<RenderPatternSource> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly RenderPatternSource this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator RenderPatternSources(RenderPatternSource[] src)
            => new RenderPatternSources(src);
    }
}