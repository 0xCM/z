//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Hex
{
    /// <summary>
    /// Retrieves the character corresponding to a specified <see cref='HexDigitValue'/>
    /// </summary>
    /// <param name="case">The case specifier</param>
    /// <param name="value">The digit value</param>
    [MethodImpl(Inline), Op]
    public static char lower(HexDigitValue value)
        => (char)symbol(LowerCase, value);

    [MethodImpl(Inline), Op]
    public static char lower(Hex4 src)
        => (char)symbol(LowerCase, src.Value);
}
