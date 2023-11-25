//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static BitMaskLiterals;
using static vcpu;

partial struct vmask
{
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vcentral(W128 w, W8 t, N4 f, N2 d)
        => vbroadcast(w, Central8x4x2);

    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vcentral(W128 w, W16 t, N4 f, N2 d)
        => vbroadcast(w, Central16x4x2);

    [MethodImpl(Inline), Op]
    public static Vector128<uint> vcentral(W128 w, W32 t, N4 f, N2 d)
        => vbroadcast(w, Central32x4x2);

    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vcentral(W128 w, W64 t, N4 f, N2 d)
        => vbroadcast(w, Central64x4x2);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vcentral(W128 w, W8 t, N8 f, N4 d)
        => vbroadcast(w, Central8x8x4);

    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vcentral(W128 w, W16 t, N8 f, N4 d)
        => vbroadcast(w, Central16x8x4);

    [MethodImpl(Inline), Op]
    public static Vector128<uint> vcentral(W128 w, W32 t, N8 f, N4 d)
        => vbroadcast(w, Central32x8x4);

    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vcentral(W128 w, W64 t, N8 f, N4 d)
        => vbroadcast(w,  Central64x8x4);

    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vcentral(W128 w, W16 t, N16 f, N8 d)
        => vbroadcast(w, Central16x16x8);

    [MethodImpl(Inline), Op]
    public static Vector128<uint> vcentral(W128 w, W32 t, N16 f, N8 d)
        => vbroadcast(w, Central32x16x8);

    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vcentral(W128 w, W64 t, N16 f, N8 d)
        => vbroadcast(w, Central64x16x8);

    [MethodImpl(Inline), Op]
    public static Vector128<uint> vcentral(W128 w, W32 t, N32 f, N16 d)
        => vbroadcast(w, Central32x32x16);

    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vcentral(W128 w, W64 t, N32 f, N16 d)
        => vbroadcast(w, Central64x32x16);

    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vcentral(W128 w, W64 t, N64 f, N32 d)
        => vbroadcast(w, Central64x64x32);

    [MethodImpl(Inline), Op]
    public static Vector256<byte> vcentral(W256 w, W8 t, N4 f, N2 d)
        => vbroadcast(w, Central8x4x2);

    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vcentral(W256 w, W16 t, N4 f, N2 d)
        => vbroadcast(w, Central16x4x2);

    [MethodImpl(Inline), Op]
    public static Vector256<uint> vcentral(W256 w, W32 t, N4 f, N2 d)
        => vbroadcast(w,  Central32x4x2);

    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vcentral(W256 w, W64 t, N4 f, N2 d)
        => vbroadcast(w, Central64x4x2);

    [MethodImpl(Inline), Op]
    public static Vector256<byte> vcentral(W256 w, W8 t, N4 f, N4 d)
        => vbroadcast(w,  Central8x8x4);

    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vcentral(W256 w, W16 t, N4 f, N4 d)
        => vbroadcast(w,  Central16x8x4);

    [MethodImpl(Inline), Op]
    public static Vector256<uint> vcentral(W256 w, W32 t, N4 f, N4 d)
        => vbroadcast(w,  Central32x8x4);

    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vcentral(W256 w, W64 t, N4 f, N4 d)
        => vbroadcast(w, Central64x8x4);

    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vcentral(W256 w, W16 t, N16 f, N8 d)
        => vbroadcast(w, Central16x16x8);

    [MethodImpl(Inline), Op]
    public static Vector256<uint> vcentral(W256 w, W32 t, N16 f, N8 d)
        => vbroadcast(w,  Central32x16x8);

    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vcentral(W256 w, W64 t, N16 f, N8 d)
        => vbroadcast(w, Central64x16x8);

    [MethodImpl(Inline), Op]
    public static Vector256<uint> vcentral(W256 w, W32 t, N32 f, N16 d)
        => vbroadcast(w,  Central32x32x16);

    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vcentral(W256 w, W64 t, N32 f, N16 d)
        => vbroadcast(w, Central64x32x16);

    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vcentral(W256 w, W64 t, N64 f, N32 d)
        => vbroadcast(w, Central64x64x32);
}
