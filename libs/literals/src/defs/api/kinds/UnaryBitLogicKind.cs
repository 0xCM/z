//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies unary logic operators
    /// </summary>
    [SymSource(api_kinds)]
    public enum UnaryBitLogicKind : byte
    {
        None = 0,

        /// <summary>
        /// The unary operator that always returns false
        /// </summary>
        False = 0,

        /// <summary>
        /// Logical NOT
        /// </summary>
        Not = 1,

        /// <summary>
        /// The identity operator
        /// </summary>
        Identity = 2,

        /// <summary>
        /// The unary operator that always returns true
        /// </summary>
        True = 3,
    }
}