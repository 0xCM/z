//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class TableRows
    {
        List<TableRow> Data;

        TableColumn[] Cols;

        uint Kind;

        string Source;

        public static TableRows create()
            => new TableRows(0);

        public TableRows(uint kind)
        {
            Kind = kind;
            Source = EmptyString;
            Data = new();
            Cols = array<TableColumn>();
        }

        public TableRows WithKind(uint kind)
        {
            Kind = kind;
            return this;
        }

        public TableRows WithSource(string src)
        {
            Source = src;
            return this;
        }

        public TableRows WithRow(in TableRow row)
        {
            Data.Add(row);
            return this;
        }

        public TableRows WithColumns(TableColumn[] cols)
        {
            Cols = cols;
            return this;
        }

        public TableRows WithRow(TableCell[] cells)
        {
            Data.Add(new TableRow(0, cells));
            return this;
        }

        public TableRows WithRow(string[] cells)
        {
            Data.Add(new TableRow(0, cells.Select(x => new TableCell(x))));
            return this;
        }

        public TableRows WithRows(ReadOnlySpan<TableRow> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Data.Add(skip(src,i));
            return this;
        }

        public TableRows IfNonEmpty(Action f)
        {
            if(IsNonEmpty)
                f();
            return this;
        }

        public Table Emit()
        {
            var rows = Data.ToArray();
            var count = rows.Length;
            ref var row = ref first(rows);
            for(var i=0u; i<count; i++)
                seek(row,i).Seq = i;
            var dst = Table.define(Source, Kind, Cols.Replicate(), rows);
            Clear();
            return dst;
        }

        public TableRows Clear()
        {
            Data.Clear();
            Cols.Clear();
            Kind = 0;
            return this;
        }

        public bool IsNonEmpty
        {
            get => Data.Count != 0;
        }
    }
}