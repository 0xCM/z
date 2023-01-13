//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public class InstGroupMember : IComparable<InstGroupMember>
        {
            public readonly InstGroupSeq Seq;

            public readonly AsmOpCodeMap Map;

            public readonly InstPattern Pattern;

            [MethodImpl(Inline)]
            public InstGroupMember(InstGroupSeq seq, InstPattern pattern)
            {
                Seq = seq;
                Map = AsmOpCodeMaps.map(seq.OpCode.Kind);
                Pattern = pattern;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Pattern.InstForm;
            }

            public ref readonly InstCells Fields
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Cells;
            }

            public ref readonly byte Index
            {
                [MethodImpl(Inline)]
                get => ref Seq.Index;
            }

            public ref readonly ModIndicator Mod
            {
                [MethodImpl(Inline)]
                get => ref Seq.Mod;
            }

            public ref readonly BitIndicator RexW
            {
                [MethodImpl(Inline)]
                get => ref Seq.RexW;
            }

            public ref readonly RepIndicator Rep
            {
                [MethodImpl(Inline)]
                get => ref Seq.Rep;
            }

            public ref readonly ushort PatternId
            {
                [MethodImpl(Inline)]
                get => ref Seq.PatternId;
            }

            public ref readonly LockIndicator Lock
            {
                [MethodImpl(Inline)]
                get => ref Seq.Lock;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Seq.Mode;
            }

            public ref readonly AsmInstClass Class
            {
                [MethodImpl(Inline)]
                get => ref Seq.Instruction;
            }

            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref Seq.OpCode;
            }

            public int CompareTo(InstGroupMember src)
                => Seq.CompareTo(src.Seq);

            public static InstGroupMember Empty => new (InstGroupSeq.Empty, InstPattern.Empty);
        }
    }
}