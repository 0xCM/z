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

    struct Hex64DigitParser : IBlockMap<GBlock64<D>, char>, IBlockMap<GBlock64<D>,C>
    {
        uint Count;

        GBlock64<D> Storage;

        public uint Counter
        {
            get => Count;
        }

        public Hex64DigitParser()
        {
            Count = 0;
            Storage = default;
        }

        public GBlock64<D> Map(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var j = 0u;
            var dst = sys.recover<D>(sys.bytes(Storage));
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(base16, c))
                    seek(dst,j++) = Digital.digit(base16,c);
            }
            Count = j;    
            return Storage;
        }

        public GBlock64<D> Map(ReadOnlySpan<C> src)
        {
            var count = src.Length;
            var j = 0u;
            var dst = sys.recover<D>(sys.bytes(Storage));
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(base16, c))
                    seek(dst,j++) = Digital.digit(base16,c);
                else
                    break;
            }
            Count = j;
            return Storage;            
        }

        public static Hex64DigitParser Service => new();
    }

    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<char> src, out GBlock64<D> dst, B @base = default)
        {
            var parser = Hex64DigitParser.Service;
            dst = parser.Map(src);
            return parser.Counter;
            // var count = src.Length;
            // var j = 0u;
            // dst = default;
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var c = ref skip(src,i);
            //     if(test(@base, c))
            //         dst[j++] = digit(@base,c);
            //     else
            //         break;
            // }
            // return j;
        }

        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<C> src, out GBlock64<D> dst, B @base = default)
        {
            var parser = Hex64DigitParser.Service;
            dst = parser.Map(src);
            return parser.Counter;

            // var count = src.Length;
            // var j = 0u;
            // dst = default;
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var c = ref skip(src,i);
            //     if(test(@base, c))
            //         dst[j++] = digit(@base,c);
            //     else
            //         break;
            // }
            // return j;
        }

        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<S> src, out GBlock64<D> dst, B @base = default)
            => parse(recover<S,C>(src), out dst, @base);    
    }
}