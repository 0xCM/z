//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    [Record(TableId)]
    public struct LlvmInstDef : IComparable<LlvmInstDef>
    {
        public const string TableId = "llvm.inst.def";

        public const byte FieldCount = 9;

        [Render(6)]
        public ushort AsmId;

        [Render(6)]
        public bit CgOnly;

        [Render(6)]
        public bit Pseudo;

        [Render(32)]
        public string InstName;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(12)]
        public AsmVariationCode VarCode;

        [Render(54)]
        public string FormatPattern;

        [Render(86)]
        public dag<IExpr> InOperandList;

        [Render(1)]
        public dag<IExpr> OutOperandList;

        [MethodImpl(Inline)]
        public int CompareTo(LlvmInstDef src)
            => AsmId.CompareTo(src.AsmId);
    }
}