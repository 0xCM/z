//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Id = ApiClassKind;

    /// <summary>
    /// Identifies comparison (predicate) kinds
    /// </summary>
    [ApiClass, SymSource("api.classes")]
    public enum ApiComparisonClass : ushort
    {
        /// <summary>
        /// The empty identity
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies a comparison operator that returns true iff its operands are equal
        /// </summary>
        [Symbol("eq")]
        Eq = Id.Eq,

        [Symbol("eqz")]
        Eqz = Id.Eqz,

        /// <summary>
        /// Classifies a comparison operator that returns true if the left operand is strictly smaller than the left operand
        /// </summary>
        [Symbol("lt")]
        Lt = Id.Lt,

        [Symbol("ltz")]
        Ltz = Id.Ltz,

        /// <summary>
        /// Classifies a comparison operator that returns true if the left operand is smaller than or equal to the left operand
        /// </summary>
        [Symbol("lteq")]
        LtEq = Id.LtEq,

        /// <summary>
        /// Classifies a comparison operator that returns true if the left operand is strictly greater than the left operand
        /// </summary>
        [Symbol("gt")]
        Gt  = Id.Gt,

        [Symbol("gtz")]
        Gtz = Id.Gtz,

        /// <summary>
        /// Classifies a comparison operator that returns true if the left operand is greater than or equal to the left operand
        /// </summary>
        [Symbol("gteq")]
        GtEq = Id.GtEq,

        /// <summary>
        /// Classifies a comparison operator that returns true iff its operands are not equal
        /// </summary>
        [Symbol("neq")]
        Neq = Id.Neq,

        Divides  = Id.Divides,

        Between = Id.Between,

        Within = Id.Within,

        Negative = Id.Negative,

        Positive = Id.Positive,

        Nonz = Id.Nonz,

        EqB = Id.EqB,

        NeqB = Id.NeqB,

        LtB = Id.LtB,

        LtEqB = Id.LtEqB,

        GtB = Id.GtB,

        GtEqB = Id.GtEqB,
    }
}