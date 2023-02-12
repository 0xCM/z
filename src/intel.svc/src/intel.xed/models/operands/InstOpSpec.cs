//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public record struct InstOpSpec : IComparable<InstOpSpec>
        {
            const string TableId = "xed.inst.ops.specs";

            [Render(12)]
            public uint Pattern;

            [Render(8)]
            public byte Index;

            [Render(14)]
            public OpName Name;

            [Render(12)]
            public ElementType ElementType;

            [Render(6)]
            public OpWidth Width;

            [Render(8)]
            public ushort BitWidth;

            [Render(8)]
            public Register RegLit;

            [Render(32)]
            public Nonterminal Rule;

            [Render(12)]
            public GprWidth GprWidth;

            [Render(12)]
            public Segmentation Seg;

            public bool IsReg
            {
                [MethodImpl(Inline)]
                get => RegLit.IsNonEmpty;
            }

            public bool IsRule
            {
                [MethodImpl(Inline)]
                get => Rule.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Width.IsEmpty;
            }

            public string Format()
            {
                var uri = _FileUri.Empty;
                var sig = RuleSig.Empty;
                var detail = EmptyString;
                var bw = BitWidth.ToString();
                if(IsRule)
                {
                    uri = XedPaths.Service.CheckedTableDef(Rule, true, out sig);
                    detail = string.Format("{0}::{1}", Rule, uri);
                }
                else if(IsReg)
                    detail = RegLit.Format();

                if(GprWidth.IsNonEmpty)
                    bw = GprWidth.Format();

                return string.Format(RenderPattern, Index, Name, bw, Seg, ElementType, XedRender.format(Width), detail);
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(InstOpSpec src)
            {
                var result = Pattern.CompareTo(src.Pattern);
                if(result == 0)
                    result = Index.CompareTo(src.Index);
                return result;
            }

            const string RenderPattern = "{0,-2} {1,-14} {2,-6} {3,-12} {4,-6} {5,-3} {6}";

            public static InstOpSpec Empty => default;

            [StructLayout(LayoutKind.Sequential,Pack=1)]
            public readonly record struct Segmentation
            {
                const string RenderPattern = "{0}x{1}{2}x{3}n";

                public readonly ushort DataWidth;

                public readonly ushort ElementWidth;

                public readonly NumericIndicator Indicator;

                public readonly byte ElementCount;

                [MethodImpl(Inline)]
                public Segmentation(ushort dw, ushort ew, NumericIndicator i, byte n)
                {
                    DataWidth = dw;
                    ElementWidth = ew;
                    Indicator = i;
                    ElementCount = n;
                }

                public bool IsEmpty
                {
                    [MethodImpl(Inline)]
                    get => DataWidth == 0;
                }

                public string Format()
                    => IsEmpty ? EmptyString : string.Format(RenderPattern, DataWidth, ElementWidth, Indicator != 0 ? (char)Indicator : EmptyString, ElementCount);

                public override string ToString()
                    => Format();

                public static Segmentation Empty => default;
            }
        }
    }
}