//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedImport
    {
        [StructLayout(StructLayout,Pack=1), Record(TableId)]
        public struct InstBlockImport : ISequential<InstBlockImport>, IComparable<InstBlockImport>
        {
            public const string TableId = "xed.instblock.import";

            [Render(6)]
            public uint Seq;

            [Render(18)]
            public AmsInstClass Class;

            [Render(8)]
            public MachineMode Mode;

            [Render(62)]
            public InstForm Form;

            [Render(1)]
            public InstPatternBody Pattern;

            public override int GetHashCode()
                => (int)Seq;

            [MethodImpl(Inline)]
            public bool Equals(InstBlockImport src)
                => Seq == src.Seq;

            uint ISequential.Seq
            {
                get => Seq;
                set => Seq = value; }

            public int CompareTo(InstBlockImport src)
            {
                var result = Class.CompareTo(src.Class);
                if(result == 0)
                    result = Pattern.Format().CompareTo(src.Pattern.Format());
                return result;
            }

            public static InstBlockImport Empty => default;
        }
    }
}
