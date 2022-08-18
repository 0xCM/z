//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = PrimalKind;

    /// <summary>
    /// Restricts the numeric kind classifier to reflect the numeric kinds
    /// that an Enum type may refine
    /// </summary>
    [SymSource(clr), LiteralAlias(typeof(P))]
    public enum ClrEnumKind : byte
    {
        None = 0,

        /// <summary>
        /// An alias for <see cref='P.U8'/>
        /// </summary>
        [Symbol("u8", "Specifies an unsigned 8-bit refinement")]
        U8 = P.U8,

        /// <summary>
        /// An alias for <see cref='P.U16'/>
        /// </summary>
        [Symbol("u16", "Specifies an unsigned 16-bit refinement")]
        U16 = P.U16,

        /// <summary>
        /// An alias for <see cref='P.U32'/>
        /// </summary>
        [Symbol("u32", "Specifies an unsigned 32-bit refinement")]
        U32 = P.U32,

        /// <summary>
        /// An alias for <see cref='P.U64'/>
        /// </summary>
        [Symbol("u64", "Specifies an unsigned 64-bit refinement")]
        U64 = P.U64,

        /// <summary>
        /// An alias for <see cref='P.I8'/>
        /// </summary>
        [Symbol("i8", "Specifies a signed 8-bit refinement")]
        I8 = P.I8,

        /// <summary>
        /// An alias for <see cref='P.I16'/>
        /// </summary>
        [Symbol("i16", "Specifies a signed 16-bit refinement")]
        I16 = P.I16,

        /// <summary>
        /// An alias for <see cref='P.I32'/>
        /// </summary>
        [Symbol("i32", "Specifies a signed 32-bit refinement")]
        I32 = P.I32,

        /// <summary>
        /// An alias for <see cref='P.I64'/>
        /// </summary>
        [Symbol("i64", "Specifies a signed 64-bit refinement")]
        I64 = P.I64,
    }
}