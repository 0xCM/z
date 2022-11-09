//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.TypeAttributes;
    using static sys;

    [ApiHost]
    public readonly struct RecordBuilder
    {
        const TypeAttributes Default = BeforeFieldInit | Public | Sealed | AnsiClass;

        [Op]
        public static ushort offset(Type host, FieldInfo field)
            => (ushort)Marshal.OffsetOf(host, field.Name);

        [Op]
        public static void offsets(Type src, Span<ushort> dst)
        {
            var fields = span(src.DeclaredFields());
            offsets(src,fields,dst);
        }

        [Op]
        public static void offsets(Type src, ReadOnlySpan<FieldInfo> fields, Span<ushort> dst)
        {
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(dst,i) = offset(src,f);
            }
        }

        [Op]
        public static ushort[] offsets(Type host, Index<FieldInfo> fields)
            => fields.Select(f => offset(host,f));

        public const TypeAttributes ExplicitAnsi
            = Default | ExplicitLayout;

        public const TypeAttributes SequentialAnsi
            = Default | SequentialLayout;

        [MethodImpl(Inline), Op]
        public static RecordSpec table(Identifier type, params ColumnSpec[] Fields)
            => new RecordSpec(type, Fields);

        [MethodImpl(Inline), Op]
        public static ColumnSpec field(Identifier name, Identifier type, ushort position, ushort offset = default)
            => new ColumnSpec(name, type, position, offset);

        [Op]
        public static TypeBuilder type(ModuleBuilder mb, Identifier fullName, TypeAttributes attributes, Type parent)
            => mb.DefineType(fullName, attributes, parent);

        [Op]
        public static TypeBuilder valueType(ModuleBuilder mb, Identifier fullName, TypeAttributes attributes)
            => mb.DefineType(fullName, attributes, typeof(ValueType));

        [Op]
        public static System.Reflection.Emit.FieldBuilder field(TypeBuilder tb, Identifier name, Identifier type, uint? offset = null)
        {
            var fb = tb.DefineField(name.Format(), Type.GetType(type.Format()), FieldAttributes.Public);
            if(offset != null)
                fb.SetOffset((int)offset.Value);
            return fb;
        }

        [Op]
        public static ModuleBuilder module(AssemblyName name)
        {
            var ab = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
            return ab.DefineDynamicModule("Primary");
        }

        [Op]
        public static RecordSpec clone(Type src)
        {
            Identifier name = src.Name;
            var declared = src.DeclaredInstanceFields();
            var count = declared.Length;
            var buffer = alloc<ColumnSpec>(count);
            var fields = @readonly(declared);
            var fieldOffsets = span(offsets(src, declared));
            var dst = span(buffer);
            for(ushort i=0; i<count; i++)
            {
                ref readonly var f = ref skip(fields, i);
                var offset = skip(fieldOffsets,i);
                seek(dst,i) = field(f.Name, f.FieldType.Name, i, skip(fieldOffsets,i));
            }

            return new RecordSpec(name, buffer);
        }

        /// <summary>
        /// Manufactures the type that reifies a supplied record definition
        /// </summary>
        /// <param name="spec">The record definition</param>
        [MethodImpl(NotInline),Op]
        public static Type type(AssemblyName assname, RecordSpec spec)
            => build(module(assname), spec);

        /// <summary>
        /// Manufactures the types that reify supplied record definitions
        /// </summary>
        /// <param name="spec">The record definition</param>
        [MethodImpl(NotInline), Op]
        public static Type[] types(AssemblyName assname, params RecordSpec[] specs)
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
        static Type build(ModuleBuilder mb, RecordSpec spec)
        {
            var tb = valueType(mb, spec.TypeName, ExplicitAnsi);
            var fields = spec.Fields;
            foreach(var f in fields)
                field(tb, f.Name, f.DataType, f.Offset);
            var type = tb.CreateType();
            return type;
        }
    }
}