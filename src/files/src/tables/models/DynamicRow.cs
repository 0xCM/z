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
    public struct DynamicRow
    {
        /// <summary>
        /// The record fields
        /// </summary>
        public readonly ClrTableCols Cells;

        readonly Index<object> Values;

        [MethodImpl(Inline)]
        public DynamicRow(ClrTableCols cells, object[] values)
        {
            Cells = cells;
            Values = values;
        }

        public string Format(string pattern, RenderBuffers buffers)
        {
            for(var i=0; i<CellCount; i++)
                buffers[i] = Cells.FormatFieldValue(i, this[i]);
            return string.Format(pattern, buffers.CellStorage);
        }

        public string Format(string pattern, object[] buffer)
        {
            for(var i=0; i<CellCount; i++)
                seek(buffer,i) = Cells.FormatFieldValue(i, this[i]);
            return string.Format(pattern, buffer);
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Cells.Count;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Values.Length;
        }

        public ref object this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Values[index];
        }

        public ref object this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Values[index];
        }
    }
}