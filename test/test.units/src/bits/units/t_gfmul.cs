//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_gfmul : t_bits<t_gfmul>
    {
        public void gfmul_256()
        {
            for(var i=0; i<RepCount; i++)
            {
                var v1 = Random.BitVector(n8);
                var v2 = Random.BitVector(n8);
                var p1 = Gf256.clmul(v1,v2);
                var p2 = Gf256.clmul((byte)v1, (byte)v2);
                var p4 = Gf256.mul_ref(v1,v2);

                Claim.eq(p1,p2);
                Claim.eq(p1,p4);
            }
        }
        public void gfpoly_format()
        {
            var p1 = GfPoly.Gfp_8_4_3_2_0;
            var p2 = GfPoly16.FromExponents(8,4,3,2,0);
            var p3 = GfPoly16.FromScalar(0b100011101);

            Claim.eq(p3.Degree,(byte)8);
            Claim.eq(p1.Scalar, p2.Scalar);
            ClaimPrimalSeq.eq(p1.Format(),p2.Format());
        }

        public void gfmul_8()
        {
            var expect =  new byte[,]
            {
                {0b001, 0b010, 0b011, 0b100, 0b101, 0b110, 0b111},
                {0b010, 0b100, 0b110, 0b011, 0b001, 0b111, 0b101},
                {0b011, 0b110, 0b101, 0b111, 0b100, 0b001, 0b010},
                {0b100, 0b011, 0b111, 0b110, 0b010, 0b101, 0b001},
                {0b101, 0b001, 0b100, 0b010, 0b111, 0b011, 0b110},
                {0b110, 0b111, 0b001, 0b101, 0b011, 0b010, 0b100},
                {0b111, 0b101, 0b010, 0b001, 0b110, 0b100, 0b011}
            };

            var actual = new byte[7,7];
            Gf8.products(ref actual[0,0]);

            //var actual = Gf8.products();

            for(byte i=0; i<7; i++)
            for(byte j=0; j<7; j++)
                Claim.eq(expect[i,j], actual[i,j]);
        }

        public static string format8x8x3(byte[,] src)
        {
            var dst = text.build();
            var config = BitFormat.limited(3);
            var formatter = BitRender.formatter<byte>(config);
            for(var i=0; i<7; i++)
            {
                for(var j=0; j<7; j++)
                {
                    ref readonly var cell = ref src[i,j];

                    var cellFmt = formatter.Format(cell);

                    dst.Append(cellFmt);

                    if(j != 6)
                        dst.Append(Chars.Pipe);
                }
                dst.AppendLine();
            }
            return dst.ToString();
        }

        public void gfpoly()
        {
            gfpoly_check(GfPoly.Lookup<N3,byte>(), BitStrings.parse("1011"));
            gfpoly_check(GfPoly.Lookup<N8,ushort>(), BitStrings.parse("100011101"));
            gfpoly_check(GfPoly.Lookup<N16,uint>(), BitStrings.parse("10000001111011101"));
            Claim.eq((ushort)0b100011101, GfPoly.Lookup<N8,ushort>().Scalar);
        }

        void gfpoly_check<N,T>(GfPoly<N,T> p, BitString match)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var bs = BitStrings.scalar(p.Scalar).Truncate(p.Degree + 1);
            Claim.eq(bs, match);
        }
    }
}