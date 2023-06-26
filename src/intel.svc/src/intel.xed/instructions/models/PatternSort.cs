//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct PatternSort : IComparable<PatternSort>, IComparer<InstPatternRecord>, IComparer<InstPatternSpec>
        {
            public static PatternSort comparer() => default;

            public readonly XedInstClass InstClass;

            public readonly XedOpCode OpCode;

            public readonly MachineMode Mode;

            public readonly LockIndicator Lock;

            public readonly ModIndicator Mod;

            public readonly BitIndicator RexW;

            public readonly RepIndicator Rep;

            readonly bool OpCodeFirst;

            [MethodImpl(Inline)]
            public PatternSort(InstPattern src, bool ocfirst = false)
            {
                ref readonly var fields = ref src.Cells;
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = XedCells.mod(fields);
                RexW = XedCells.rexw(fields);
                Rep = XedCells.rep(fields);
                OpCodeFirst = ocfirst;
            }

            [MethodImpl(Inline)]
            public PatternSort(in InstPatternRecord src, bool ocfirst = false)
            {
                ref readonly var fields = ref src.Body.Cells;
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = XedCells.mod(fields);
                RexW = XedCells.rexw(fields);
                Rep = RepIndicator.Empty;
                Rep = XedCells.rep(fields);
                OpCodeFirst = ocfirst;
            }

            [MethodImpl(Inline)]
            public PatternSort(in InstPatternSpec src, bool ocfirst = false)
            {
                ref readonly var fields = ref src.Body.Cells;
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = XedCells.@lock(fields);
                Mod = XedCells.mod(fields);
                RexW = XedCells.rexw(fields);
                Rep = RepIndicator.Empty;
                Rep = XedCells.rep(fields);
                OpCodeFirst = ocfirst;
           }

            [MethodImpl(Inline)]
            public PatternSort(in InstGroupSeq src, bool ocfirst = false)
            {
                InstClass = src.Instruction;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = src.Mod;
                RexW = src.RexW;
                Rep = src.Rep;
                OpCodeFirst = ocfirst;
            }

            [MethodImpl(Inline)]
            public PatternSort(in InstOpDetail src, bool ocfirst = false)
            {
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = src.Mod;
                RexW = src.RexW;
                Rep = src.Rep;
                OpCodeFirst = ocfirst;
            }

            [MethodImpl(Inline)]
            public PatternSort(in XedInstOpCode src, bool ocfirst = false)
            {
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = src.Mod;
                RexW = src.RexW;
                Rep = src.Rep;
                OpCodeFirst = ocfirst;
            }

            public int CompareTo(PatternSort src)
            {
                var result = 0;
                if(OpCodeFirst)
                {
                    result = AsmOpCodeMaps.cmp(OpCode.Kind,src.OpCode.Kind);
                    if(result == 0)
                        result = OpCode.Value.CompareTo(src.OpCode.Value);
                    if(result == 0)
                        result = InstClass.CompareTo(src.InstClass);
                }
                else
                {
                    result = InstClass.CompareTo(src.InstClass);
                    if(result == 0)
                        result = OpCode.Value.CompareTo(src.OpCode.Value);
                }

                if(result == 0)
                {
                    if(result == 0)
                        result = Mode.CompareTo(src.Mode);

                    if(result == 0)
                        result = Lock.CompareTo(src.Lock);

                    if(result==0)
                    {
                        var a = (uint)Rep.Kind | ((uint)Mod.Kind << 4) | (RexW.Enabled ? 0xFFu << 8 : 0u);
                        var b = (uint)src.Rep.Kind | ((uint)src.Mod.Kind << 4) | (src.RexW.Enabled ? 0xFFu << 8 : 0u);
                        result = a.CompareTo(b);
                    }

                }
                return result;
            }

            public string Format()
                => GetHashCode().FormatHex();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int Compare(InstPatternRecord x, InstPatternRecord y)
                => x.Sort().CompareTo(y.Sort());

            [MethodImpl(Inline)]
            public int Compare(InstPatternSpec x, InstPatternSpec y)
                => x.CompareTo(y);

            [MethodImpl(Inline)]
            public int Compare(InstPattern x, InstPattern y)
                => x.Sort().CompareTo(y.Sort());
        }
    }
}