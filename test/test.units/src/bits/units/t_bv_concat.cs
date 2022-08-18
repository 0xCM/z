//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bvconcat : t_bits<t_bvconcat>
    {
        public void bv_inc_8()
        {
            var bv = BitVector8.Zero;
            var counter = 0;
            do
                Claim.eq(counter++, (byte)bv);
            while(++bv);

            Claim.eq(counter, Pow2.T08);
        }

        public void bv_concat_8()
        {
            var head = BitVectors.create(n8,0b10100);
            var tail = BitVectors.create(n8,0b111);
            var whole = head.Concat(tail);
            Claim.eq(head, whole.Hi);
            Claim.eq(tail, whole.Lo);
            var bsWhole = whole.ToBitString();
            var bsHead = head.ToBitString();
            var bsTail = tail.ToBitString();
            Claim.eq(bsWhole, bsHead + bsTail);
        }
    }
}