//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static Pair<int> indices(ReadOnlySpan<char> src, S first, S second)
            => Tuples.pair(index(src, first), index(src,second));

        [MethodImpl(Inline), Op]
        public static Pair<int> indices(ReadOnlySpan<C> src, Fence<C> fence)
            => Tuples.pair(index(src, fence.Left), index(src,fence.Right));

        [MethodImpl(Inline), Op]
        public static Pair<int> indices(ReadOnlySpan<C> src, Fence<char> fence)
            => Tuples.pair(index(src, fence.Left), index(src,fence.Right));

        [MethodImpl(Inline), Op]
        public static Pair<int> indices(ReadOnlySpan<C> src, S first, S second)
            => Tuples.pair(index(src, first), index(src,second));

        [MethodImpl(Inline), Op]
        public static uint indices(ReadOnlySpan<char> src, S match, Span<uint> dst)
        {
            var max = (uint)dst.Length;
            var j = 0u;
            for(var i=0u; i<src.Length && j < max; i++)
            {
                if(skip(src,i) == match)
                    seek(dst, j++) = i;
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static uint indices(ReadOnlySpan<C> src, S match, Span<uint> dst)
        {
            var max = (uint)dst.Length;
            var j = 0u;
            for(var i=0u; i<src.Length && j < max; i++)
            {
                if(skip(src,i) == match)
                    seek(dst, j++) = i;
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static uint indices(ReadOnlySpan<S> src, S match, Span<uint> dst)
        {
            var max = (uint)dst.Length;
            var j = 0u;
            for(var i=0u; i<src.Length && j < max; i++)
            {
                if(skip(src,i) == match)
                    seek(dst, j++) = i;
            }
            return j;
        }
    }
}