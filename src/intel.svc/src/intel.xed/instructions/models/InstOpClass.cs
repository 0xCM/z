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
        /// <summary>
        /// Characterizes a disassembled operand class
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public record struct InstOpClass : IComparable<InstOpClass>
        {
            public const string TableId = "xed.inst.ops.classes";

            [Render(8)]
            public uint Seq;

            [Render(12)]
            public OpKind Kind;

            [Render(12)]
            public ushort BitWidth;

            [Render(12)]
            public EmptyZero<WidthCode> WidthCode;

            [Render(12)]
            public ElementType ElementType;

            [Render(12)]
            public byte ElementCount;

            [Render(12)]
            public bit IsRegLit;

            [Render(12)]
            public bit IsRule;

            public int CompareTo(InstOpClass src)
                => Xed.cmp(this,src);

            public static InstOpClass Empty => default;
        }
    }
}