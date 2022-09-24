//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq.Expressions;

    using static Option;

    partial class ClrQuery
    {
        /// <summary>
        /// Extracts member info from an expression, if possbile; otherwise returns none
        /// </summary>
        /// <param name="x">The expression to examine</param>
        [Op]
        public static Option<MemberInfo> AccessedMember(this Expression src)
        {
            var M = TryCast<MemberExpression>(src).ValueOrDefault();
            if (M != null)
                return M.Member;
            else
                return TryCast<LambdaExpression>(src).Select(y => y.Body.AccessedMember().ValueOrDefault());
        }

        [Op]
        public static Option<MemberInfo> AccessedMember(this BinaryExpression src)
            => src.Left.AccessedMember().ValueOrElse(() => src.Right.AccessedMember().ValueOrDefault());
    }
}