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

        [Op]
        public static ColumnSet columns(ushort? capacity = null)
            => new ColumnSet(capacity ?? 20);

        public const TypeAttributes ExplicitAnsi
            = Default | ExplicitLayout;

        public const TypeAttributes SequentialAnsi
            = Default | SequentialLayout;

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
    }
}