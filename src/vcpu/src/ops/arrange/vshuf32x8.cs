//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Rearranges the source vector according to the indices specified in the control vector dst[i] = src[spec[i]]
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The control vector that defines the permutation</param>
    /// <remarks>Approach follows https://stackoverflow.com/questions/30669556/shuffle-elements-of-m256i-vector/30669632#30669632</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vshuf32x8(Vector256<byte> a, Vector256<byte> spec)
    {
        var x = vshuf16x8(a, vadd(spec, K0V));
        var y = vshuf16x8(vswaphl(a), vadd(spec, K1V));
        return vor(x,y);
    }

    const byte M70 = 0b01110000;

    const byte MF0 = 0b11110000;

    static Vector256<byte> K0V
    {
        [MethodImpl(Inline)]
        get => vload(w256, K0Bytes);
    }

    static Vector256<byte> K1V
    {
        [MethodImpl(Inline)]
        get => vload(w256, K1Bytes);
    }

    static ReadOnlySpan<byte> K0Bytes
        => new byte[]
            {
                M70, M70, M70, M70, M70, M70, M70, M70,
                M70, M70, M70, M70, M70, M70, M70, M70,
                MF0, MF0, MF0, MF0, MF0, MF0, MF0, MF0,
                MF0, MF0, MF0, MF0, MF0, MF0, MF0, MF0
            };

    static ReadOnlySpan<byte> K1Bytes
        => new byte[]
            {
                MF0, MF0, MF0, MF0, MF0, MF0, MF0, MF0,
                MF0, MF0, MF0, MF0, MF0, MF0, MF0, MF0,
                M70, M70, M70, M70, M70, M70, M70, M70,
                M70, M70, M70, M70, M70, M70, M70, M70
            };
}
