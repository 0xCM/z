//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static HexFormatSpecs;

using C = AsciCode;
using XD = HexDigitFacets;
using XS = HexSymFacet;
using DS = DecimalSymFacet;

[Free,ApiHost]
public class HexTest
{

    /// <summary>
    /// Tests whether a specified character matches the hex postfix character
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static bit postfix(char c)
        => c  == Chars.h;

    /// <summary>
    /// Tests whether a specified character sequence matches the '0x' prefix specifier
    /// </summary>
    /// <param name="a0"></param>
    /// <param name="a1"></param>
    [MethodImpl(Inline), Op]
    public static bit prefix(char a0, char a1)
        => a0 == Chars.D0 && a1 == Chars.x;

    /// <summary>
    /// Tests whether a character symbol is one of '0'..'9'
    /// </summary>
    /// <param name="src">The symbol to test</param>
    [MethodImpl(Inline), Op]
    public static bit number(char c)
        => (DS)c >= DS.First && (DS)c <= DS.Last;

    /// <summary>
    /// Tests whether a character symbol is one of '0'..'9'
    /// </summary>
    /// <param name="src">The symbol to test</param>
    [MethodImpl(Inline), Op]
    public static bit number(C c)
        => (DS)c >= DS.First && (DS)c <= DS.Last;

    /// <summary>
    /// Tests whether a <see cref='HexLowerSym'/> value is one of '0',...,'9'
    /// </summary>
    /// <param name="src">The symbol to test</param>
    [MethodImpl(Inline), Op]
    public static bit number(HexLowerSym src)
        => (XS)src <= XS.LastNumber;

    /// <summary>
    /// Tests whether a <see cref='HexUpperSym'/> value is one of '0',...,'9'
    /// </summary>
    /// <param name="src">The symbol to test</param>
    [MethodImpl(Inline), Op]
    public static bit number(HexUpperSym src)
        => (XS)src <= XS.LastNumber;

    /// <summary>
    /// Determines whether a character is an upper-cased hex digit
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit test(UpperCased casing, char c)
        => hexscalar(c) || hexupper(c);

    /// <summary>
    /// Determines whether a character is an upper-cased hex digit
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit test(UpperCased casing, C c)
        => hexscalar(c) || hexupper(c);

    /// <summary>
    /// Determines whether a character is a lower-cased hex digit
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit test(LowerCased casing, char c)
        => hexscalar(c) || hexlower(c);

    /// <summary>
    /// Determines whether a character is a hex digit of any case
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit test(char c)
        => hexscalar(c) || hexlower(c) || hexupper(c);

    /// <summary>
    /// Determines whether a character corresponds to one of the lowercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit lower(C c)
        => (HexDigitCode)c >= XD.MinLetterCodeL && (HexDigitCode)c <= XD.MaxLetterCodeL;

    /// <summary>
    /// Determines whether a character corresponds to one of the uppercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit upper(C c)
        => (HexDigitCode)c >= XD.MinLetterCodeU && (HexDigitCode)c <= XD.MaxLetterCodeU;

    /// <summary>
    /// Determines whether a character corresponds to one of the uppercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit upper(char c)
        => upper((C)c);

    /// <summary>
    /// Determines whether a character corresponds to one of the lowercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit lower(char c)
        => lower((C)c);

    /// <summary>
    /// Determines whether a character corresponds to one of the lower hex codes
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit scalar(C c)
        => (HexDigitCode)c >= XD.MinScalarCode && (HexDigitCode)c <= XD.MaxScalarCode;

    /// <summary>
    /// Determines whether a character corresponds to one of the lower hex codes
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bit scalar(char c)
        => scalar((C)c);

    public static bit prespec(ReadOnlySpan<char> src)
        => src.TrimStart().StartsWith(PreSpec);

    public static bit postspec(ReadOnlySpan<char> src)
        => src.TrimEnd().EndsWith(PostSpec);

    [MethodImpl(Inline), Op]
    public static bit fence(char c)
        => c == Chars.LBracket || c == Chars.RBracket;

    [MethodImpl(Inline)]
    public static bit separator(char src)
        => src == Chars.Comma || whitespace((C)src);

    [MethodImpl(Inline)]
    static bit whitespace(char src)
        => whitespace((C)src);

    [MethodImpl(Inline)]
    static bit whitespace(C src)
        => SQ.contains(whitespace(), src);

    [MethodImpl(Inline), Op]
    static ReadOnlySpan<C> whitespace()
        => Whitespace;

    static ReadOnlySpan<C> Whitespace
        => new []{C.CR, C.FF, C.NL, C.Space, C.Tab, C.VTab};

    /// <summary>
    /// Determines whether a character is one of [0..9]
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline)]
    static bit hexscalar(char c)
        => (XS)c >= XS.FirstNumber && (XS)c <= XS.LastNumber;

    /// <summary>
    /// Determines whether a character is one of [0..9]
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline)]
    static bit hexscalar(C c)
        => (XS)c >= XS.FirstNumber && (XS)c <= XS.LastNumber;

    /// <summary>
    /// Determines whether a character corresponds to one of the uppercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline)]
    static bit hexupper(char c)
        => (XS)c >= XS.FirstLetterUp && (XS)c <= XS.LastLetterUp;

    /// <summary>
    /// Determines whether a character corresponds to one of the uppercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline)]
    static bit hexupper(AsciCode c)
        => (XS)c >= XS.FirstLetterUp && (XS)c <= XS.LastLetterUp;

    /// <summary>
    /// Determines whether a character corresponds to one of the lowercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline)]
    static bit hexlower(char c)
        => (XS)c >= XS.FirstLetterLo && (XS)c <= XS.LastLetterUp;
}
