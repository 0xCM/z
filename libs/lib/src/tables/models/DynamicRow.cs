//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;

    /// <summary>
    /// Defines the content of a row
    /// </summary>
    /// <typeparam name="T">The record type</typeparam>
    public struct DynamicRow
    {
        /// <summary>
        /// The record fields
        /// </summary>
        public readonly ClrTableFields Fields;

        readonly Index<object> Cells;

        [MethodImpl(Inline)]
        public DynamicRow(ClrTableFields fields, object[] cells)
        {
            Fields = fields;
            Cells = cells;
        }

        public string Format(string pattern, RenderBuffers buffers)
        {
            for(var i=0; i<CellCount; i++)
                buffers[i] = Fields.FormatFieldValue(i, this[i]);
            return string.Format(pattern, buffers.CellStorage);
        }

        public string Format(string pattern, object[] buffer)
        {
            for(var i=0; i<CellCount; i++)
                seek(buffer,i) = Fields.FormatFieldValue(i, this[i]);
            return string.Format(pattern, buffer);
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
    }
}