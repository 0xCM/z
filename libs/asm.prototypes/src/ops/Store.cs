//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static ByteBlocks;

    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + store)]
        public readonly struct Store
        {
            [Op, Closures(AllNumeric)]
            public static uint deposit<T>(ReadOnlySpan<T> src, Span<T> dst)
                where T : unmanaged
            {
                seek(dst,0) = skip(src,0);
                seek(dst,1) = skip(src,1);
                seek(dst,2) = skip(src,2);
                seek(dst,3) = skip(src,3);
                seek(dst,4) = skip(src,4);

                return 5;
            }

            [Op, Closures(AllNumeric)]
            public static unsafe void pdeposit<T>(T* pSrc, T* pDst)
                where T : unmanaged
            {
                *pDst++ = *pSrc++;
                *pDst++ = *pSrc++;
                *pDst++ = *pSrc++;
                *pDst++ = *pSrc++;
                *pDst++ = *pSrc++;
            }

            [Op, Closures(AllNumeric)]
            public static unsafe void pdeposit2<T>(T* pSrc, T* pDst)
                where T : unmanaged
            {
                seek(pDst,0) = skip(pSrc,0);
                seek(pDst,1) = skip(pSrc,1);
                seek(pDst,2) = skip(pSrc,2);
                seek(pDst,3) = skip(pSrc,3);
                seek(pDst,4) = skip(pSrc,4);

            }

            [Op]
            public static void deposit(Span<byte> dst, byte a0, byte a1)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
            }

            [Op]
            public static void deposit(Span<Cell128> dst, Cell128 a0, Cell128 a1)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;

            }

            [Op]
            public static void deposit(Span<Cell256> dst, Cell256 a0, Cell256 a1)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
            }

            [Op]
            public static void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
            }

            [Op]
            public static void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1, Cell512 a2)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
            }

            [Op]
            public static void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1, Cell512 a2, Cell512 a3)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
            }

            [Op]
            public static void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1, Cell512 a2, Cell512 a3, Cell512 a4)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
            }

            [Op]
            public static void deposit_runtime(Span<Cell256> dst, Cell256 a0, Cell256 a1, Cell256 a2, Cell256 a3, Cell256 a4)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
            }

            [Op]
            public unsafe void deposit_intrinsic(Span<Cell256> dst, Cell256 a0, Cell256 a1, Cell256 a2, Cell256 a3, Cell256 a4)
            {
                cpu.vstore(cpu.vload(w256, first(a0.Bytes)), ref first(seek(dst,0).Bytes));
                cpu.vstore(cpu.vload(w256, first(a1.Bytes)), ref first(seek(dst,1).Bytes));
                cpu.vstore(cpu.vload(w256, first(a2.Bytes)), ref first(seek(dst,2).Bytes));
                cpu.vstore(cpu.vload(w256, first(a3.Bytes)), ref first(seek(dst,3).Bytes));
                cpu.vstore(cpu.vload(w256, first(a4.Bytes)), ref first(seek(dst,4).Bytes));
            }

            [Op]
            public static void deposit(Span<ByteBlock64> dst, ByteBlock64 a0, ByteBlock64 a1)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
            }

            [Op]
            public static void deposit(Span<ByteBlock128> dst, ByteBlock128 a0, ByteBlock128 a1)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
            }

            [Op]
            public static void deposit(Span<byte> dst, in byte a0, in byte a1)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
            }

            [Op]
            public static void deposit(Span<byte> dst, byte a0, byte a1, byte a2)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
            }

            [Op]
            public static void deposit(Span<byte> dst, in byte a0, in byte a1, in byte a2)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
            }

            [Op]
            public static void deposit(Span<byte> dst, byte a0, byte a1, byte a2, byte a3)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
            }


            [Op]
            public static void deposit(Span<byte> dst, byte a0, byte a1, byte a2, byte a3, byte a4)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
            }


            [Op]
            public static void deposit(Span<ushort> dst, ushort a0, ushort a1, ushort a2, ushort a3, ushort a4, ushort a5, ushort a6)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
                seek(dst,5) = a5;
                seek(dst,6) = a6;
            }

            [Op]
            public static void deposit(ushort a0, ushort a1, ushort a2, ushort a3, ushort a4, ushort a5, ushort a6, Span<ushort> dst)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
                seek(dst,5) = a5;
                seek(dst,6) = a6;
            }

            [Op]
            public static void deposit(Span<ulong> dst, ulong a0, ulong a1, ulong a2)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
            }

            [Op]
            public static void deposit(Span<ulong> dst, ulong a0, ulong a1, ulong a2, ulong a3, ulong a4)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
            }

            [Op]
            public static void deposit(Span<ulong> dst, ulong a0, ulong a1, ulong a2, ulong a3, ulong a4, ulong a5, ulong a6)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
                seek(dst,5) = a5;
                seek(dst,6) = a6;
            }

            [Op]
            public static void deposit(Span<ulong> dst, in ulong a0, in ulong a1, in ulong a2, in ulong a3, in ulong a4, in ulong a5, in ulong a6)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
                seek(dst,5) = a5;
                seek(dst,6) = a6;
            }

            [Op]
            public static void deposit(ref ulong dst, in ulong a0, in ulong a1, in ulong a2, in ulong a3, in ulong a4, in ulong a5, in ulong a6)
            {
                seek(dst,0) = a0;
                seek(dst,1) = a1;
                seek(dst,2) = a2;
                seek(dst,3) = a3;
                seek(dst,4) = a4;
                seek(dst,5) = a5;
                seek(dst,6) = a6;
            }

            [Op]
            public static void io(in ulong a0, out ulong b0, in ulong a1, out ulong b1, in ulong a2, out ulong b2, in ulong a3, out ulong b3)
            {
                b0 = a0;
                b1 = a1;
                b2 = a2;
                b3 = a3;
            }
        }
    }
}