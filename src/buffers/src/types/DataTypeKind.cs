//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataWidth(5)]
    public enum DataTypeKind : byte
    {
        None,

        Primitive,

        Numeric,

        Literal,

        /// <summary>
        /// Classifies a named literal
        /// </summary>
        TypedLiteral,

        Operator,

        Expression,

        BitLiteral,

        IntLiteral,

        HexLiteral,
    }
}