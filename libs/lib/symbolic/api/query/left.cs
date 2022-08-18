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
        public static ReadOnlySpan<char> left(ReadOnlySpan<char> src, int index)
        {
            if(index < src.Length)
                return slice(src, 0, index);
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<C> left(ReadOnlySpan<C> src, int index)
        {
            if(index < src.Length)
                return slice(src, 0, index);
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> left(ReadOnlySpan<char> src, string match)
        {
            var i = SQ.index(src,match);
            if(i > 0)
                return left(src,i);
            else
                return default;
        }

    }
}