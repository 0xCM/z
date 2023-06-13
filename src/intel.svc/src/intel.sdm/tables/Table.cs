//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct Table
    {
        [MethodImpl(Inline), Op]
        public static TableCell cell(object content)
            => new TableCell(content);

        [MethodImpl(Inline), Op]
        public static TableColumn column(string name, string type, ushort length)
            => new TableColumn(name, type, length);

        public static TableColumn column<K>(string name)
            where K : unmanaged, Enum
        {
            var kinds = Symbols.index<K>();
            var result = kinds.Lookup(name.Trim(), out var sym);
            var type = result ? sym.Expr.Format() : string.Format("!{0}!", name);
            var length = name.Length;
            return column(name.Trim(), type, (ushort)length);
        }

        public static Seq<TableColumn> columns<K>(ReadOnlySpan<string> src)
            where K : unmanaged, Enum
        {
            var count = src.Length;
            var buffer = alloc<TableColumn>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                seek(dst,i) = column<K>(skip(src,i));
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static TableRow row(uint seq, TableCell[] cells)
            => new TableRow(seq, cells);
        
        [MethodImpl(Inline), Op]
        public static TableRow row(TableCell[] cells)
            => new TableRow(0, cells);

        [MethodImpl(Inline), Op]
        public static TableRow row(string[] cells)
            => new TableRow(0, cells.Select(cell));

        [MethodImpl(Inline), Op]
        public static TableRow row(object[] cells)
            => new TableRow(0, cells.Select(cell));

        [MethodImpl(Inline), Op]
        public static Table define(string src, uint kind, TableColumn[] cols, TableRow[] rows)
            => new Table(src,kind, cols, rows);

        public string Source {get;}

        public uint Kind {get;}

        readonly TableRow[] Data;

        readonly TableColumn[] _Cols;

        [MethodImpl(Inline)]
        public Table(string src, uint kind, TableColumn[] cols, TableRow[] rows)
        {
            Source = src;
            Kind = kind;
            Data = rows;
            _Cols = cols;
        }

        public Span<TableRow> Rows
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<TableColumn> Cols
        {
            [MethodImpl(Inline)]
            get => _Cols;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }
    }
}