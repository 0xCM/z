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
        public static uint read(ReadOnlySpan<char> src, out GBlock64<D> dst, B @base = default)
        {
            var parser = Hex64DigitReader.Service;
            dst = parser.Read(src);
            return parser.Counter;
        }

        [MethodImpl(Inline), Op]
        public static uint read(ReadOnlySpan<C> src, out GBlock64<D> dst, B @base = default)
        {
            var parser = Hex64DigitReader.Service;
            dst = parser.Read(src);
            return parser.Counter;
        }

        [MethodImpl(Inline), Op]
        public static uint read(ReadOnlySpan<S> src, out GBlock64<D> dst, B @base = default)
            => read(recover<S,C>(src), out dst, @base);    
    }
}