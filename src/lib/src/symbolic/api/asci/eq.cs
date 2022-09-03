//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using static AsciSymbols;
    using static AsciChars;

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static bool eq(ReadOnlySpan<char> x, ReadOnlySpan<C> y)
        {
            var count = x.Length;
            if(count != y.Length)
                return false;

            for(var i=0u; i<count; i++)
                if((byte)skip(x,i) != (byte)skip(y,i))
                    return false;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool eq(ReadOnlySpan<C> x, ReadOnlySpan<char> y)
            => eq(y,x);
    }
}