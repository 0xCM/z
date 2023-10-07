//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
    public struct TableDefRow
    {
        public const string TableName = "xed.rules.tables";

        [Render(8)]
        public uint Seq;

        [Render(8)]
        public uint TableId;

        [Render(8)]
        public uint Index;

        [Render(8)]
        public RuleTableKind Kind;

        [Render(32)]
        public RuleName Name;

        [Render(1)]
        public TextBlock Statement;

        public static TableDefRow Empty => default;
    }
}
