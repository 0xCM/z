//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        public readonly record struct Cell<T> : IComparable<Cell<T>>
            where T : unmanaged,  IValue<T>, IEquatable<T>, ILogicOperand<T>
        {
            public readonly CellKey Key;

            public readonly T Value;

            [MethodImpl(Inline)]
            public Cell(CellKey key, T value)
            {
                Key = key;
                Value = value;
            }

            public int CompareTo(Cell<T> src)
                => Key.CompareTo(src.Key);

            public uint Index
            {
                [MethodImpl(Inline)]
                get => Key.Index;
            }

            [MethodImpl(Inline)]
            public static implicit operator Cell(Cell<T> src)
                => new Cell(src.Key, src.Value.Operator, XedGrids.Value.untype(src.Value));
        }
    }
}