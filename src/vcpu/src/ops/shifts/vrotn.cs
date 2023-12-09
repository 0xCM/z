//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static HexConst;
using static CpuBytes;

partial class vcpu
{
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrol(W128 n, N8 count)
        => vload<byte>(n, RotL8_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrol(W128 n, N16 count)
        => vload<byte>(n,RotL16_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrol(W128 n, N24 count)
        => vload<byte>(n,RotL24_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrol(W128 n, N32 count)
        => vload<byte>(n,RotL32_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrol(W128 n, N40 count)
        => vload<byte>(n,RotL40_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrol(W128 n, N48 count)
        => vload<byte>(n,RotL48_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vror(W128 n, N8 count)
        => vload<byte>(n,RotR8_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vror(W128 n, N16 count)
        => vload<byte>(n,RotR16_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vror(W128 n, N24 count)
        => vload(n,RotR24_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vror(W128 n, N32 count)
        => vload(n, RotR32_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vror(N128 n, N40 count)
        => vload(n,RotR40_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vror(W128 n, N48 count)
        => vload(n,RotR48_128x8u);

}
