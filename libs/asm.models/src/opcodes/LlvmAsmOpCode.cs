//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = RenderStyle;

    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public record struct LlvmAsmOpCode : IComparable<LlvmAsmOpCode>
    {
        const string TableId = "llvm.asm.opcode";

        [Render(8)]
        public ushort AsmId;

        [Render(32)]
        public asci32 InstName;

        [Render(16)]
        public asci16 Map;

        [Render(8)]
        public asci8 Bits;

        [Render<S>(8, S.Fixed)]
        public Hex8 Hex;

        public int CompareTo(LlvmAsmOpCode src)
            => AsmId.CompareTo(src.AsmId);
    }
}