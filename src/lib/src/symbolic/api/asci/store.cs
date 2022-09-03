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
        public static void store(ReadOnlySpan<byte> src, char fill, Span<char> dst)
        {
            var count = Algs.length(src,dst);
            for(var i=0u; i<count; i++)
            {
                ref readonly var next = ref skip(src,i);
                seek(dst,i) = next == 0 ? fill : @char(skip(src,i));
            }
        }
    }
}