//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Scalars;
    using S = AsciSymbol;

    partial struct AsciBlocks
    {
        public static AsciBlock<N> block<N>(Span<S> src, N n = default)
            where N : unmanaged, ITypeNat
                => new AsciBlock<N>(slice(src,0, Scalars.min(src.Length, (int)n.NatValue)));

        public static AsciBlock<N> block<N>(string src, N n = default)
            where N : unmanaged, ITypeNat
        {
            var buffer = sys.alloc<S>(Typed.value<N>());
            buffer.Clear();
            var chars = span(src);
            ref var dst = ref first(buffer);
            var count = min(buffer.Length, chars.Length);
            for(var i=0; i<count; i++)
                sys.seek(dst,i) = skip(chars,i);
            return new AsciBlock<N>(buffer);
        }
    }
}