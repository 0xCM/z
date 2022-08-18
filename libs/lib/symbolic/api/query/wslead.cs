//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static uint wslead(ReadOnlySpan<byte> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(whitespace((C)skip(src,i)))
                    counter++;
                else
                    break;
            }
            return counter;
        }
    }
}