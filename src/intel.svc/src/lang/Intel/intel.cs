//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang;

using static sys;

using Intel;


[ApiHost("dsl.intel")]
public class intel
{
    const NumericKind Closure = NumericKind.UnsignedInts;

    [MethodImpl(Inline), Op]
    public static __m128i<byte> calc(in mm_delta_epu8 src)
        => vcpu.vor(vcpu.vsubs(src.A, src.B), vcpu.vsubs(src.B, src.A));

    [MethodImpl(Inline), Op]
    public static __m256i<byte> calc(in mm256_min_epu8 src)
        => vcpu.vmin(src.A,src.B);

    [MethodImpl(Inline)]
    public static CmpPred128<T> eq<T>(__m128i<T> a, __m128i<T> b)
        where T : unmanaged
            => new (CmpPredKind.EQ,a,b);

    [MethodImpl(Inline), Closures(Closure)]
    public static __m128i<T> m128i<T>()
        where T : unmanaged
            => default;

    [MethodImpl(Inline), Closures(Closure)]
    public static __m256i<T> m256i<T>()
        where T : unmanaged
            => default;

    [MethodImpl(Inline), Closures(Closure)]
    public static __m512i<T> m512i<T>()
        where T : unmanaged
            => default;
}
