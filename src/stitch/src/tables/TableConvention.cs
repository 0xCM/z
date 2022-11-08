//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class TableConvention
    {
        const NumericKind Closure = UInt64k;

        internal const string DefaultDelimiter = " | ";

        internal const byte DefaultFieldWidth = 24;

        /// <summary>
        /// Formats a <see cref='RowHeader'/>
        /// </summary>
        /// <param name="src">The source header</param>
        public static string format(RowHeader src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                    dst.Append(src.Delimiter);

                dst.Append(src[i].Format());
            }
            return dst.ToString();
        }

        public static ReadOnlySpan<uint> cuts(ReadOnlySpan<byte> widths)
        {
            var count = (uint)widths.Length;
            var dst = span<uint>(count - 1);
            cuts(widths,dst);
            return dst;
        }

        public static ReadOnlySpan<Pair<uint>> segments(ReadOnlySpan<byte> widths)
        {
            const uint SepWidth = 3u;
            var count = (uint)widths.Length;
            var dst = span<Pair<uint>>(count);
            var offset = z32;
            for(var i=0u; i<count; i++)
            {
                ref readonly var width = ref skip(widths,i);
                var cut = math.add(offset, width + 1u);
                seek(dst,i) = (offset, cut - 1u);
                offset += (width + SepWidth);
            }
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void cuts(ReadOnlySpan<byte> widths, Span<uint> dst)
        {
            const uint SepWidth = 3u;
            var count = (uint)widths.Length;
            var offset = z32;
            for(var i=0u; i<count - 1; i++)
            {
                ref readonly var width = ref skip(widths,i);
                var cut = math.add(offset, width + 1u);
                seek(dst,i) = cut;
                offset += (width + SepWidth);
            }
        }
        public static string KvpPattern(in RowFormatSpec spec)
        {
            var slot0 = RP.slot(0, math.negate((short)spec.MaxCellWidth));
            var slot1 = RP.slot(1);
            return slot0 + Chars.Space + spec.Delimiter + Chars.Space + slot1;
        }

        [Op]
        static string slot(byte index, RenderWidth width, string delimiter = DefaultDelimiter)
            => delimiter + RP.slot(index, (short)(-(short)width));

        [Op]
        public static string pattern(Index<CellFormatSpec> cells, string delimiter = DefaultDelimiter)
        {
            var count = cells.Count;
            var view = cells.View;
            var parts = alloc<string>(count);
            for(var i=0u; i<count; i++)
            {
                var cell = skip(view,i);
                seek(parts,i) = slot((byte)i, cell.Width, i!=0 ? delimiter : EmptyString);
            }
            return string.Concat(parts);
        }

        [MethodImpl(Inline), Op]
        public static RowFormatSpec rowspec(RowHeader header, CellFormatSpec[] cells, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            => new RowFormatSpec(header, cells, pattern(cells, header.Delimiter), rowpad, Chars.Pipe, fk);

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(ReadOnlySpan<byte> widths, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var header = Tables.header<T>(widths);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }

        [Op, Closures(Closure)]
        public static RowFormatSpec rowspec<T>(byte width, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
        {
            var header = Tables.header<T>(width);
            return rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        }        
        [Op]
        public static ReflectedTable reflected(Type src)
        {
            var layout = src.Tag<StructLayoutAttribute>();
            var id = TableId.identify(src);
            LayoutKind? kind = null;
            CharSet? charset = null;
            byte? pack = null;
            uint? size = null;
            if(layout)
            {
                var value = layout.Value;
                kind = value.Value;
                charset = value.CharSet;
                pack = (byte)value.Pack;
                size = (uint)value.Size;
            }
            return new ReflectedTable(src, id, Tables.fields(src), kind, charset, pack, size);
        }

        [Op]
        public static Index<ReflectedTable> reflected(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var dst = list<ReflectedTable>();
            for(var i=0; i<count; i++)
                discover(skip(src,i), dst);
            return dst.ToArray();
        }

        [Op]
        public static Index<ReflectedTable> reflected(Assembly src)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var dst = list<ReflectedTable>();
            discover(src, dst);
            return dst.ToArray();
        }

        [Op]
        static uint discover(Assembly src, List<ReflectedTable> dst)
        {
            var types = src.Types().Tagged<RecordAttribute>().Index();
            for(var i=0; i<types.Count; i++)
                dst.Add(reflected(types[i]));
            return types.Count;
        }

        [MethodImpl(Inline), Op]
        public static TableCell cell(object content)
            => new TableCell(content);

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
    }
}