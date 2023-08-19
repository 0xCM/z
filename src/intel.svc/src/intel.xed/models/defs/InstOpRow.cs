//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
    public record struct InstOpRow
    {
        public const string TableName = "xed.inst.ops";

        [Render(12)]
        public uint Pattern;

        [Render(18)]
        public XedInstClass InstClass;

        [Render(26)]
        public XedOpCode OpCode;

        [Render(6)]
        public MachineMode Mode;

        [Render(6)]
        public LockIndicator Lock;

        [Render(6)]
        public ModIndicator Mod;

        [Render(10)]
        public BitIndicator RexW;

        [Render(10)]
        public byte OpCount;

        [Render(8)]
        public byte Index;

        [Render(8)]
        public OpName Name;

        [Render(8)]
        public OpKind Kind;

        [Render(10)]
        public EnumFormat<OpAction> Action;

        [Render(10)]
        public EnumFormat<WidthCode> WidthCode;

        [Render(10)]
        public GprWidth GprWidth;

        [Render(10)]
        public EmptyZero<ushort> BitWidth;

        [Render(6)]
        public ElementType EType;

        [Render(6)]
        public EmptyZero<ushort> EWidth;

        [Render(12)]
        public EmptyZero<byte> ECount;

        [Render(12)]
        public BitSegType SegInfo;

        [Render(8)]
        public EmptyZero<Register> RegLit;

        [Render(12)]
        public OpModifier Modifier;

        [Render(12)]
        public Visibility Visibility;

        [Render(16)]
        public Nonterminal NonTerminal;

        [Render(1)]
        public asci64 SourceExpr;

        public static InstOpRow Empty => default;
    }
}
