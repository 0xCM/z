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
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct FormImport : IComparable<FormImport>, ISequential<FormImport>
        {
            const string TableId = "xed.iform";

            [Render(8)]
            public ushort Seq;

            [Render(8)]
            public ushort FormId;

            [Render(64)]
            public InstForm InstForm;

            [Render(20)]
            public AsmInstClass InstClass;

            [Render(16)]
            public CategoryKind Category;

            [Render(16)]
            public InstIsaKind IsaKind;

            [Render(16)]
            public Extension Extension;

            [Render(1)]
            public InstAttribs Attributes;

            uint ISequential.Seq
            {
                get => Seq;
                set => Seq = (ushort)value;
            }

            public int CompareTo(FormImport src)
                => Seq.CompareTo(src.Seq);

            public static FormImport Empty => default;
        }
    }
}