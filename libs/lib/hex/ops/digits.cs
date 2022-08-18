//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    using C = AsciCode;
    using S = AsciSymbol;
    using D = HexDigitValue;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static Outcome<uint> digits(ReadOnlySpan<char> src, Span<D> dst)
        {
            var j=0u;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<src.Length; i++)
            {
                if(!parse(skip(src,i), out seek(dst,i)))
                    return false;
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static Outcome<uint> digits(ReadOnlySpan<C> src, Span<D> dst)
        {
            var j=0u;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<src.Length; i++)
            {
                if(!parse(skip(src,i), out seek(dst,i)))
                    return false;
            }
            return j;
        }        

        [MethodImpl(Inline), Op]
        public static Outcome<uint> digits(ReadOnlySpan<S> src, Span<D> dst)
            => digits(recover<AsciSymbol,AsciCode>(src), dst);
    }
}