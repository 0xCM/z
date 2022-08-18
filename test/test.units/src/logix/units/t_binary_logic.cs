//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using System.Linq;

    using static BitLogicSpec;
    using static LogixEngine;

    using BLK = BinaryBitLogicKind;
    using BL = BitLogix;

    public class t_binary_logic : t_logix<t_binary_logic>
    {
        protected override int CycleCount => Pow2.T08;

        protected void logic_op_check(BLK kind, Func<bit,bit,bit> rule)
        {
            var check = BinaryBitLogixCheck.create(Wf, kind,rule, (uint)RepCount, Random);
            Claim.yea(check.Run().Result);
        }

        public void and_op_check()
            => logic_op_check(BLK.And, (a,b) => a & b);

        public void and_expr_check()
            => logic_expr_check(BLK.And, BL.and);

        public void nand_op_check()
            => logic_op_check(BLK.Nand, (a,b) => !(a & b));

        public void nand_expr_check()
            => logic_expr_check(BLK.Nand, BL.nand);

        public void or_op_check()
            => logic_op_check(BLK.Or, (a,b) => a | b);

        public void or_expr_check()
            => logic_expr_check(BLK.Or, BL.or);

        public void nor_op_check()
            => logic_op_check(BLK.Nor, (a,b) => !(a | b));

        public void nor_expr_check()
            => logic_expr_check(BLK.Nor, BL.nor);

        public void xor_op_check()
            => logic_op_check(BLK.Xor, (a,b) => a ^ b);

        public void xor_expr_check()
            => logic_expr_check(BLK.Xor, BL.xor);

        public void xnor_op_check()
            => logic_op_check(BLK.Xnor, (a,b) => !(a ^ b));

        public void xnor_expr_check()
            => logic_expr_check(BLK.Xnor, BL.xnor);

        public void t_seqential_op_check()
        {
            var a = lvar(0);
            var b = lvar(1);

            var expr1 = and(a, b);
            var expr2 = or(a, b);
            var expr3 = xor(expr1, expr2);
            var expr4 = nand(expr2, expr3);
            var expr5 = nor(expr3, expr4);
            var expr6 = xnor(expr4, expr5);

            foreach(var seq in bitcombo(n2))
            {
                var s0 = seq[0];
                var s1 = seq[1];

                var e1 = BL.and(s0,s1);
                var e2 = BL.or(s0,s1);
                var e3 = BL.xor(e1,e2);
                var e4 = BL.nand(e2,e3);
                var e5 = BL.nor(e3,e4);
                var e6 = BL.xnor(e4,e5);
                var expect = e6;

                a.Set(s0);
                b.Set(s1);
                var actual = eval(expr6);
                Claim.eq(expect,actual);
            }
        }

        public void t_sop_expr()
        {
            var v1 = lvar(1);
            var v2 = lvar(2);
            var v3 = lvar(3);
            var expr = or(and(v1,v2), and(v2,v3));

            foreach(var seq in bitcombo(n4))
            {
                var s1 = seq[0];
                var s2 = seq[1];
                var s3 = seq[2];
                v1.Set(s1);
                v2.Set(s2);
                v3.Set(s3);

                var actual = eval(expr);
                var expect = (s1 & s2) | (s2 & s3);
                Claim.eq(expect,actual);
            }
        }

        public void t_andnot_expr()
        {
            var v1 = lvar(1);
            var v2 = lvar(2);
            var expr = and(v1,not(v2));

            foreach(var seq in bitcombo(n2))
            {
                var s1 = seq[0];
                var s2 = seq[1];
                v1.Set(s1);
                v2.Set(s2);
                var actual = eval(expr);
                var expect = s1 & ~s2;
                Claim.eq(expect,actual);
            }
        }

        public void t_bitcombo_check()
        {
            Claim.eq(Pow2.T01, bitcombo(n1).Distinct().Count());
            Claim.eq(Pow2.T02, bitcombo(n2).Distinct().Count());
            Claim.eq(Pow2.T03, bitcombo(n3).Distinct().Count());
            Claim.eq(Pow2.T04, bitcombo(n4).Distinct().Count());
            Claim.eq(Pow2.T05, bitcombo(n5).Distinct().Count());
            Claim.eq(Pow2.T06, bitcombo(n6).Distinct().Count());
            Claim.eq(Pow2.T07, bitcombo(n7).Distinct().Count());
            Claim.eq(Pow2.T08, bitcombo(n8).Distinct().Count());
        }

        void bitcombo_emit()
        {
            var width = n8;
            var terms = bitcombo(width).Select(x => x.Terms).SelectMany(x => x).ToSpan();
            var expectations = terms.ToBitString().Pack().AsUInt64();
            var matrix = BitMatrix.alloc<ulong>();

            for(int i=0, j=0; i< terms.Length; i+= 64, j++)
            {
                // BitVector<ulong> actual = BitPack.pack<ulong>(terms.Slice(i));
                // BitVector<ulong> expect = expectations[j];
                // Claim.eq(actual,expect);
                // matrix[j] = actual;

                // Notify(actual.Format(8));
            }
        }

        public void t_bitseq_check()
        {
            for(var sample=0; sample<RepCount; sample++)
            {
                var bs = Random.BitString(2,7);
                var x = bs.ToLogicSeq();
                var y = BitVectors.create(n8,bs);
                for(var i=z8; i<bs.Length; i++)
                {
                    Claim.eq(bs[i], x[i]);
                    Claim.eq(bs[i], y[i]);
                }
            }
        }

        public void logic_op_bench()
        {
            logic_op_bench(true);
            logic_op_bench(false);
        }

        void logic_op_bench(bool lookup, SystemCounter clock = default)
        {
            var opname = $"ops/logical/lookup[{lookup}]";

            var lhsSamples = Random.BitStream32().Take(RepCount).ToArray();
            var rhsSamples = Random.BitStream32().Take(RepCount).ToArray();
            var result = Z0.bit.Off;
            var kinds = bitlogix.BinaryOpKinds;
            var opcount = 0;

            clock.Start();

            if(lookup)
            {
                for(var i=0; i<CycleCount; i++)
                for(var sample=0; sample< RepCount; sample++)
                for(var k=0; k< kinds.Length; k++, opcount++)
                    result = bitlogix.Lookup(kinds[k])(lhsSamples[sample], rhsSamples[sample]);
            }
            else
            {
                for(var i=0; i<CycleCount; i++)
                for(var sample=0; sample< RepCount; sample++)
                for(var k=0; k< kinds.Length; k++, opcount++)
                    result = bitlogix.Evaluate(kinds[k],lhsSamples[sample], rhsSamples[sample]);
            }

            clock.Stop();

            ReportBenchmark(opname, opcount,clock);
        }

        void logic_expr_check(BLK kind, Func<bit,bit,bit> rule)
        {
            var v1 = lvar(1);
            var v2 = lvar(2);
            var expr = binary(kind, v1,v2);

            foreach(var seq in bitcombo(n2))
            {
                var s1 = seq[0];
                var s2 = seq[1];
                v1.Set(s1);
                v2.Set(s2);
                var expect = rule(s1,s2);
                var e1 = eval(expr);
                Claim.eq(expect,e1);
            }
        }
    }
}