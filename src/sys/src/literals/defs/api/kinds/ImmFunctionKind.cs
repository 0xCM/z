//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    using p = Pow2x8;

    /// <summary>
    /// Classifies operations according to their immediate needs
    /// </summary>
    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum ImmFunctionKind : byte
    {
        /// <summary>
        /// The empty class
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies operations that accept one or more immediate values
        /// </summary>
        Imm8 = p.P2ᐞ00,

        /// <summary>
        /// Classifies operations that accept immediate values in the first parameter
        /// </summary>
        ImmSlot0 = p.P2ᐞ01,

        /// <summary>
        /// Classifies operations that accept immediate values in the second parameter
        /// </summary>
        ImmSlot1 = p.P2ᐞ02,

        /// <summary>
        /// Classifies operations that accept immediate values in the third parameter
        /// </summary>
        ImmSlot2 = p.P2ᐞ03,

        /// <summary>
        /// Classifies operations that accept immediate values in the fourth parameter
        /// </summary>
        ImmSlot3 = p.P2ᐞ04,

        /// <summary>
        /// Classifies operations that accept immediate values in the fifth parameter
        /// </summary>
        ImmSlot4 = p.P2ᐞ05,

        /// <summary>
        /// Classifies operations that immediate one immediate value
        /// </summary>
        ImmCount1 = p.P2ᐞ06,

        /// <summary>
        /// Classifies operations that immediate two immediate values
        /// </summary>
        ImmCount2 = p.P2ᐞ07,

        /// <summary>
        /// F:A -> byte -> A
        /// </summary>
        UnaryImm8 = Imm8 | ImmCount1 | ImmSlot1,

        /// <summary>
        /// F:A -> A -> byte -> A
        /// </summary>
        BinaryImm8 = Imm8 | ImmCount1 | ImmSlot2,

        /// <summary>
        /// F:A -> A -> A -> byte -> A
        /// </summary>
        TernaryImm8 = Imm8 | ImmCount1 | ImmSlot3,

        /// <summary>
        /// F:A -> byte -> byte -> A
        /// </summary>
        UnaryImm8x2 = Imm8 | ImmCount2 | ImmSlot1 | ImmSlot2,

        /// <summary>
        /// F:A -> A -> byte -> byte -> A
        /// </summary>
        BinaryImm8x2 = Imm8 | ImmCount2 | ImmSlot2 | ImmSlot3,

        /// <summary>
        /// F:A -> A -> A -> byte -> byte -> A
        /// </summary>
        TernaryImm8x2 = Imm8 | ImmCount2 | ImmSlot3 | ImmSlot4
    }
}