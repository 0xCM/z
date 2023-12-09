//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    [MethodImpl(Inline)]
    static Vector256<sbyte> vperm4x64(Vector256<sbyte> x, [Imm] Perm4L spec)
        => v8i(Permute4x64(v64i(x), (byte)spec));

    [MethodImpl(Inline)]
    static Vector256<byte> vperm4x64(Vector256<byte> x, [Imm] Perm4L spec)
        => v8u(Permute4x64(v64u(x), (byte)spec));

    [MethodImpl(Inline)]
    static Vector512<sbyte> vperm4x64(Vector512<sbyte> x, [Imm] Perm4L spec)
        => v8i(Permute4x64(v64u(x), (byte)spec));

    [MethodImpl(Inline)]
    static Vector512<byte> vperm4x64(Vector512<byte> x, [Imm] Perm4L spec)
        => v8u(Permute4x64(v64u(x), (byte)spec));

    /// <summary>
    /// (16x16i,16x16i) -> 32x8i
    /// </summary>
    /// <param name="a">The first source vector</param>
    /// <param name="b">The second source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vpack256x8i(Vector256<short> a, Vector256<short> b)
        => vperm4x64(vpackss(a,b), Perm4L.ACBD);
}
