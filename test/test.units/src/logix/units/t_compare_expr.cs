//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using static LogixEngine;

    using CS = Comparisons;

    public class t_compare_expr : t_typed_logix<t_compare_expr>
    {
        public void scalar_lt_check()
        {
            scalar_lt_check<byte>();
            scalar_lt_check<sbyte>();
            scalar_lt_check<short>();
            scalar_lt_check<ushort>();
            scalar_lt_check<int>();
            scalar_lt_check<uint>();
            scalar_lt_check<long>();
            scalar_lt_check<ulong>();
        }

        public void scalar_lteq_check()
        {
            scalar_lteq_check<byte>();
            scalar_lteq_check<sbyte>();
            scalar_lteq_check<short>();
            scalar_lteq_check<ushort>();
            scalar_lteq_check<int>();
            scalar_lteq_check<uint>();
            scalar_lteq_check<long>();
            scalar_lteq_check<ulong>();
        }

        public void scalar_gt_expr_check()
        {
            scalar_gt_check<byte>();
            scalar_gt_check<sbyte>();
            scalar_gt_check<short>();
            scalar_gt_check<ushort>();
            scalar_gt_check<int>();
            scalar_gt_check<uint>();
            scalar_gt_check<long>();
            scalar_gt_check<ulong>();
        }

        public void scalar_gteq_expr_check()
        {
            scalar_gteq_check<byte>();
            scalar_gteq_check<sbyte>();
            scalar_gteq_check<short>();
            scalar_gteq_check<ushort>();
            scalar_gteq_check<int>();
            scalar_gteq_check<uint>();
            scalar_gteq_check<long>();
            scalar_gteq_check<ulong>();
        }

         protected void scalar_lt_check<T>()
            where T : unmanaged
        {
            var va = var_a<T>();
            var vb = var_b<T>();
            var x = CS.lt(va,vb);
            for(var i=0; i<RepCount; i++)
            {
                var a = va.Set(Random);
                var b = vb.Set(Random);
                var result = eval(x).Value;
                var expect = LogixPredicateEval.eval(ApiComparisonClass.Lt,a,b);
                Claim.eq(expect,result);
            }
        }

        protected void scalar_lteq_check<T>()
            where T : unmanaged
        {
            var va = var_a<T>();
            var vb = var_b<T>();
            var x = CS.lteq(va,vb);
            for(var i=0; i<RepCount; i++)
            {
                var a = va.Set(Random);
                var b = vb.Set(Random);
                var result = eval(x).Value;
                var expect = LogixPredicateEval.eval(ApiComparisonClass.LtEq,a,b);
                Claim.eq(expect,result);
            }
        }

        protected void scalar_gt_check<T>()
            where T : unmanaged
        {
            var va = var_a<T>();
            var vb = var_b<T>();
            var x = CS.gt(va,vb);
            for(var i=0; i<RepCount; i++)
            {
                var a = va.Set(Random);
                var b = vb.Set(Random);
                var expect = LogixPredicateEval.eval(ApiComparisonClass.Gt,a,b);
                var actual = eval(x).Value;
                if(gmath.neq(actual,expect))
                    Notify($"{a} > {b}?");
                Claim.eq(expect,actual);
            }
        }

        protected void scalar_gteq_check<T>()
            where T : unmanaged
        {
            var va = var_a<T>();
            var vb = var_b<T>();
            var x = CS.gteq(va,vb);
            for(var i=0; i<RepCount; i++)
            {
                var a = va.Set(Random);
                var b = vb.Set(Random);
                var expect = LogixPredicateEval.eval(ApiComparisonClass.GtEq,a,b);
                var actual = eval(x).Value;
                Claim.eq(expect,actual);
            }
        }
  }
}