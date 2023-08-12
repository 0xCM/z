//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;
        
public static partial class XHex
{
    [Op]
    public static string FormatBits(this Hex2 src)
        => BitRender.format2(src);

    [Op]
    public static string FormatBits(this Hex3 src)
        => BitRender.format3(src);

    [Op]
    public static string FormatBits(this Hex4 src)
        => BitRender.format4(src);

    [Op]
    public static string FormatBits(this Hex5 src)
        => BitRender.format5(src);

    [Op]
    public static string FormatBits(this Hex6 src)
        => BitRender.format6(src);

    [Op]
    public static string FormatBits(this Hex7 src)
        => BitRender.format7(src);

    [Op]
    public static string FormatBits(this Hex8 src, N4 n)
        => BitRender.format8x4(src);

    [Op]
    public static string FormatBits(this Hex8 src, N8 n)
        => BitRender.format8(src);

    [Op]
    public static string FormatBits(this Hex16 src, N4 n)
        => BitRender.format16x4(src);

    [Op]
    public static string FormatBits(this Hex16 src, N8 n)
        => BitRender.format16x8(src);

    [Op]
    public static string FormatBits(this Hex32 src, N4 n)
        => BitRender.format32x4(src);

    [Op]
    public static string FormatBits(this Hex32 src, N8 n)
        => BitRender.format32x8(src);

    [Op]
    public static string FormatBits(this Hex64 src, N4 n)
        => BitRender.format64x4(src);

    [Op]
    public static string FormatBits(this Hex64 src, N8 n)
        => BitRender.format64x8(src);        
}
