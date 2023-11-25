//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vgcpu
{
    /// <summary>
    /// Populates a bitstring from a 128-bit cpu vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="maxbits">The maximum number of bits to extract from the source</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static BitString bitstring<T>(Vector128<T> src, int? maxbits = null)
        where T : unmanaged
            => BitStrings.scalars(sys.cover(vcpu.vref(ref src), vcpu.vcount<T>(W128.W)), maxbits);

    /// <summary>
    /// Populates a bitstring from a 256-bit cpu vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="maxbits">The maximum number of bits to extract</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static BitString bitstring<T>(Vector256<T> src, int? maxbits = null)
        where T : unmanaged
            => BitStrings.scalars(sys.cover(vcpu.vref(ref src), vcpu.vcount<T>(W256.W)), maxbits);

    /// <summary>
    /// Populates a bitstring from a 256-bit cpu vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="maxbits">The maximum number of bits to extract</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    public static BitString bitstring<T>(Vector512<T> src, int? maxbits = null)
        where T : unmanaged
            => BitStrings.scalars(sys.cover(vcpu.vref(ref src), vcpu.vcount<T>(W512.W)), maxbits);
}