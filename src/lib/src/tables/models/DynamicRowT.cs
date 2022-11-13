//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines the content of a row
    /// </summary>
    /// <typeparam name="T">The record type</typeparam>
    public struct DynamicRow<T>
        where T : struct
    {
        /// <summary>
        /// The record fields
        /// </summary>
        public readonly ReflectedFields Fields;

        /// <summary>
        /// The cell values
        /// </summary>
        readonly Index<object> Cells;

        [MethodImpl(Inline)]
        public DynamicRow(ReflectedFields fields, object[] cells)
        {
            Fields = fields;
            Cells = cells;
        }

        public void Update(in T src)
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<FieldCount; i++)
                this[i] = Fields[i].Definition.GetValueDirect(tr);
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Cells.Length;
        }

        public ref object this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }

        public ref object this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cells[index];
        }

        public string Format(in RowFormatSpec spec)
            => string.Format(spec.Pattern, Cells.Storage);

        [MethodImpl(Inline)]
        public static implicit operator DynamicRow(DynamicRow<T> src)
            => new DynamicRow(src.Fields, src.Cells);
    }
}