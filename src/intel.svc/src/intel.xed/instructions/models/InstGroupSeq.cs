//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public record struct InstGroupSeq : IComparable<InstGroupSeq>
        {
            public const string TableId = "xed.inst.groups";

            [Render(8)]
            public uint Seq;

            [Render(12)]
            public ushort PatternId;

            [Render(18)]
            public XedInstClass Instruction;

            [Render(6)]
            public ModIndicator Mod;

            [Render(6)]
            public LockIndicator Lock;

            [Render(6)]
            public MachineMode Mode;

            [Render(6)]
            public BitIndicator RexW;

            [Render(6)]
            public RepIndicator Rep;

            [Render(6)]
            public byte Index;

            [Render(26)]
            public XedOpCode OpCode;

            [Render(22)]
            public AsmOcValue OpCodeBytes;

            [Render(1)]
            public XedInstForm Form;

            public AsmOpCodeClass OpCodeClass
            {
                [MethodImpl(Inline)]
                get => OpCode.Class;
            }

            PatternSort Sort()
                => new PatternSort(this);

            public int CompareTo(InstGroupSeq src)
                => Sort().CompareTo(src.Sort());

            public override int GetHashCode()
                => (int)PatternId | (int)Index << 16;

            public static InstGroupSeq Empty => default;
        }
    }
}