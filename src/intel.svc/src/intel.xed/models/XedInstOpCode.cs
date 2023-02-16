//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static AsmOpCodeMaps;
    using static XedRules;

    [Record(TableId), StructLayout(StructLayout,Pack=1)]
    public record struct XedInstOpCode : IComparable<XedInstOpCode>
    {
        const string TableId = "xed.inst.opcodes";

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public ushort PatternId;

        [Render(18)]
        public XedInstClass InstClass;

        [Render(8)]
        public byte Index;

        [Render(8)]
        public MapName MapName;

        [Render(16)]
        public AsmOcValue Value;

        [Render(6)]
        public MachineMode Mode;

        [Render(6)]
        public LockIndicator Lock;

        [Render(6)]
        public ModIndicator Mod;

        [Render(6)]
        public BitIndicator RexW;

        [Render(6)]
        public RepIndicator Rep;

        [Render(112)]
        public InstCells Layout;

        [Render(1)]
        public InstCells Expr;

        [Ignore]
        public XedOpCode OpCode;

        [MethodImpl(Inline)]
        public int CompareTo(XedInstOpCode src)
            => XedRules.cmp(this, src);
    }
}