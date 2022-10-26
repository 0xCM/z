//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = PrimalKind;

    /// <summary>
    /// Defines a <see cref='P'/> subset that corresponds to integers
    /// </summary>
    [SymSource(clr), LiteralAlias(typeof(P))]
    public enum ClrIntegerKind : byte
    {
        None = 0,

        /// <summary>
        /// An alias for <see cref='P.U8'/>
        /// </summary>
        U8 = P.U8,

        /// <summary>
        /// An alias for <see cref='P.U16'/>
        /// </summary>
        U16 = P.U16,

        /// <summary>
        /// An alias for <see cref='P.U32'/>
        /// </summary>
        U32 = P.U32,

        /// <summary>
        /// An alias for <see cref='P.U64'/>
        /// </summary>
        U64 = P.U64,

        /// <summary>
        /// An alias for <see cref='P.I8'/>
        /// </summary>
        I8 = P.I8,

        /// <summary>
        /// An alias for <see cref='P.I16'/>
        /// </summary>
        I16 = P.I16,

        /// <summary>
        /// An alias for <see cref='P.I32'/>
        /// </summary>
        I32 = P.I32,

        /// <summary>
        /// An alias for <see cref='P.I64'/>
        /// </summary>
        I64 = P.I64,

    }
}