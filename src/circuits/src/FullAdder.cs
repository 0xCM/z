//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class FullAdder
    {
        [MethodImpl(Inline), Op]
        public static void Compute(bit x, bit y, bit cin, out bit sum, out bit cout)
        {
            var a = x ^ y;
            var b = a & cin;
            var c = x & y;
            sum = a ^ cin;
            cout = b | c;
        }

        [MethodImpl(Inline), Op]
        public static OutPair<bit> Compute(bit x, bit y, bit cin)
        {
            var a = x ^ y;
            var b = a & cin;
            var c = x & y;
            var sum = a ^ cin;
            var cout = b | c;
            return(sum, cout);
        }

        [MethodImpl(Inline), Op]
        public static BitVector64 Compute(BitVector32 x, BitVector32 y, BitVector32 cin)
        {
            var a = x ^ y;
            var b = a & cin;
            var c = x & y;
            var sum = a ^ cin;
            var cout = b | c;
            return BitVectors.join(sum,cout);
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
        public static OutPair<Vector256<T>> Compute<T>(Vector256<T> a, Vector256<T> b, Vector256<T> cin)
            where T : unmanaged
        {
            Compute(a,b,cin, out Vector256<T> sum, out Vector256<T> cout);
            return(sum,cout);
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

        [MethodImpl(Inline), Op, NumericClosures(UnsignedInts)]
        public static OutPair<Vector128<T>> Compute<T>(Vector128<T> x, Vector128<T> y, Vector128<T> cin)
            where T : unmanaged
        {
            Compute(x,y,cin, out Vector128<T> sum, out Vector128<T> cout);
            return(sum,cout);
        }
    }
}