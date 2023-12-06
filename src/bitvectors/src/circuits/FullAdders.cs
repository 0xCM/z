//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static bit;

[ApiHost]
public class FullAdders
{
    public static void validate()
    {
        compute(Off, Off, Off, out bit s0, out bit c0);
        Require.equal(s0, Off);
        Require.equal(c0, Off);

        compute(On, Off, Off, out bit s1, out bit c1);
        Require.equal(s1, On);
        Require.equal(c1, Off);

        compute(On, On, Off, out bit s2, out bit c2);
        Require.equal(s2, Off);
        Require.equal(c2, On);

        compute(On, On, On, out bit s3, out bit c3);
        Require.equal(s3, On);
        Require.equal(c3, On);

        compute(Off, Off, On, out bit s4, out bit c4);
        Require.equal(s4, On);
        Require.equal(c4, Off);
    }

    [MethodImpl(Inline), Op]
    public static void compute(bit x, bit y, bit cin, out bit sum, out bit cout)
    {
        var a = x ^ y;
        var b = a & cin;
        var c = x & y;
        sum = a ^ cin;
        cout = b | c;
    }

    [MethodImpl(Inline), Op, NumericClosures(UnsignedInts)]
    public static void Compute<T>(T x, T y, T cin, out T sum, out T cout)
        where T : unmanaged
    {
        var a = gmath.xor(x, y);
        var b = gmath.and(a, cin);
        var c = gmath.and(x, y);
        sum = gmath.xor(a, cin);
        cout = gmath.or(b, c);
    }

    [MethodImpl(Inline), Op, NumericClosures(UnsignedInts)]
    public static void Compute<T>(Vector256<T> a, Vector256<T> b, Vector256<T> cin, out Vector256<T> sum, out Vector256<T> cout)
        where T : unmanaged
    {
        var a0 = vgcpu.vxor(a,b);
        var b0 = vgcpu.vand(a0,cin);
        var c0 = vgcpu.vand(a,b);
        sum = vgcpu.vxor(a0, cin);
        cout = vgcpu.vor(b0, c0);
    }

    [MethodImpl(Inline), Op, NumericClosures(UnsignedInts)]
    public static void Compute<T>(Vector128<T> a, Vector128<T> b, Vector128<T> cin, out Vector128<T> sum, out Vector128<T> cout)
        where T : unmanaged
    {
        var a0 = vgcpu.vxor(a,b);
        var b0 = vgcpu.vand(a0,cin);
        var c0 = vgcpu.vand(a,b);
        sum = vgcpu.vxor(a0, cin);
        cout = vgcpu.vor(b0, c0);
    }
}
