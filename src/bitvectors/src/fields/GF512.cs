//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public static class Gf512
    {
        public const int MemberCount = 512;

        static readonly BitVector32 Redux =  GfPoly.Lookup<N9,uint>().Scalar;

        [MethodImpl(Inline)]
        public static BitVector16 mul(BitVector16 a, BitVector16 b)
            => cpu.clmulr(n16, a.State,b.State,Redux.State);

        /// <summary>
        /// Computes the full multiplication table for GF512
        /// </summary>
        /// <param name="dst">The target matrix</param>
        public static ref Matrix256<N512,ushort> products(out Matrix256<N512,ushort> dst)
        {
            dst = Matrix.blockalloc<N512,ushort>();
            for(ushort i=1; i < MemberCount; i++)
            for(ushort j=1; j < MemberCount; j++)
                dst[i, j] = Gf512.mul(i,j);
            return ref dst;
        }

        public static BitVector16 mul_ref(BitVector16 a, BitVector16 b)
        {
            ulong r = Redux;
            var p = 0ul;
            ulong x = a;
            ulong y = b;
            for(var i=0; i<16; i++)
            {
                if((x & (1ul << i)) != 0)
                    p^= (y << i);
            }

            for(var i=30; i>=16; i--)
            {
                if((p & (1ul << i)) != 0)
                    p^= (r <<(i-16));
            }

            return (ushort)p;
        }
    }
}