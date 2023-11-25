//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static HexCharData;

partial struct Hex
{
    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(LowerCased casing, byte index)
        => (HexDigitSym)(index < LowerSymbolCount ? skip(LowerSymbols, index) : HexLowerSym.None);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(UpperCased casing, byte index)
        => (HexDigitSym)(index < UpperSymbolCount ? skip(UpperSymbols, index) : HexUpperSym.None);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(LowerCased casing, Hex2Kind src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(UpperCased casing, Hex2Kind src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(LowerCased casing, Hex3Kind src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(UpperCased casing, Hex3Kind src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(LowerCased casing, Hex4Kind src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(UpperCased casing, Hex4Kind src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(LowerCased casing, Hex4 src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(UpperCased casing, Hex4 src)
        => symbol(casing, (HexDigitValue)src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(UpperCased @case, HexDigitValue src)
        => (HexDigitSym)code(@case, src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(LowerCased @case, HexDigitValue src)
        => (HexDigitSym)code(@case, src);

    [MethodImpl(Inline), Op]
    public static HexDigitSym symbol(LetterCaseKind @case, HexDigitValue src)
        => @case == LetterCaseKind.Upper ? symbol(UpperCase, src) : symbol(LowerCase, src);

    [MethodImpl(Inline)]
    public static HexDigitSym symbol<C>(C @case, HexDigitValue src)
        where C : unmanaged, ILetterCase
    {
        if(typeof(C) == typeof(LowerCased))
            return symbol(LowerCase,src);
        else if(typeof(C) == typeof(UpperCased))
            return symbol(UpperCase,src);
        else
            throw no<C>();
    }

    [MethodImpl(Inline)]
    public static HexDigitSym symbol<C>(C @case, byte index)
        where C : unmanaged, ILetterCase
    {
        if(typeof(C) == typeof(LowerCased))
            return symbol(LowerCase,index);
        else if(typeof(C) == typeof(UpperCased))
            return symbol(UpperCase,index);
        else
            throw no<C>();
    }         
}
