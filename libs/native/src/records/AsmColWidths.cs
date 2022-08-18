//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct AsmColWidths
    {
        public const byte Seq = 8;

        public const byte DocSeq = 8;

        public const byte OriginId = 12;

        public const byte OriginName = 32;

        public const byte EncodingId = 16;

        public const byte InstructionId = 30;

        public const byte EncodedHex = 48;

        public const byte EncodedBits = 128;

        public const byte AsmExpr = 72;

        public const byte InstForm = 62;

        public const byte Mnemonic = 18;

        public const byte AsmSyntax = 120;

        public const byte IP = 12;

        public const byte Size = 5;

        public const byte BlockName = 32;

        public const byte BlockNumber = 12;

        public const byte BlockAddress = 12;

        public const byte BlockSize = 12;

        public const byte OffsetAddress = 12;

        public const byte Hex8 = 8;

        public const byte RexPrefx = 5;

        public const byte VexPrefix = 12;

        public const byte EvexPrefix = 12;

        public const byte ModRm = 5;

        public const byte Sib = 5;

        public const byte Disp = 12;

        public const byte Imm = 12;

        public const byte EASZ = 5;

        public const byte EOSZ = 5;

        public const byte SymbolName = 24;

        public const byte RegName = 6;

        public const byte SectionName = 12;

        public const byte SyntaxComment = 90;

        public const byte InstSig = 64;

        public const byte SymbolicOpCode = 48;

        public const byte FormatPattern = 64;

        public const byte AsmId = 32;

        public const byte Hash = 12;

        public const byte LineNumber = 12;
    }
}