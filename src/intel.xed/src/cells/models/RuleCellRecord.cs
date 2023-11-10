//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(RecordId)]
    public record struct RuleCellRecord : IComparable<RuleCellRecord>
    {
        public const string RecordId = "xed.rules.cells";

        [Render(6)]
        public uint Seq;

        [Render(8)]
        public ushort Index;

        [Render(8)]
        public ushort Table;

        [Render(6)]
        public ushort Row;

        [Render(6)]
        public byte Col;

        [Render(6)]
        public LogicClass Logic;

        [Render(10)]
        public RuleCellType Type;

        [Render(6)]
        public RuleTableKind Kind;

        [Render(32)]
        public RuleName Rule;

        [Render(32)]
        public asci32 Expression;

        [Render(24)]
        public EmptyZero<FieldKind> Field;

        [Render(4)]
        public RuleOperator Op;

        [Render(1)]
        public dynamic Value;

        public CellKey Key
            => new CellKey(Index, Table, Row, Col, Logic, Type, Kind, Rule, Field, KeywordKind.None);

        public int CompareTo(RuleCellRecord src)
            => Key.CompareTo(src.Key);

        public static RuleCellRecord Empty => default;
    }
}
