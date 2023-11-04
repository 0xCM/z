//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    [Record(TableId),StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct InstPatternRecord : IComparable<InstPatternRecord>, ISequential<InstPatternRecord>
    {
        public const string TableId = "xed.inst.patterns";

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public ushort PatternId;

        [Render(18)]
        public XedInstClass InstClass;

        [Render(26)]
        public AsmOpCode OpCode;

        [Render(8)]
        public MachineMode Mode;

        [Render(8)]
        public LockIndicator Lock;

        [Render(8)]
        public EmptyZero<bit> Scalable;

        [Render(1)]
        public InstCells Body;

        public int CompareTo(InstPatternRecord src)
            => Sort().CompareTo(src.Sort());

        [MethodImpl(Inline)]
        public PatternSort Sort()
            => new PatternSort(this,true);

        public static InstPatternRecord Empty => default;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}
