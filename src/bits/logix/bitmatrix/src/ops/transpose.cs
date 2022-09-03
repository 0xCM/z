//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;
    using static BitMaskLiterals;

    partial class BitMatrix
    {
        [Op]
        public static BitMatrix<N16,N8,uint> transpose(in BitMatrix<N8,N16,uint> A)
        {
            var vec = gcpu.vload(n128,A.Bytes);
            cpu.vstore(cpu.vshuf16x8(vec, Tr8x16Mask), ref first(A.Bytes));
            return BitMatrix.load<N16,N8,uint>(A.Content);
        }

        /// <summary>
        /// Transposes a copy of the matrix
        /// </summary>
        public static BitMatrix4 transpose(in BitMatrix4 A)
        {
            var B = A.Replicate();
            for(var i=0; i<BitMatrix4.N; i++)
                B[i] = col(A,i);

            return B;
        }

        [MethodImpl(Inline)]
        public static ref BitMatrix8 transpose_v1(in BitMatrix8 A, ref BitMatrix8 Z)
        {
            var x = cpu.vscalar(n128,(ulong)A);
            for(var i=7; i>= 0; i--)
            {
                Z[i] = (byte)cpu.vmovemask(cpu.v8u(x));
                x = cpu.vsll(x,1);
            }
            return ref Z;
        }

        [MethodImpl(Inline)]
        public static BitMatrix8 transpose_v2(in BitMatrix8 A)
        {
            var n = n8;
            var src = (ulong)A;
            var data = 0ul;
            for(var i=0; i<8; i++)
            {
                data |= (bits.gather(src, Lsb64x8x1) << i*8);
                src >>= 1;
            }
            return (BitMatrix8)data;
        }

        [MethodImpl(Inline)]
        public static void transpose_v2(in BitMatrix8 A, ref BitMatrix8 Z)
        {
            var n = n8;
            var src = (ulong)A;
            var data = 0ul;
            for(var i=0; i<8; i++)
            {
                data |= (bits.gather(src, Lsb64x8x1) << i*8);
                src >>= 1;
            }

            uint64(ref Z.Head) = data;
        }

        [MethodImpl(Inline)]
        public static BitMatrix8 transpose_v3(in BitMatrix8 A)
            => BitMatrix.primal(n8,
                  ((ulong)A.Col(0) << 0*8)
                | ((ulong)A.Col(1) << 1*8)
                | ((ulong)A.Col(2) << 2*8)
                | ((ulong)A.Col(3) << 3*8)
                | ((ulong)A.Col(4) << 4*8)
                | ((ulong)A.Col(5) << 5*8)
                | ((ulong)A.Col(6) << 6*8)
                | ((ulong)A.Col(7) << 7*8)
                );

        [MethodImpl(Inline)]
        public static void transpose_v3(in BitMatrix8 A, ref BitMatrix8 Z)
        {
            const int width = 8;
            var data = 0ul;
            for(var i=0; i<width; i++)
                data |= ((ulong)A.Col(i) << i*width);
            uint64(ref Z.Head) = data;
        }

        /// <summary>
        /// Transposes an 8x8 bitmatrix
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Z"></param>
        /// <remarks>Code adapted from Hacker's Delight</remarks>
        [MethodImpl(Inline)]
        public static void transpose_v4(in BitMatrix8 A, ref BitMatrix8 Z)
        {
            var data = (ulong)A;
            var t = (data ^ (data >> 7)) & 0x00AA00AA00AA00AAul;
            data = data ^ t ^ (t << 7);
            t = (data ^ (data >> 14)) & 0x0000CCCC0000CCCCul;
            data = data ^ t ^ (t << 14);
            t = (data ^ (data >> 28)) & 0x00000000F0F0F0F0ul;
            data = data ^ t ^ (t << 28);
            uint64(ref Z.Head) = data;
        }

        public static BitMatrix16 transpose(in BitMatrix16 A)
        {
            var dst = A.Replicate();
            for(var i=0; i < BitMatrix16.N; i++)
                dst[i] = A.Col(i);
            return dst;
        }

        public static BitMatrix32 transpose(in BitMatrix32 A)
        {
            var dst = A.Replicate();
            for(var i=0; i<A.Order; i++)
                dst[i] = col(A,i);
            return dst;
        }

        static Vector128<byte> Tr8x16Mask
        {
            [MethodImpl(Inline)]
            get => cpu.vload(n128, core.first(Tr8x16MaskBytes));
        }

        /// <summary>
        ///  When used as a mask for _mm_shuffle_epi8, transposes a 8x16 bitmatrix
        /// </summary>
        static ReadOnlySpan<byte> Tr8x16MaskBytes => new byte[]
        {
            0, 4, 8, 12,
            1, 5, 9, 13,
            2, 6, 10, 14,
            3, 7, 11, 15
        };
    }
}