//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Hex
{
    [MethodImpl(Inline), Op]
    public static char upper(Hex4 src)
        => Hex4.hexchar(UpperCase, src);

    /// <summary>
    /// Retrieves the character corresponding to a specified <see cref='HexDigitValue'/>
    /// </summary>
    /// <param name="case">The case specifier</param>
    /// <param name="value">The digit value</param>
    [MethodImpl(Inline), Op]
    public static char upper(HexDigitValue value)
        => (char)symbol(UpperCase, value);
}
