//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using W = DataWidth;
    using ID = ScalarKind;
    using NBK = NumericBaseKind;

    /// <summary>
    /// Classifies system-defined numeric primitive types
    /// </summary>
    [SymSource(numeric, NBK.Base16), Flags]
    public enum NumericKind : uint
    {
        None = 0,

        /// <summary>
        /// When enabled, indicates a signed integral type
        /// </summary>
        Signed = 1u << 31,

        /// <summary>
        /// When enabled, indicates a floating-point type
        /// </summary>
        Float = 1u << 30,

        /// <summary>
        /// When enabled, indicates an unsigned integral type
        /// </summary>
        Unsigned = 1u << 29,

        /// <summary>
        /// Identifies an unsigned 8-bit integral type
        /// </summary>
        U8 = ID.U8 | W.W8 | Unsigned,

        /// <summary>
        /// Identifies a signed 8-bit integral type
        /// </summary>
        I8 = ID.I8 | W.W8 | Signed,

        /// <summary>
        /// Identifies an unsigned 16-bit integral type
        /// </summary>
        U16 = ID.U16 | W.W16 | Unsigned,

        /// <summary>
        /// Identifies a signed 16-bit integral type
        /// </summary>
        I16 = ID.I16 | W.W16 | Signed,

        /// <summary>
        /// Identifies an unsigned 32-bit integral type
        /// </summary>
        U32 = ID.U32 | W.W32 | Unsigned,

        /// <summary>
        /// Identifies a signed 32-bit integral type
        /// </summary>
        I32 = ID.I32 | W.W32 | Signed,

        /// <summary>
        /// Identifies an unsigned 64-bit integral type
        /// </summary>
        U64 = ID.U64 | W.W64 | Unsigned,

        /// <summary>
        /// Identifies a signed 64-bit integral type
        /// </summary>
        I64 = ID.I64 | W.W64 | Signed,

        /// <summary>
        /// Identifies a 32-bit floating-point type
        /// </summary>
        F32 = ID.F32 | W.W32 | Float,

        /// <summary>
        /// Identifies a 64-bit floating-point type
        /// </summary>
        F64 = ID.F64 | W.W64 | Float,

        /// <summary>
        /// Defines a classification that includes all signed primal integral types and no others
        /// </summary>
        SignedInts = I8 | I16 | I32 | I64,

        /// <summary>
        /// Defines a classification that includes all unsigned primal integral types and no others
        /// </summary>
        UnsignedInts = U8 | U16 | U32 | U64,

        /// <summary>
        /// Defines a classification that includes all primal integral types and no others
        /// </summary>
        Integers = SignedInts | UnsignedInts,

        /// <summary>
        /// Defines a classification that includes all primal floating-point types and no others
        /// </summary>
        Floats = F32 | F64,

        /// <summary>
        /// Defines a classification that includes all kinds
        /// </summary>
        All = Integers | Floats,

        /// <summary>
        /// Defines a classification that includes kinds of width 8
        /// </summary>
        Width8 = U8 | I8,

        /// <summary>
        /// Defines a classification that includes kinds of width 16
        /// </summary>
        Width16 = U16 | I16,

        /// <summary>
        /// Defines a classification that includes kinds of width 32
        /// </summary>
        Width32 = U32 | I32 | F32,

        /// Defines a classification that includes kinds of width 64
        /// </summary>
        Width64 = U64 | I64 | F64
    }
}