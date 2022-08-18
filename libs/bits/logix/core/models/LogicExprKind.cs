//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum _ExprKind : byte
    {
        /// <summary>
        /// Classifies boolean bariables
        /// </summary>
        Variable = 1,

        /// <summary>
        /// Classifies a boolean expression that depends on one or more variables
        /// </summary>
        Varied = 2,

        /// <summary>
        /// Classifies a boolean literal expression
        /// </summary>
        Literal = 3,

        /// <summary>
        /// Classifies a boolean comparison expression
        /// </summary>
        Comparison = 4,

        /// <summary>
        /// Classifies a boolean unary operator
        /// </summary>
        UnaryOperator = 5,

        /// <summary>
        /// Classifies a boolean binary operator
        /// </summary>
        BinaryOperator = 6,

        /// <summary>
        /// Classifies a boolean ternary operator
        /// </summary>
        TernaryOperator = 7,
    }
}