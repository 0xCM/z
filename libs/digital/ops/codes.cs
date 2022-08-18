//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Digital
    {
        [Op, Closures(Closure)]
        public static Index<HexLowerCode> codes<T>(in T src, Base16 @base, LowerCased @case)
            where T : struct
        {
            var count = Sized.size<T>();
            var dst = sys.alloc<HexLowerCode>(count*2);
            codes(src,dst);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void codes<T>(in T src, Span<HexLowerCode> dst)
            where T : struct
        {
            var count = Sized.size<T>();
            ref readonly var bytes = ref @as<T,byte>(src);
            var j = count*2 - 1;
            for(var i=0u; i<count; i++)
            {
                ref readonly var d = ref skip(bytes,i);
                seek(dst, j--) = Hex.code(n4, LowerCase, d);
                seek(dst, j--) = Hex.code(n4, LowerCase, Bytes.srl(d, 4));
            }
        }

        /// <summary>
        /// Projects a bytespan into a codespan
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The hexcode target</param>
        [MethodImpl(Inline), Op]
        public static int codes(ReadOnlySpan<byte> src, UpperCased @case, Span<HexDigitCode> dst)
        {
            var j=0u;
            for(var i=0u; i<src.Length; i++, j+=2)
            {
                ref readonly var data = ref skip(src, i);
                seek(dst, j) = Hex.code(@case, (HexDigitValue)(data >> 4));
                seek(dst, j + 1) = Hex.code(@case, (HexDigitValue)(0xF & data));
            }
            return (int)j;
        }

        /// <summary>
        /// Projects a bytespan into a codespan
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The hexcode target</param>
        [MethodImpl(Inline), Op]
        public static int codes(ReadOnlySpan<byte> src, LowerCased @case, Span<HexDigitCode> dst)
        {
            var j=0u;
            for(var i=0u; i<src.Length; i++, j+=2)
            {
                ref readonly var data = ref skip(src, i);
                seek(dst, j) = Hex.code(@case, (HexDigitValue)(data >> 4));
                seek(dst, j + 1) = Hex.code(@case, (HexDigitValue)(0xF & data));
            }
            return (int)j;
        }
    }
}