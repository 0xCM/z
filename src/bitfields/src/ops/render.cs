//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    [MethodImpl(Inline), Op]
    public static uint render(Bitfield8 src, Span<char> dst)
        => BitRender.render4x4(sys.bytes(src), dst);

    [MethodImpl(Inline), Op]
    public static uint render(Bitfield16 src, Span<char> dst)
        => BitRender.render4x4(sys.bytes(src), dst);

    [MethodImpl(Inline), Op]
    public static uint render(Bitfield32 src, Span<char> dst)
        => BitRender.render4x4(sys.bytes(src), dst);

    [MethodImpl(Inline), Op]
    public static uint render(Bitfield64 src, Span<char> dst)
        => BitRender.render4x4(sys.bytes(src), dst);
}
