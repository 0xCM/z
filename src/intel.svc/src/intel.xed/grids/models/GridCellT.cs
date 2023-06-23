//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        public readonly record struct GridCell<T> : IComparable<GridCell<T>>
            where T : unmanaged,  IValue<T>, IEquatable<T>, ILogicOperand<T>
        {
            public readonly CellKey Key;

            public readonly T Value;

            [MethodImpl(Inline)]
            public GridCell(CellKey key, T value)
            {
                Key = key;
                Value = value;
            }

            public int CompareTo(GridCell<T> src)
                => Key.CompareTo(src.Key);

            public uint Index
            {
                [MethodImpl(Inline)]
                get => Key.Index;
            }

            // [MethodImpl(Inline)]
            // public static implicit operator Cell(GridCell<T> src)
            //     => new Cell(src.Key, src.Value.Operator, XedGrids.Value.untype(src.Value));
        }
    }
}