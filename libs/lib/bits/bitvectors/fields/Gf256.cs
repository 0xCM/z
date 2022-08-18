//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public static class Gf256
    {
        public const int MemberCount = 256;

        static readonly ushort Redux = GfPoly.Lookup<N8,ushort>().Scalar;

        /// <summary>
        /// Computes the GF(256) product reduced by the canonical polynomial
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline)]
        public static byte clmul(byte a, byte b)
            => cpu.clmulr(n8, a, b, Redux);

        /// <summary>
        /// Fills caller-allocated memory with a GF(256) multiplication table
        /// </summary>
        /// <param name="min">The minimum operand value</param>
        /// <param name="max">The maximum operand value</param>
        public static void products(byte min, byte max, ref byte dst)
        {
            var width = max - min + 1;
            var cells = width*width;
            var index = 0;
            for(byte i=min; i<= max; i++)
            for(byte j=min; j<= max; j++)
                Unsafe.Add(ref dst,index++) = clmul(i,j);
        }

        /// <summary>
        /// Creates an N^2 multiplication table for the values [1...N]
        /// </summary>
        /// <typeparam name="N">The table order</typeparam>
        public static Matrix256<N,byte> products<N>(N n = default)
            where N : unmanaged, ITypeNat
        {
            var dst = Matrix.blockalloc<N,byte>();
            products(1, (byte)n.NatValue, ref dst.Unblocked[0]);
            return dst;
        }

        /// <summary>
        /// Computes the full multiplication table for GF(256) modulo the canonical polynomial
        /// </summary>
        /// <param name="dst">The target matrix</param>
        public static ref Matrix256<N256,byte> products(out Matrix256<N256,byte> dst)
        {
            dst = Matrix.blockalloc<N256,byte>();
            for(uint i=1; i < MemberCount; i++)
            for(uint j=1; j < MemberCount; j++)
                dst[i, j] = clmul((byte)i,(byte)j);
            return ref dst;
        }

        /// <summary>
        /// The reference (slow) implementation of GF(256) multiplication reduced
        /// via the canonical polynomial
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        public static byte mul_ref(byte a, byte b)
        {
            ulong r = Redux;
            var p = 0ul;
            ulong x = a;
            ulong y = b;
            for(var i=0; i<8; i++)
            {
                if((x & (1ul << i)) != 0)
                    p^= (y << i);
            }

            for(var i=14; i>=8; i--)
            {
                if((p & (1ul << i)) != 0)
                    p^= (r <<(i-8));
            }
            return (byte)p;
        }
    }
}