//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    /// <summary>
    /// Constants for integer comparison predicates
    /// </summary>
    [SymSource("dsl.intrinsics")]
    public enum _MM_CMPINT_ENUM : byte
    {
        /// <summary>
        /// Equal
        /// </summary>
        _MM_CMPINT_EQ,

        /// <summary>
        /// Less than
        /// </summary>
        _MM_CMPINT_LT,

        /// <summary>
        /// Less than or Equal
        /// </summary>
        _MM_CMPINT_LE,

        _MM_CMPINT_UNUSED,

        /// <summary>
        /// Not Equal
        /// </summary>
        _MM_CMPINT_NE,

        /// <summary>
        /// Not Less than
        /// </summary>
        _MM_CMPINT_NLT,

        /// <summary>
        /// Greater than or Equal
        /// </summary>
        _MM_CMPINT_GE = _MM_CMPINT_NLT,

        /// <summary>
        /// Not Less than or Equal
        /// </summary>
        _MM_CMPINT_NLE,

        /// <summary>
        /// Greater than
        /// </summary>
        _MM_CMPINT_GT = _MM_CMPINT_NLE
    }
}