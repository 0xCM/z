//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.TypeAttributes;
    using static sys;

    [ApiHost]
    public class TableDefs
    {
        const TypeAttributes Default = BeforeFieldInit | Public | Sealed | AnsiClass;

        const NumericKind Closure = UnsignedInts;

        const string DefaultDelimiter = " | ";

        public static Index<Type> types(params Assembly[] src)
            => src.Types().Tagged<RecordAttribute>();

        /// <summary>
        /// Computes the <see cref='TableId'/> of a parametrically-identified record
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static TableId identify<T>()
            where T : struct
                => TableId.identify<T>();

        [Op]
        public static TableId identify(Type type)
            => TableId.identify(type);

        [Op]
        public static TableId identify(Type type, string name)
            => TableId.identify(type, name);

        /// <summary>
        /// Creates a row header for parametrically-identified record type
        /// </summary>
        /// <param name="widths">The cell render widths</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header<T>(ReadOnlySpan<byte> widths, string delimiter = DefaultDelimiter)
            => header(typeof(T), widths);

        /// <summary>
        /// Creates a row header for parametrically-identified record type and uniform field width
        /// </summary>
        /// <param name="fieldwidht">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header<T>(byte fieldwidth, string delimiter = DefaultDelimiter)
            => header(typeof(T), fieldwidth, delimiter);

        /// <summary>
        /// Creates a row header for a specified record type record type and uniform field width
        /// </summary>
        /// <param name="fieldwidht">The uniform field width</param>
        /// <typeparam name="T">The record type</typeparam>
        public static RowHeader header(Type record, byte fieldwidth, string delimiter = DefaultDelimiter)
        {
            var _fields = TableDefs.cells(record).ToReadOnlySpan();
            var count = _fields.Length;
            var buffer = alloc<HeaderCell>(count);
            var cells = span(buffer);
            for(var i=0u; i<count; i++)
                seek(cells, i) = new HeaderCell(i, skip(_fields,i).CellName, fieldwidth);
            return new RowHeader(buffer, delimiter);
        }

        /// <summary>
        /// Creates a row header for a specified record type
        /// </summary>
        /// <param name="widths">The cell render widths</param>
        public static RowHeader header(Type record, ReadOnlySpan<byte> widths, string delimiter = DefaultDelimiter)
        {
            var _fields = TableDefs.cells(record).ToReadOnlySpan();
            var count = _fields.Length;
            if(count != widths.Length)
                sys.@throw(AppMsgs.FieldCountMismatch.Format(count, widths.Length));
            var buffer = alloc<HeaderCell>(count);
            var cells = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(_fields,i);
                seek(cells,i) = new HeaderCell(i, field.CellName, skip(widths,i));
            }
            return new RowHeader(buffer, delimiter);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref RowAdapter<T> adapt<T>(in T src, ref RowAdapter<T> adapter)
        {
            adapter.Source = src;
            adapter.Index++;
            load(adapter.Source, ref adapter.Row);
            return ref adapter;
        }

        [Op, Closures(Closure)]
        public static void load<T>(in T src, ref DynamicRow<T> dst)
        {
            var tr = __makeref(sys.edit(src));
            for(var i=0u; i<dst.FieldCount; i++)
                dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
        }

        /// <summary>
        /// Adapts a <see cref='ClrTableCells'/> sequence to a <typeparamref name='T'/> parametric row
        /// </summary>
        /// <param name="fields">The record fields</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static RowAdapter<T> adapter<T>(in ClrTableCells fields)
            => new RowAdapter<T>(fields);

        /// <summary>
        /// Creates a <see cref='RowAdapter{T}'/> predicated a specified <typeparamref name='T'/>
        /// </summary>
        /// <typeparam name="T">The row type</typeparam>
        [Op, Closures(Closure)]
        public static RowAdapter<T> adapter<T>()
            => adapter<T>(TableDefs.cells<T>());

        [Op, Closures(Closure)]
        public static DynamicRow<T> dynarow<T>(ClrTableCells fields)
            => new DynamicRow<T>(fields, new object[fields.Length]);

        [Op, Closures(Closure)]
        public static DynamicRow dynarow(ClrTableCells fields)
            => new DynamicRow(fields, new object[fields.Length]);

        /// <summary>
        /// Discerns a <see cref='ClrTableCells'/> for a parametrically-identified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        public static ClrTableCell[] cells<T>()
            => cells(typeof(T));

        /// <summary>
        /// Discerns a <see cref='ClrTableCells'/> for a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [Op]
        public static ClrTableCell[]  cells(Type src)
        {
            var fields = src.DeclaredPublicInstanceFields().Ignore().Index();
            var count = fields.Count;
            var dst = sys.alloc<ClrTableCell>(count);
            for(var i=z32; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                var tag = field.Tag<RenderAttribute>();
                if(tag)
                {
                    var tv = tag.Value;
                    sys.seek(dst,i) = new ClrTableCell(new CellRenderSpec(i, tv.Width, TextFormat.formatter(field.FieldType, (ushort)tv.Style)), field);
                }
                else
                {
                    sys.seek(dst,i) = new ClrTableCell(new CellRenderSpec(i, 16, TextFormat.formatter(field.FieldType)), field);
                }

            }
            return dst;
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
        public static TableCell cell(object content)
            => new TableCell(content);

        [Op]
        public static ClrTable reflected(Type src)
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
            return new ClrTable(src, id, cells(src), kind, charset, pack, size);
        }

        [Op]
        public static Index<ClrTable> reflected(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var dst = list<ClrTable>();
            for(var i=0; i<count; i++)
                discover(skip(src,i), dst);
            return dst.ToArray();
        }

        [Op]
        public static Index<ClrTable> reflected(Assembly src)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var dst = list<ClrTable>();
            discover(src, dst);
            return dst.ToArray();
        }

        [Op]
        static uint discover(Assembly src, List<ClrTable> dst)
        {
            var types = src.Types().Tagged<RecordAttribute>().Index();
            for(var i=0; i<types.Count; i++)
                dst.Add(reflected(types[i]));
            return types.Count;
        }

        [Op]
        public static ColumnSet columns(ushort? capacity = null)
            => new ColumnSet(capacity ?? 20);

        public const TypeAttributes ExplicitAnsi
            = Default | ExplicitLayout;

        public const TypeAttributes SequentialAnsi
            = Default | SequentialLayout;

        [MethodImpl(Inline), Op]
        public static CsvTableDef table(TableId name, Identifier type, params ColumDef[] cols)
            => new CsvTableDef(name, type, cols);

        [MethodImpl(Inline), Op]
        public static ColumDef column(ushort index, Identifier name, Identifier type)
            => new ColumDef(index, name, type);

        [Op]
        public static TypeBuilder type(ModuleBuilder mb, Identifier fullName, TypeAttributes attributes, Type parent)
            => mb.DefineType(fullName, attributes, parent);

        [Op]
        public static TypeBuilder valueType(ModuleBuilder mb, Identifier fullName, TypeAttributes attributes)
            => mb.DefineType(fullName, attributes, typeof(ValueType));

        [MethodImpl(Inline), Op]
        public static ModuleBuilder module(string name)
        {
            var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(name), AssemblyBuilderAccess.Run);
            return ab.DefineDynamicModule("Primary");
        }

        [MethodImpl(Inline), Op]
        public static TypeBuilder type(ModuleBuilder mb, string name, TypeAttributes attributes, Type parent)
            => mb.DefineType(name, attributes, parent);

        [MethodImpl(Inline), Op]
        public static TypeBuilder @struct(ModuleBuilder mb, string name, TypeAttributes attributes)
            => mb.DefineType(name, attributes, typeof(ValueType));

        [Op]
        public static System.Reflection.Emit.FieldBuilder field(TypeBuilder tb, string name, string type, Address16? offset = null)
        {
            var fb = tb.DefineField(name, Type.GetType(type), FieldAttributes.Public);
            if(offset != null)
                fb.SetOffset(offset.Value);
            return fb;
        }

        [Op]
        public static System.Reflection.Emit.FieldBuilder field(TypeBuilder tb, Identifier name, Identifier type, uint? offset = null)
        {
            var fb = tb.DefineField(name.Format(), Type.GetType(type.Format()), FieldAttributes.Public);
            if(offset != null)
                fb.SetOffset((int)offset.Value);
            return fb;
        }

        [Op]
        public static CsvTableDef def(Type src)
        {
            var fields = src.PublicInstanceFields();
            var count = fields.Length;
            if(count == 0)
                return new CsvTableDef(TableId.identify(src), src.Name, sys.empty<ColumDef>());
            var specs = alloc<ColumDef>(count);
            for(var i=z16; i<count; i++)
            {
                var field = skip(fields,i);
                seek(specs,i) = new ColumDef(i, ClrTableCell.name(field), field.FieldType.CodeName());
            }

            return new CsvTableDef(TableId.identify(src), src.Name, specs);
        }

        /// <summary>
        /// Manufactures the type that reifies a supplied record definition
        /// </summary>
        /// <param name="spec">The record definition</param>
        [MethodImpl(NotInline),Op]
        public static Type type(AssemblyName assname, CsvTableDef spec)
            => build(module(assname), spec);

        [Op]
        public static ModuleBuilder module(AssemblyName name)
        {
            var ab = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
            return ab.DefineDynamicModule("Primary");
        }

        /// <summary>
        /// Manufactures the types that reify supplied record definitions
        /// </summary>
        /// <param name="spec">The record definition</param>
        [MethodImpl(NotInline), Op]
        public static Type[] types(AssemblyName assname, params CsvTableDef[] specs)
        {
            var count = specs.Length;
            var buffer = alloc<Type>(count);
            var dst = span(buffer);
            var src = @readonly(specs);
            var mb = module(assname);
            for(var i=0u; i<count; i++)
                seek(dst,i) = build(mb, skip(src,i));
            return buffer;
        }

        [Op]
        static Type build(ModuleBuilder mb, CsvTableDef spec)
        {
            var tb = valueType(mb, spec.TypeName, ExplicitAnsi);
            var fields = spec.Columns;
            var pos = z16;
            foreach(var f in fields)
                column(pos++, f.Name, f.DataType);
            var type = tb.CreateType();
            return type;
        }

        [Op]
        public static uint offset(Type host, FieldInfo field)
            => (uint)Marshal.OffsetOf(host, field.Name);

        [Op]
        public static uint[] offsets(Type host, Index<FieldInfo> fields)
            => fields.Select(f => offset(host,f));

        [Op]
        public static CsvTableDef infer(Type src)
        {
            var members = src.PublicInstanceFields();
            var count = members.Length;
            var cols = alloc<ColumDef>(count);
            var fieldOffsets = offsets(src, members);
            for(ushort i=0; i<count; i++)
            {
                ref readonly var member = ref skip(members, i);
                var offset = skip(fieldOffsets,i);
                seek(cols,i) = column(i, member.Name, Clr.type(member).Name);
            }

            return new CsvTableDef(TableId.identify(src), src.Name, cols);
        }

        public static CsvTableDef def<T>()
            where T : struct
                => def(typeof(T));        
        [Op]
        public static Index<CsvTableDef> defs(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<CsvTableDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = def(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<CsvTableDef> defs(params Assembly[] src)
            => defs(src.Types().Concrete().Tagged<RecordAttribute>());
    }
}