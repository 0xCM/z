//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using X = HexDigitFacets;

/// <summary>
/// Defines operations over character digits
/// </summary>
partial struct Digital
{
    /// <summary>
    /// Determines whether a character corresponds to one of the lower hex codes
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bool scalar(Base16 @base, char c)
        => (HexDigitCode)c >= X.MinScalarCode && (HexDigitCode)c <= X.MaxScalarCode;

    /// <summary>
    /// Determines whether a character corresponds to one of the uppercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bool upper(Base16 @base, char c)
        => (HexDigitCode)c >= X.MinLetterCodeU && (HexDigitCode)c <= X.MaxLetterCodeU;

    /// <summary>
    /// Determines whether a character corresponds to one of the lowercase hex code characters
    /// </summary>
    /// <param name="c">The character to test</param>
    [MethodImpl(Inline), Op]
    public static bool lower(Base16 @base, char c)
        => (HexDigitCode)c >= X.MinLetterCodeL && (HexDigitCode)c <= X.MaxLetterCodeL;
}
