//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using static LogixEngine;
    using static PredicateSpec;
    using static ApiComparisonClass;
    using static NumericLogixHost;

    public class t_comparison_pred : t_typed_logix<t_comparison_pred>
    {
        public void trichotomy_check()
        {
            trichotomy_check<uint>();
        }

        public void eq_pred_check()
        {
            var kind = Eq;
            predicate_check<sbyte>(kind);
            predicate_check<byte>(kind);
            predicate_check<short>(kind);
            predicate_check<ushort>(kind);
            predicate_check<int>(kind);
            predicate_check<uint>(kind);
            predicate_check<long>(kind);
            predicate_check<ulong>(kind);
        }

        public void neq_pred_check()
        {
            var kind = Eq;
            predicate_check<sbyte>(kind);
            predicate_check<byte>(kind);
            predicate_check<short>(kind);
            predicate_check<ushort>(kind);
            predicate_check<int>(kind);
            predicate_check<uint>(kind);
            predicate_check<long>(kind);
            predicate_check<ulong>(kind);
        }

        public void lt_pred_check()
        {
            var kind = Lt;
            predicate_check<sbyte>(kind);
            predicate_check<byte>(kind);
            predicate_check<short>(kind);
            predicate_check<ushort>(kind);
            predicate_check<int>(kind);
            predicate_check<uint>(kind);
            predicate_check<long>(kind);
            predicate_check<ulong>(kind);
        }

        public void lteq_pred_check()
        {
            var kind = LtEq;
            predicate_check<sbyte>(kind);
            predicate_check<byte>(kind);
            predicate_check<short>(kind);
            predicate_check<ushort>(kind);
            predicate_check<int>(kind);
            predicate_check<uint>(kind);
            predicate_check<long>(kind);
            predicate_check<ulong>(kind);
        }

        public void gt_pred_check()
        {
            var kind = Gt;
            predicate_check<sbyte>(kind);
            predicate_check<byte>(kind);
            predicate_check<short>(kind);
            predicate_check<ushort>(kind);
            predicate_check<int>(kind);
            predicate_check<uint>(kind);
            predicate_check<long>(kind);
            predicate_check<ulong>(kind);
        }

        public void gteq_pred_check()
        {
            var kind = GtEq;
            predicate_check<sbyte>(kind);
            predicate_check<byte>(kind);
            predicate_check<short>(kind);
            predicate_check<ushort>(kind);
            predicate_check<int>(kind);
            predicate_check<uint>(kind);
            predicate_check<long>(kind);
            predicate_check<ulong>(kind);
        }

        void trichotomy_check<T>()
            where T : unmanaged
        {
            var va = var_a<T>();
            var vb = var_b<T>();
            var vc = var_c<T>();
            var x = predicate(ApiComparisonClass.Lt,va,vb);
            var y = predicate(ApiComparisonClass.Lt,vb,vc);
            var z = predicate(ApiComparisonClass.Lt,vc,va);
            for(var i=0; i<RepCount; i++)
            {
                var a = va.Set(Random);
                var b = vb.Set(Random);
                var c = vc.Set(Random);

                var ab = gmath.lt(a,b);
                var abx = eval(x);
                Claim.require(ab == abx);

                var bc = gmath.lt(b,c);
                var bcy = eval(y);
                Claim.require(bc == bcy);

                var ca = gmath.lt(c,a);
                var caz = eval(z);
                Claim.require(ca == caz);
            }
        }

        void predicate_check<T>(ApiComparisonClass kind)
            where T : unmanaged
        {
            var va = var_a<T>();
            var vb = var_b<T>();
            var x = predicate(kind,va,vb);
            for(var i=0; i<RepCount; i++)
            {
                var a = va.Set(Random);
                var b = vb.Set(Random);
                var result = eval(x);
                var expect = NumericLogixHost.eval(kind,a,b);
                Claim.eq(expect,result);
            }
        }
    }
}