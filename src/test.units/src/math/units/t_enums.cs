//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class t_enums : t_numeric<t_enums>
    {
        public enum Choices8u : byte
        {
            C0, C1, C2, C3, C4, C5
        }

        public enum Choices32i : int
        {
            C0 = 1,  C1 = 2, C2 = C1*2, C3 = C2*2,
            C4 = C3*2, C5 = C4*2, C6 = C5*2, C7 = C6*2,
            C99 = byte.MaxValue,

        }

        public void check_enum_values()
        {
            var values = ClrEnums.details<Choices32i,int>();
            Claim.eq(Enum.GetValues(typeof(Choices32i)).Length, values.Length);

            for(var i = 0; i<values.Length; i++)
            {
                var ival = values[i].PrimalValue;
                if(ival == byte.MaxValue)
                    break;

                var member = Enums.literal<Choices32i,int>(ival);
                Claim.eq(member, values[i].LiteralValue);

                var expect = (int)Math.Pow(2,i);
                if(expect != ival)
                    Notify($"{values[i]} = {ival} != {expect}");
                Claim.eq(expect, ival);
            }
        }
    }
}