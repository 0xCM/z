//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bitparser : t_bits<t_bitparser>
    {
        public void t_bitparser_01()
        {
            var input = "0110";
            BitParser.parse(text.slice(input,0,1), 1, out byte b0);
            Claim.eq(bit.Off, (bit)b0);
            BitParser.parse(text.slice(input,1,1), 1, out byte b1);
            Claim.eq(bit.On, (bit)b1);
            BitParser.parse(text.slice(input,2,1), 1, out byte b2);
            Claim.eq(bit.On, (bit)b2);
            BitParser.parse(text.slice(input,3,1), 1, out byte b3);
            Claim.eq(bit.Off, (bit)b3);
        }

        public void t_bitparser_true_false()
        {
            var inputA = "true";
            BitParser.semantic(inputA, out var b0);
            Claim.eq(bit.On, b0);

            var inputB = "false";
            BitParser.semantic(inputB, out var b1);
            Claim.eq(bit.Off, b1);
        }
    }
}