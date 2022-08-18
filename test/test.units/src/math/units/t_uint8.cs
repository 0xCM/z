//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CNum;

    public sealed class CNumChecks : UnitTest<CNumChecks>
    {
        static new readonly IPolyrand Random = Rng.wyhash64(PolySeed64.Seed00);

        const uint Reps = Pow2.T16;

        static new ICheckNumeric Claim => NumericClaims.Checker;

        public static void bv8_ops_check()
        {
            for(var i=0; i<Reps; i++)
            {
                var a = Random.Next<byte>();
                var b = Random.Next<byte>();

                uint8_t va = a;
                uint8_t vb = b;

                Claim.eq(math.add(a,b), va + vb);
                Claim.eq(math.sub(a,b), va - vb);
                Claim.eq(math.mul(a,b), va * vb);
                if(b != 0)
                {
                    Claim.eq(math.div(a,b), va / vb);
                    Claim.eq(math.mod(a,b), va % vb);
                }
                Claim.eq(math.negate(a), -va);
                Claim.eq(math.and(a,b), va & vb);
                Claim.eq(math.or(a,b), va | vb);
                Claim.eq(math.xor(a, b), va ^ vb);
                Claim.eq(math.not(a), ~va);
                Claim.eq(math.sll(a,3), va << 3);
                Claim.eq(math.srl(a,3), va >> 3);
            }

            var c = byte.MinValue;
            var d = uint8_t.zero;

            for(var i=0; i<300; i++)
            {
                c++;
                d++;
                Claim.eq(c,d);
            }

            for(var i=0; i<300; i++)
            {
                c--;
                d--;
                Claim.eq(c,d);
            }
        }
    }
}