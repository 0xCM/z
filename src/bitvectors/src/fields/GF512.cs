//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class Gf512
    {
        public const int MemberCount = 512;

        static readonly BitVector32 Redux =  GfPoly.Lookup<N9,uint>().Scalar;

        [MethodImpl(Inline)]
        public static BitVector16 mul(BitVector16 a, BitVector16 b)
            => vcpu.clmulr(n16, a.State,b.State,Redux.State);

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