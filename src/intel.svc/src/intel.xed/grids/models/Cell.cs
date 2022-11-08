//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct Cell
        {
            public readonly CellKey Key;

            public readonly RuleOperator Operator;

            public readonly Value Value;

            [MethodImpl(Inline)]
            public Cell(CellKey key, RuleOperator op, Value value)
            {
                Key = key;
                Operator = op;
                Value = value;
            }

            public uint Index
            {
                [MethodImpl(Inline)]
                get => Key.Index;
            }
        }
    }
}