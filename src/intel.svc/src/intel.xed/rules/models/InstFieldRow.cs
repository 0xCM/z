//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [Record(TableId)]
    public struct InstFieldRow
    {
        const string TableId = "xed.inst.fields";

        [Render(12)]
        public uint PatternId;

        [Render(18)]
        public XedInstClass InstClass;

        [Render(26)]
        public AsmOpCode OpCode;

        [Render(8)]
        public MachineMode Mode;

        [Render(8)]
        public LockIndicator Lock;

        [Render(8)]
        public byte Index;

        [Render(12)]
        public RuleCellType FieldClass;

        [Render(26)]
        public EmptyZero<FieldKind> FieldKind;

        [Render(16)]
        public CellExpr FieldExpr;

        [Render(16)]
        public InstFieldSeg Seg;

        [Render(22)]
        public Nonterminal Nonterminal;

        [Render(12)]
        public EmptyZero<Hex8> HexLiteral;

        [Render(12)]
        public LiteralBits BitLiteral;

        public static InstFieldRow Empty => default;
    }
}
