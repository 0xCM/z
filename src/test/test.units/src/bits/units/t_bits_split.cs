//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class t_bits_split : t_bits<t_bits_split>
    {
        public void split_16x8()
        {
            var src = Random.Span<ushort>(RepCount);
            foreach(var x in src)
            {
                bits.split(x,out var x0, out var x1);
                var y = bits.join(x0, x1);
                Claim.eq(x,y);
                Claim.eq(x, BitConverter.ToUInt16(new byte[]{x0, x1}));
            }
        }

        public void split_32x8()
        {
            var src = Random.Span<uint>(RepCount);
            foreach(var x in src)
            {
                bits.split(x, out var x0, out var x1, out var x2, out var x3);
                var y = bits.join(x0, x1, x2, x3);
                Claim.eq(x,y);
                Claim.eq(x, BitConverter.ToUInt32(new byte[]{x0, x1, x2, x3}));
            }
        }

        public void split_64x8()
        {
            var src = Random.Span<ulong>(Pow2.T11);
            foreach(var x in src)
            {
                bits.split(x, out var x0, out var x1, out var x2, out var x3, out var x4, out var x5, out var x6, out var x7);
                var y = bits.join(x0, x1, x2, x3, x4, x5, x6, x7);
                Claim.eq(x,y);
                Claim.eq(x, BitConverter.ToUInt64(new byte[]{x0, x1, x2, x3, x4, x5, x6, x7}));

                for(var i=0; i<8; i++)
                {
                    var dst = (byte)0;
                    var pos = (byte)(Pow2.pow(i) - 1);
                    BitRefs.pack(x0, x1, x2, x3, x4, x5, x6, x7, pos, ref dst);

                    byte j = 0;
                    Claim.require(gbits.bitmatch(dst, j++, x0, pos));
                    Claim.require(gbits.bitmatch(dst, j++, x1, pos));
                    Claim.require(gbits.bitmatch(dst, j++, x2, pos));
                    Claim.require(gbits.bitmatch(dst, j++, x3, pos));
                    Claim.require(gbits.bitmatch(dst, j++, x4, pos));
                    Claim.require(gbits.bitmatch(dst, j++, x5, pos));
                    Claim.require(gbits.bitmatch(dst, j++, x6, pos));
                    Claim.require(gbits.bitmatch(dst, j++, x7, pos));
                }
            }
        }

        public void pack_split_16()
        {
            var len = Pow2.T08;
            var lhs = Random.Array<byte>(len);
            var rhs = Random.Array<byte>(len);
            for(var i=0; i<len; i++)
            {
                var dst = bits.join(lhs[i], rhs[i]);
                bits.split(dst,out var x0, out var x1);

                Claim.eq(x0, lhs[i]);
                Claim.eq(x1, rhs[i]);
            }
        }
    }
}