//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static uint render(in AsciLineCover src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            if(src.IsNonEmpty)
                render(src.Codes, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(AsciSeq src, uint length, Span<char> dst)
        {
            var size = min(src.Capacity,length);
            var data = slice(src.Data.View,0,size);
            for(var i=0u; i<size; i++)
                seek(dst, i) = src[i];
            return size;
        }

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<C> src, ref uint i, Span<char> dst)
        {
            var count = (uint)src.Length;
            for(var j=0; j<count; j++)
                seek(dst,i++) = (char)skip(src,j);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint render(ReadOnlySpan<S> src, ref uint i, Span<char> dst)
            => render(recover<S,C>(src), ref i, dst);
    }
}