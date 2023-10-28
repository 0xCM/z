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
    public static Vector128<byte> vrotl(W128 n, N8 offset)
        => vload<byte>(n, RotL8_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotl(W128 n, N16 offset)
        => vload<byte>(n,RotL16_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotl(W128 n, N24 offset)
        => vload<byte>(n,RotL24_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotl(W128 n, N32 offset)
        => vload<byte>(n,RotL32_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotl(W128 n, N40 offset)
        => vload<byte>(n,RotL40_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotl(W128 n, N48 offset)
        => vload<byte>(n,RotL48_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotr(W128 n, N8 offset)
        => vload<byte>(n,RotR8_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotr(W128 n, N16 offset)
        => vload<byte>(n,RotR16_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotr(W128 n, N24 offset)
        => vload(n,RotR24_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotr(W128 n, N32 offset)
        => vload(n, RotR32_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotr(N128 n, N40 offset)
        => vload(n,RotR40_128x8u);

    [MethodImpl(Inline), Op]
    public static Vector128<byte> vrotr(W128 n, N48 offset)
        => vload(n,RotR48_128x8u);

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content leftward by 8 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotL8_128x8u
    {
        [MethodImpl(Inline)]
        get => RotL_128x8u.Slice(0*16, 16);
    }

    public static ReadOnlySpan<byte> RotL_128x8u
        => new byte[16*7]
        {
            F,0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,  //8
            14,F,0,1,2,3,4,5,6,7,8,9,A,B,C,D, //16
            D,E,F,0,1,2,3,4,5,6,7,8,9,A,B,C,  //24
            C,D,E,F,0,1,2,3,4,5,6,7,8,9,A,B,  //32
            B,C,D,E,F,0,1,2,3,4,5,6,7,8,9,A,  //40
            A,B,C,D,E,F,0,1,2,3,4,5,6,7,8,9,  //48
            9,A,B,C,D,E,F,0,1,2,3,4,5,6,7,8,  //56
        };

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content leftward by 16 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotL16_128x8u
    {
        [MethodImpl(Inline)]
        get => RotL_128x8u.Slice(1*16, 16);
    }

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content leftward by 24 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotL24_128x8u
    {
        [MethodImpl(Inline)]
        get => RotL_128x8u.Slice(2*16, 16);
    }

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content leftward by 32 bits
    /// </summary>
    static ReadOnlySpan<byte> RotL32_128x8u
    {
        [MethodImpl(Inline)]
        get => RotL_128x8u.Slice(3*16, 16);
    }

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content leftward by 40 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotL40_128x8u
    {
        [MethodImpl(Inline)]
        get => RotL_128x8u.Slice(4*16, 16);
    }

    /// <summary>
    /// Shuffle pattern that, when applied, rotates 128 bits of content leftward by 40 bits
    /// </summary>
    public static ReadOnlySpan<byte> RotL48_128x8u
    {
        [MethodImpl(Inline)]
        get => RotL_128x8u.Slice(5*16, 16);
    }
}
