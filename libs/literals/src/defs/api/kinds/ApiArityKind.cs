//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NBK = NumericBaseKind;
    using OC = OperationKind;

    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum ApiArityKind : ushort
    {
        /// <summary>
        /// Classifies nothing
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies operations of arity 0
        /// </summary>
        Nullary = OC.Nullary,

        /// <summary>
        /// Classifies operations of arity 1
        /// </summary>
        Unary = OC.Unary,

        /// <summary>
        /// Classifies operations of arity 2
        /// </summary>
        Binary = OC.Binary,

        /// <summary>
        /// Classifies operations of arity 3
        /// </summary>
        Ternary = OC.Ternary,
    }
}