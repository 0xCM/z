//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.TypeAttributes;
    using static TableDef;
    using static sys;

    [ApiHost]
    public class TableDefs
    {
        const TypeAttributes Default = BeforeFieldInit | Public | Sealed | AnsiClass;

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

        [Op]
        public static ColumnSet columns(ushort? capacity = null)
            => new ColumnSet(capacity ?? 20);

        public const TypeAttributes ExplicitAnsi
            = Default | ExplicitLayout;

        public const TypeAttributes SequentialAnsi
            = Default | SequentialLayout;

        [MethodImpl(Inline), Op]
        public static TableDef table(TableId name, params Column[] cols)
            => new TableDef(name, cols);

        [MethodImpl(Inline), Op]
        public static Column column(ushort index, Identifier name, Identifier type)
            => new Column(index, name, type);

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
        public static TableDef def(Type src)
        {
            var fields = src.DeclaredInstanceFields();
            var count = fields.Length;
            if(count == 0)
                return new TableDef(TableId.identify(src), sys.empty<Column>());
            var specs = sys.alloc<Column>(count);
            for(var i=z16; i<count; i++)
            {
                var field = skip(fields,i);
                seek(specs,i) = new Column(i, ReflectedField.name(field), field.FieldType.CodeName());
            }

            return new TableDef(TableId.identify(src), specs);
        }

        /// <summary>
        /// Manufactures the type that reifies a supplied record definition
        /// </summary>
        /// <param name="spec">The record definition</param>
        [MethodImpl(NotInline),Op]
        public static Type type(AssemblyName assname, TableDef spec)
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
        public static Type[] types(AssemblyName assname, params TableDef[] specs)
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
        static Type build(ModuleBuilder mb, TableDef spec)
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
        public static ushort offset(Type host, FieldInfo field)
            => (ushort)Marshal.OffsetOf(host, field.Name);

        [Op]
        public static ushort[] offsets(Type host, Index<FieldInfo> fields)
            => fields.Select(f => offset(host,f));

        [Op]
        public static TableDef clone(Type src)
        {
            var declared = src.DeclaredInstanceFields();
            var count = declared.Length;
            var buffer = alloc<Column>(count);
            var fields = @readonly(declared);
            var fieldOffsets = span(offsets(src, declared));
            var dst = span(buffer);
            for(ushort i=0; i<count; i++)
            {
                ref readonly var f = ref skip(fields, i);
                var offset = skip(fieldOffsets,i);
                seek(dst,i) = column(i, f.Name, f.FieldType.Name);
            }

            return new TableDef(Tables.identify(src), buffer);
        }

        public static TableDef def<T>()
            where T : struct
                => def(typeof(T));        
        [Op]
        public static Index<TableDef> defs(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<TableDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = def(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<TableDef> defs(params Assembly[] src)
            => defs(src.Types().Tagged<RecordAttribute>());
    }
}