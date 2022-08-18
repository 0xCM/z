//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Defines helper methods for working with LINQ expressions
    /// </summary>
    public static class ConditionalActions
    {
        /// <summary>
        /// Tests whether an expression is a nullity operator
        /// </summary>
        /// <param name="x">The expression to examine</param>
        public static bool IsNullityOperator(this Expression x)
            => x.TryGetNullityOperator().Exists;

        /// <summary>
        /// Extracts a nullity operator if detected
        /// </summary>
        /// <param name="x">The source expression</param>
        public static Option<INullityOperator> TryGetNullityOperator(this Expression x)
        {
            var no = Option.none<INullityOperator>();
            var C = (x as BinaryExpression)?.Right as ConstantExpression;
            if (C != null && C.Value == null)
            {
                switch (x.NodeType)
                {
                    case ExpressionType.NotEqual:
                        return StandardOperators.IsNotNull;
                    case ExpressionType.Equal:
                        return StandardOperators.IsNull;
                }
            }
            return no;
        }

        /// <summary>
        /// Extracts a comparison operator if detected
        /// </summary>
        /// <param name="x">The source expression</param>
        public static Option<IComparisonOperator> TryGetComparisonOperator(this Expression x)
        {
            var no = Option.none<IComparisonOperator>();

            if (x.IsNullityOperator())
                return no;

            switch (x.NodeType)
            {
                case ExpressionType.NotEqual:
                    return StandardOperators.NotEqual;
                case ExpressionType.Equal:
                    return StandardOperators.Equal;
                case ExpressionType.GreaterThan:
                    return StandardOperators.GreaterThan;
                case ExpressionType.GreaterThanOrEqual:
                    return StandardOperators.GreaterThanOrEqual;
                case ExpressionType.LessThan:
                    return StandardOperators.LessThan;
                case ExpressionType.LessThanOrEqual:
                    return StandardOperators.LessThanOrEqual;
            }
            return no;
        }

        /// <summary>
        /// Invokes the supplied action if the expression is a conjunction and returns true in this case and otherwise false
        /// </summary>
        /// <param name="x">The source expression</param>
        /// <param name="a">The operation to conditionally invoke</param>
       public static bool OnConjunction<X>(this X x, Action<X> a)
            where X : Expression
        {
            var conjunction = x.Conjunction();
            if (conjunction)
            {
                conjunction.OnSome(a);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Invokes the supplied action if the expression is a comparision operator
        /// </summary>
        /// <param name="x">The source expression</param>
        /// <param name="a">The operation to conditionally invoke</param>
        public static bool OnComparisonOperator(this Expression x, Action<IComparisonOperator> a)
        {
            var C = x.TryGetComparisonOperator();
            if (C)
            {
                C.OnSome(a);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Invokes the supplied action if the expression is a nullity operator and returns true in this case and otherwise false
        /// </summary>
        /// <param name="x">The source expression</param>
        /// <param name="a">The operation to conditionally invoke</param>
        public static bool OnNullityOperator(this Expression x, Action<INullityOperator> a)
        {
            var C = x.TryGetNullityOperator();
            if (C)
            {
                C.OnSome(a);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Invokes the supplied action if the expression is a disjunction and returns true in this case and otherwise false
        /// </summary>
        /// <param name="x">The source expression</param>
        /// <param name="a">The operation to conditionally invoke</param>
        public static bool OnDisjunction<X>(this X x, Action<X> a)
            where X : Expression
        {
            var D = x.Disjunction();
            if (D)
            {
                D.OnSome(a);
                return true;
            }
            else
                return false;
        }
    }
}