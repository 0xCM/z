//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies common validiation invariants
    /// </summary>
    public enum ClaimKind : byte
    {
        None = 0,

        /// <summary>
        /// Asserts that two values are equal
        /// </summary>
        Eq,

        /// <summary>
        /// Asserts that two values are approximately equal
        /// </summary>
        Close,

        /// <summary>
        /// Asserts that two values are not equal
        /// </summary>
        NEq,

        /// <summary>
        /// Asserts that one value is less than another
        /// </summary>
        Lt,

        /// <summary>
        /// Asserts that one value is less than or equal to another
        /// </summary>
        LtEq,

        /// <summary>
        /// Asserts that one value is greater than another
        /// </summary>
        Gt,

        /// <summary>
        /// Asserts that one value is greater than or equal to another
        /// </summary>
        GtEq,

        /// <summary>
        /// Asserts that a predicate evaluates to false
        /// </summary>
        False,

        /// <summary>
        /// Asserts that a predicate evaluates to true
        /// </summary>
        True,

        /// <summary>
        /// Asserts that a value is nonzero
        /// </summary>
        Nonzero,

        /// <summary>
        /// Asserts that a value is contained with a closed interval
        /// </summary>
        Between,

        /// <summary>
        /// Asserts that a value is not in a set
        /// </summary>
        NotIn,

        Invariant,

        /// <summary>
        /// Asserts that a value is nonempty
        /// </summary>
        NonEmpty
    }
}