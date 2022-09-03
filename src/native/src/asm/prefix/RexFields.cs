//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [LiteralProvider]
    public readonly struct RexFields
    {
        public const byte RenderWidth = 12;

        public const byte B_Mask = 0b000_0_0_0_1;

        /// <summary>
        /// Indicates an extension of the ModR/M r/m field, SIB base field, or Opcode reg field
        /// </summary>
        public const byte B = 0;

        public const byte X_Mask = 0b000_0_0_1_0;

        /// <summary>
        /// Indicates an extension of the SIB index field
        /// </summary>
        public const byte X = 1;

        public const byte R_Mask = 0b000_0_1_0_0;

        public const byte R = 2;

        public const byte W_Mask = 0b000_1_0_0_0;

        /// <summary>
        /// Indicates a 64-bit operand size; if not, operand size determined by CS.D
        /// </summary>
        public const byte W = 3;
    }
}