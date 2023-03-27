//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a row over a specified record type
    /// </summary>
    /// <typeparam name="T">The record type</typeparam>
    public struct RowAdapter<T>
    {
        public readonly ClrTableCols Fields
        {
            [MethodImpl(Inline)]
            get => Row.Fields;
        }

        internal uint Index;

        internal T Source;

        internal DynamicRow<T> Row;

        [MethodImpl(Inline)]
        internal RowAdapter(ClrTableCols fields)
        {
            Source = default;
            Index = 0;
            Row = Tables.dynarow<T>(fields);
        }

        [MethodImpl(Inline)]
        public RowAdapter<T> Adapt(in T src)
            => Tables.adapt(src, ref this);

        public ref readonly object this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Row[index];
        }

        public ref readonly object this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Row[index];
        }

        public readonly DynamicRow<T> Adapted
        {
            [MethodImpl(Inline)]
            get => Row;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Row.CellCount;
        }
    }
}