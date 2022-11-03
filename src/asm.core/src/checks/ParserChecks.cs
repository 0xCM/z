//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ParserChecks : Checker<ParserChecks>
    {
        public Outcome CheckBitParser()
        {
            var count = 0;
            var a0 = "0b10111";
            var a1 = (byte)0b10111;
            Span<bit> a2 = array<bit>(1,1,1,0,1);
            count = BitParser.parse(a0, out Span<bit> a3);
            if(count < 0)
                return false;

            Outcome result = a3.Length == a2.Length;
            if(result.Fail)
                return (false, string.Format("Unexpected length: {0} != {1}", a3.Length, a2.Length));

            for(var i=0; i<a3.Length; i++)
            {
                result = skip(a2, i) == skip(a3,i);
                if(result.Fail)
                    break;
            }

            if(result.Fail)
                return (false, string.Format("Parsed bitstring value incorrect: {0} != {1}", a2.FormatPacked(), a3.FormatPacked()));

            var a4 = BitPack.scalar<byte>(a3);
            result = (a4 == a1);
            if(result.Fail)
                return (false, string.Format("Incorrect scalar extracted: {0} != {1}", a4, a1));


            return result;
        }
    }
}