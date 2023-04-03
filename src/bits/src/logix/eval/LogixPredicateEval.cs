//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LogicSig;

    using BCK = ApiComparisonClass;

    [ApiHost]
    public readonly struct LogixPredicateEval
    {
        const NumericKind Closure = UInt64k;

        [Op, NumericClosures(Closure)]
        public static T eval<T>(ApiComparisonClass kind, T a, T b)
            where T : unmanaged
        {
            switch(kind)
            {
                case BCK.Eq: return NumericLogixOps.equals(a,b);
                case BCK.Neq: return NumericLogixOps.neq(a,b);
                case BCK.Lt: return NumericLogixOps.lt(a,b);
                case BCK.LtEq: return NumericLogixOps.lteq(a,b);
                case BCK.Gt: return NumericLogixOps.gt(a,b);
                case BCK.GtEq: return NumericLogixOps.gteq(a,b);
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        [Op, NumericClosures(Closure)]
        public static BinaryOp<T> lookup<T>(BCK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BCK.Eq: return NumericLogixOps.equals;
                case BCK.Neq: return NumericLogixOps.neq;
                case BCK.Lt: return NumericLogixOps.lt;
                case BCK.LtEq: return NumericLogixOps.lteq;
                case BCK.Gt: return NumericLogixOps.gt;
                case BCK.GtEq: return NumericLogixOps.gteq;
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }
    }
}