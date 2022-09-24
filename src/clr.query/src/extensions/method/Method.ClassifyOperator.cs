//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using OC = ApiOperatorKind;

    partial class ClrQuery
    {
        /// <summary>
        /// Classifies a methods that is an operator and has arity between 1 and 3; otherwise, returns None
        /// </summary>
        /// <param name="src">The method to examine</param>
        [Op]
        public static ApiOperatorKind ClassifyOperator(this MethodInfo src)
        {
            if(IsOperator(src))
            {
                return src.ArityValue() switch {
                    1 => OC.UnaryOp,
                    2 => OC.BinaryOp,
                    3 => OC.TernaryOp,
                    _ => OC.None

                };
            }
            return 0;
        }
     }
}