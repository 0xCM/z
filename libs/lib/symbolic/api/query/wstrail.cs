//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static uint wstrail(ReadOnlySpan<byte> src)
            => wstrail(recover<C>(src));

        [MethodImpl(Inline), Op]
        public static uint wstrail(ReadOnlySpan<C> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=count - 1; i>= 0; i--)
            {
                if(whitespace(skip(src,i)))
                    counter++;
                else
                    break;
            }
            return counter;
        }
    }
}