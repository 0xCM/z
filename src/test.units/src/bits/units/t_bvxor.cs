//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bvxor : t_bits<t_bvxor>
    {
        public void bvxor_n13x8u()
        {
            var x0 = Random.BitBlock<N13,byte>();
            var y0 = Random.BitBlock<N13,byte>();
            var z0 = x0 ^ y0;
            var x1 = x0.ToBitVector(n16);
            var y1 = y0.ToBitVector(n16);
            var z1 = x1 ^ y1;
            Claim.eq(z0.ToBitVector(n16),z1);
        }

        public void bvxor_128()
        {
            for(var i=0; i< RepCount; i++)
            {
                var x = Random.BitVector(n128);
                var y = Random.BitVector(n128);
                var z = x ^ y;

                var xbs = BitVectors.bitstring(x);
                var ybs = BitVectors.bitstring(y);
                var zbs = xbs ^ ybs;

                Claim.eq(zbs, BitVectors.bitstring(z));
            }
        }

        public void bvxor_w2x8()
            => bvxor_wcheck<byte>(2);

        public void bvxor_w3x8()
            => bvxor_wcheck<byte>(3);

        public void bvxor_w4x8()
            => bvxor_wcheck<byte>(4);

        public void bvxor_w5x8()
            => bvxor_wcheck<byte>(5);

        public void bvxor_w6x8()
            => bvxor_wcheck<byte>(6);

        public void bvxor_w7x8()
            => bvxor_wcheck<byte>(7);

        public void bvxor_w8x8()
            => bvxor_wcheck<byte>(8);

        public void bvxor_w2x16()
            => bvxor_wcheck<ushort>(2);

        public void bvxor_w3x16()
            => bvxor_wcheck<ushort>(3);

        public void bvxor_w4x16()
            => bvxor_wcheck<ushort>(4);

        public void bvxor_w5x16()
            => bvxor_wcheck<ushort>(5);

        public void bvxor_w6x16()
            => bvxor_wcheck<ushort>(6);

        public void bvxor_w7x16()
            => bvxor_wcheck<ushort>(7);

        public void bvxor_w8x16()
            => bvxor_wcheck<ushort>(8);

        public void bvxor_w9x16()
            => bvxor_wcheck<ushort>(9);

        public void bvxor_w10x16()
            => bvxor_wcheck<ushort>(10);

        public void bvxor_w11x16()
            => bvxor_wcheck<ushort>(11);

        public void bvxor_w12x16()
            => bvxor_wcheck<ushort>(12);

        public void bvxor_w13x16()
            => bvxor_wcheck<ushort>(13);

        public void bvxor_w14x16()
            => bvxor_wcheck<ushort>(14);

        public void bvxor_w15x16()
            => bvxor_wcheck<ushort>(15);

        public void bvxor_w16x16()
            => bvxor_wcheck<ushort>(16);

         public void bvxor_w2x32()
            => bvxor_wcheck<ulong>(2);

        public void bvxor_w3x32()
            => bvxor_wcheck<ulong>(3);

        public void bvxor_w4x32()
            => bvxor_wcheck<ulong>(4);

        public void bvxor_w5x32()
            => bvxor_wcheck<ulong>(5);

        public void bvxor_w6x32()
            => bvxor_wcheck<ulong>(6);

        public void bvxor_w7x32()
            => bvxor_wcheck<ulong>(7);

        public void bvxor_w8x32()
            => bvxor_wcheck<uint>(8);

        public void bvxor_w9x32()
            => bvxor_wcheck<uint>(9);

        public void bvxor_w10x32()
            => bvxor_wcheck<uint>(10);

        public void bvxor_w11x32()
            => bvxor_wcheck<uint>(11);

        public void bvxor_w12x32()
            => bvxor_wcheck<uint>(12);

        public void bvxor_w13x32()
            => bvxor_wcheck<uint>(13);

        public void bvxor_w14x32()
            => bvxor_wcheck<uint>(14);

        public void bvxor_w15x32()
            => bvxor_wcheck<uint>(15);

        public void bvxor_w16x32()
            => bvxor_wcheck<uint>(16);

        public void bvxor_w2x64()
            => bvxor_wcheck<ulong>(2);

        public void bvxor_w3x64()
            => bvxor_wcheck<ulong>(3);

        public void bvxor_w4x64()
            => bvxor_wcheck<ulong>(4);

        public void bvxor_w5x64()
            => bvxor_wcheck<ulong>(5);

        public void bvxor_w6x64()
            => bvxor_wcheck<ulong>(6);

        public void bvxor_w7x64()
            => bvxor_wcheck<ulong>(7);

        public void bvxor_w8x64()
            => bvxor_wcheck<ulong>(8);

        public void bvxor_w9x64()
            => bvxor_wcheck<ulong>(9);

        public void bvxor_w10x64()
            => bvxor_wcheck<ulong>(10);

        public void bvxor_w11x64()
            => bvxor_wcheck<ulong>(11);

        public void bvxor_w12x64()
            => bvxor_wcheck<ulong>(12);

        public void bvxor_w13x64()
            => bvxor_wcheck<ulong>(13);

        public void bvxor_w14x64()
            => bvxor_wcheck<ulong>(14);

        public void bvxor_w15x64()
            => bvxor_wcheck<ulong>(15);

        public void bvxor_w16x64()
            => bvxor_wcheck<ulong>(16);

        public void bvxor_w17x64()
            => bvxor_wcheck<ulong>(17);

        public void bvxor_w18x64()
            => bvxor_wcheck<ulong>(18);

        public void bvxor_w19x64()
            => bvxor_wcheck<ulong>(19);

        public void bvxor_w20x64()
            => bvxor_wcheck<ulong>(20);

        public void bvxor_w21x64()
            => bvxor_wcheck<ulong>(21);

        public void bvxor_w22x64()
            => bvxor_wcheck<ulong>(22);

        public void bvxor_w23x64()
            => bvxor_wcheck<ulong>(23);

        public void bvxor_w24x64()
            => bvxor_wcheck<ulong>(24);

        public void bvxor_w25x64()
            => bvxor_wcheck<ulong>(25);

        public void bvxor_w26x64()
            => bvxor_wcheck<ulong>(26);

        public void bvxor_w27x64()
            => bvxor_wcheck<ulong>(27);

        public void bvxor_w28x64()
            => bvxor_wcheck<ulong>(28);

        public void bvxor_w29x64()
            => bvxor_wcheck<ulong>(29);

        public void bvxor_w30x64()
            => bvxor_wcheck<ulong>(30);

        public void bvxor_w31x64()
            => bvxor_wcheck<ulong>(31);

        public void bvxor_w32x64()
            => bvxor_wcheck<ulong>(32);

        void bvxor_wcheck<T>(int width)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.ScalarBits<T>(width);
                ClaimNumeric.lteq(ScalarBits.effwidth(x), width);

                var y = Random.ScalarBits<T>(width);
                ClaimNumeric.lteq(ScalarBits.effwidth(y),width);

                var z = x ^ y;
                ClaimNumeric.eq(gmath.xor(x.State, y.State), z.State);

                var xbs = x.ToBitString().Truncate(width);
                Claim.eq(width, xbs.Length);

                var ybs = y.ToBitString().Truncate(width);
                ClaimNumeric.eq(width, ybs.Length);

                var zbs = xbs.Xor(ybs);

                Claim.eq(zbs, z.ToBitString().Truncate(width));
            }
        }
    }
}