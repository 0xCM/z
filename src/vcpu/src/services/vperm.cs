//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static BitMaskLiterals;

[Free,ApiHost]
public class vperm
{
    /// <summary>
    /// Computes the digits corresponding to each 4-bit segment of the permutation spec as
    /// </summary>
    /// <param name="src">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vdigits(Perm16 spec)
        => vcpu.vshuffle(vgcpu.vinc<byte>(w128), spec.Data);

    /// <summary>
    /// Computes the digits corresponding to each 5-bit segment of the permutation spec
    /// </summary>
    /// <param name="src">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vdigits(Perm32 spec)
        => vcpu.vshuf32x8(vgcpu.vinc<byte>(w256), spec.Data);
                
    /// <summary>
    /// Creates a fixed 16-bit permutation over a generic permutation over 16 elements
    /// </summary>
    /// <param name="src">The source permutation</param>
    [MethodImpl(Inline), Op]
    public static Perm16 perm16(W128 w, Perm<byte> spec)
        => new (vcpu.vload(w128, spec.Terms.View));

    [MethodImpl(Inline), Op]
    public static Perm16 perm16(Vector128<byte> data)
        => new (vcpu.vand(data, vcpu.vbroadcast(w128, Msb8x8x3)));

    /// <summary>
    /// Creates a fixed 32-bit permutation over a generic permutation over 32 elements
    /// </summary>
    /// <param name="src">The source permutation</param>
    [MethodImpl(Inline), Op]
    public static Perm32 perm32(W256 w, Perm<byte> src)
        => new (vgcpu.vload(w, src.Terms.View));

    [MethodImpl(Inline), Op]
    public static Perm32 perm32(Vector256<byte> data)
        => new (vcpu.vand(data, vcpu.vbroadcast(w256, Msb8x8x3)));            
}
