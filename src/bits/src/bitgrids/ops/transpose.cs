//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitGrid
    {
        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static BitGrid64<N8,N8,T> transpose<T>(BitGrid64<N8,N8,T> g)
            where T : unmanaged
        {
            var dst = z64<N8,N8,byte>();
            var src = cpu.vscalar(w128,g.Data);
            for(var i=7; i>= 0; i--)
            {
                dst.Cell(i) = (byte)cpu.vmovemask(cpu.v8u(src));
                src = cpu.vsll(src,1);
            }
            return dst.As<T>();
        }

        [MethodImpl(Inline), Op]
        public static BitGrid64<N4,N16,ulong> transpose2(BitGrid64<N16,N4,ulong> A)
        {
            const ulong C = 0b0001_0001_0001_0001_0001_0001_0001_0001_0001_0001_0001_0001_0001_0001_0001_0001;
            var r = A.RowCount;
            var c = A.ColCount;
            var R = math.pow2m1(r);

            var c0 = bits.gather(A.Content, C << 0);
            var c1 = bits.gather(A.Content, C << 1);
            var c2 = bits.gather(A.Content, C << 2);
            var c3 = bits.gather(A.Content, C << 3);

            var r0 = bits.scatter(c0, R << 0*r);
            var r1 = bits.scatter(c1, R << 1*r);
            var r2 = bits.scatter(c2, R << 2*r);
            var r3 = bits.scatter(c3, R << 3*r);
            return r0 | r1 | r2 | r3;
        }

        [MethodImpl(Inline), Op]
        public static BitGrid64<N4,N16,ulong> transpose(BitGrid64<N16,N4,ulong> A)
            => BitGrid.create(n64,n4,n16,
                (ulong)A.Col(0) << 0  |
                (ulong)A.Col(1) << 16 |
                (ulong)A.Col(2) << 32 |
                (ulong)A.Col(3) << 48
                );

        [MethodImpl(Inline)]
        static Vector256<T> gcell<T>(in Vector256<T> g, int index, T data)
            where T : unmanaged
                => g.WithElement(index, data);

        [MethodImpl(Inline)]
        static Vector256<T> vT16x16step<T>(in Vector256<T> src, in Vector256<T> g0, int i, int j)
            where T : unmanaged
        {
            const uint E = BitMaskLiterals.Even32;
            const uint O = BitMaskLiterals.Odd32;

            var mask = gcpu.vmask32u(src, (byte)i);
            var gT = gcell(g0, i, Numeric.force<T>(bits.gather(mask, E)));
            gT = gcell(gT, j, Numeric.force<T>(bits.gather(mask, O)));
            return gT;
        }

        [MethodImpl(Inline), Op]
        public static BitGrid256<N16,N16,ushort> transpose(in BitGrid256<N16,N16,ushort> g)
        {
            var gT = default(Vector256<ushort>);
            var src = g.Content;
            gT = vT16x16step(src, gT, 0, 8);
            gT = vT16x16step(src, gT, 1, 9);
            gT = vT16x16step(src, gT, 2, 10);
            gT = vT16x16step(src, gT, 3, 11);
            gT = vT16x16step(src, gT, 4, 12);
            gT = vT16x16step(src, gT, 5, 13);
            gT = vT16x16step(src, gT, 6, 14);
            gT = vT16x16step(src, gT, 7, 15);
            return load(gT,n16,n16);
        }
    }
}