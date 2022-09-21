//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bv_seg : t_bits<t_bv_seg>
    {
        public void bvlsbseg_8()
        {
            var width = n8;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.lo(bv,n).ToBitString();
                var expect = bv.ToBitString()[0, n - 1];
                Claim.eq(expect, result);
            }
        }

        public void bvlsbseg_16()
        {
            var width = n16;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.lo(bv,n).ToBitString();
                var expect = bv.ToBitString()[0, n - 1];
                Claim.eq(expect, result);
            }
        }

        public void bvlsbseg_32()
        {
            var width = n32;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.lo(bv,n).ToBitString();
                var expect = bv.ToBitString()[0, n - 1];
                Claim.eq(expect, result);
            }
        }

        public void bvlsbseg_64()
        {
            var width = n64;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.lo(bv,n).ToBitString();
                var expect = bv.ToBitString()[0, n - 1];
                Claim.eq(expect, result);
            }
        }

        public void bvmsbseg_8()
        {
            var width = n8;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.hiseg(bv,n).ToBitString();
                var expect = bv.ToBitString().Reverse()[0, n - 1].Reverse();
                Claim.eq(expect, result);
            }
        }

        public void bvmsbseg_16()
        {
            var width = n16;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.hiseg(bv,n).ToBitString();
                var expect = bv.ToBitString().Reverse()[0, n - 1].Reverse();
                Claim.eq(expect, result);
            }
        }

        public void bvmsbseg_32()
        {
            var width = n32;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.hiseg(bv,n).ToBitString();
                var expect = bv.ToBitString().Reverse()[0, n - 1].Reverse();
                Claim.eq(expect, result);
            }
        }

        public void bvmsbseg_64()
        {
            var width = n64;
            for(var i=0; i< RepCount; i++)
            {
                var bv = Random.BitVector(width);
                var n = Random.Next((byte)1, (byte)bv.Width);
                var result = BitVectors.hiseg(bv,n).ToBitString();
                var expect = bv.ToBitString().Reverse()[0, n - 1].Reverse();
                Claim.eq(expect, result);
            }
        }

    }

}
