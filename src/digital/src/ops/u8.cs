//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Digital
{
    [MethodImpl(Inline), Op]
    public static byte u8(Base2 @base, char c)
        => (byte)digit(@base, c);

    [MethodImpl(Inline), Op]
    public static byte u8(Base8 @base, char c)
        => (byte)digit(@base, c);

    [MethodImpl(Inline), Op]
    public static byte u8(Base10 @base, char c)
        => (byte)digit(@base, c);

    [MethodImpl(Inline), Op]
    public static byte u8(Base16 @base, char c)
        => (byte)digit(@base, c);

    [MethodImpl(Inline), Op]
    public static byte u8(Base16 @base, UpperCased @case, char c)
        => (byte)digit(@base, @case, c);

    [MethodImpl(Inline), Op]
    public static byte u8(Base16 @base, LowerCased @case, char c)
        => (byte)digit(@base, @case, c);
}
