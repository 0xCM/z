//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static SymVal<B,AsciCode,byte,N8> symbol<B>(B @base, AsciCode src)
            where B : unmanaged, INumericBase
                => new SymVal<B,AsciCode,byte,N8>(src);

        [MethodImpl(Inline), Op]
        public static SymVal<Base2,AsciCode,byte,N8> bin(AsciCode code)
            => symbol(base2, code);

        [MethodImpl(Inline), Op]
        public static SymVal<Base8,AsciCode,byte,N8> oct(AsciCode code)
            => symbol(base8, code);

        [MethodImpl(Inline), Op]
        public static SymVal<Base10,AsciCode,byte,N8> dec(AsciCode code)
            => symbol(base10, code);

        [MethodImpl(Inline), Op]
        public static SymVal<Base16,AsciCode,byte,N8> hex(AsciCode code)
            => symbol(base16, code);

        [MethodImpl(Inline), Op]
        public static BinaryDigitSym symbol(BinaryDigitValue src)
            => (BinaryDigitSym)(src + (byte)BinarySymFacet.First);

        [MethodImpl(Inline), Op]
        public static OctalDigitSym symbol(OctalDigitValue src)
            => (OctalDigitSym)((byte)src + (byte)OctalSymFacet.First);

        [MethodImpl(Inline), Op]
        public static BinaryDigitSym symbol(Base2 @base, byte src)
            => (BinaryDigitSym)(src + (byte)BinarySymFacet.First);

        [MethodImpl(Inline), Op]
        public static DecimalDigitSym symbol(DecimalDigitValue src)
            => (DecimalDigitSym)((byte)src + DecimalSymFacet.First);

        [MethodImpl(Inline), Op]
        public static HexDigitSym symbol(LetterCaseKind @case, HexDigitValue src)
            => Hex.symbol(@case, src);

        [MethodImpl(Inline), Op]
        public static HexDigitSym symbol(UpperCased @case, HexDigitValue src)
            => Hex.symbol(@case, src);

        [MethodImpl(Inline), Op]
        public static HexDigitSym symbol(LowerCased @case, HexDigitValue src)
            => Hex.symbol(@case, src);
    }
}