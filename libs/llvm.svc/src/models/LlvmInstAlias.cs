//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    [Record(TableId)]
    public struct LlvmInstAlias : IComparable<LlvmInstAlias>
    {
        const string TableId = "llvm.inst.alias";

        [Render(24)]
        public Identifier InstName;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(48)]
        public TextBlock AsmString;

        [Render(1)]
        public TextBlock Syntax;

        public int CompareTo(LlvmInstAlias src)
            => InstName.CompareTo(src.InstName);
    }
}