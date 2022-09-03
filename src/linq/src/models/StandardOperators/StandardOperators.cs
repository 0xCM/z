//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;

    using Z0;
    using static Z0.LinqXPress;
    using static Z0.LinqXFunc;

    public class StandardOperators
    {
        public static NotNullOperator IsNotNull
            => new NotNullOperator();

        public static IsNullOperator IsNull
            => new IsNullOperator();

        public static FalseOperator False
            => new FalseOperator();

        public static TrueOperator True
            => new TrueOperator();

        public static EqualOperator Equal
            => new EqualOperator();

        public static NotEqualOperator NotEqual
            => new NotEqualOperator();

        public static GreaterThanOperator GreaterThan
            => new GreaterThanOperator();

        public static LessThanOperator LessThan
            => new LessThanOperator();

        public static GreaterThanOrEqualOperator GreaterThanOrEqual => new GreaterThanOrEqualOperator();

        public static LessThanOrEqualOperator LessThanOrEqual => new LessThanOrEqualOperator();

        public static AndOperator And => new AndOperator();

        public static OrOperator Or => new OrOperator();
    }

    public sealed class GreaterThanOperator : ComparisonOperator<GreaterThanOperator>
    {
        internal GreaterThanOperator()
            : base("gt", ">")
        {

        }
    }

    public sealed class LessThanOperator : ComparisonOperator<LessThanOperator>
    {
        internal LessThanOperator()
            : base("lt", "<")
        {

        }
    }

    public sealed class GreaterThanOrEqualOperator : ComparisonOperator<GreaterThanOrEqualOperator>
    {
        internal GreaterThanOrEqualOperator()
            : base("gteq", ">=")
        {

        }
    }

    public sealed class LessThanOrEqualOperator : ComparisonOperator<LessThanOrEqualOperator>
    {
        internal LessThanOrEqualOperator()
            : base("lteq", "<=")
        {

        }
    }
}
