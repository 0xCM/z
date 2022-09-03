//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using D = HexDigit;
    using B = Base16;
    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<char> src, out GBlock64<D> dst, B @base = default)
        {
            var count = src.Length;
            var j = 0u;
            dst = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(test(@base, c))
                    dst[j++] = digit(@base,c);
                else
                    break;
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<C> src, out GBlock64<D> dst, B @base = default)
        {
            var count = src.Length;
            var j = 0u;
            dst = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(test(@base, c))
                    dst[j++] = digit(@base,c);
                else
                    break;
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<S> src, out GBlock64<D> dst, B @base = default)
            => parse(recover<S,C>(src), out dst, @base);
        
    
    }
}