//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using static sys;
    using static BitLogicSpec;

    public class t_logic_identities : t_logix<t_logic_identities>
    {
        protected override int CycleCount
            => Pow2.T14;

        public void check_identities()
        {
            var src = LogicIdentities.All.Array();
            iter(src, expr => Claim.notnull(expr.Vars));
            iter(src, check_exhaustive);
        }

        public void identity_bench()
        {
            if(gmath.odd(Time.now().Ticks))
            {
                evaluator_bench();
            }
            else
            {
                evaluator_bench();
            }
        }

        void check_exhaustive(ComparisonExpr expr)
        {
            var count = expr.VarCount;
            Claim.gteq(count, 2u);

            foreach(var c in bitcombo(count))
            {
                expr.SetVars(c);
                Claim.eq(bit.On, LogixEngine.eval(expr));
                Claim.require(LogixEngine.satisfied(expr, c[0], c[1]));
            }
        }

        void identity_bench(string opname, Func<ComparisonExpr,bit,bit,bit> checker, SystemCounter clock = default)
        {
            var opcount = 0;
            var sat = bit.On;

            clock.Start();
            for(var i=0; i<CycleCount; i++)
            {
                foreach(var expr in LogicIdentities.All)
                {
                    foreach(var c in bitcombo(2))
                    {
                        sat &= checker(expr, c[0], c[1]);
                        opcount++;
                    }
                }
            }
            clock.Stop();
            Context.ReportBenchmark(opname, opcount,clock);
            Claim.require(sat);
        }

        void evaluator_bench()
            => identity_bench("identity/evaluator", LogixEngine.satisfied);
    }
}