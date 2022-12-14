//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.TypeAttributes;
    using static sys;

    [ApiHost]
    public ref struct EcmaFieldBuilder
    {
        readonly Span<MemberFieldSpec> Fields;

        ushort Index;

        [Op]
        public static EcmaFieldBuilder create(ushort? capacity = null)
            => new EcmaFieldBuilder(capacity ?? 20);

        [Op]
        public static FieldBuilder field(TypeBuilder tb, string name, string type, Address16? offset = null)
        {
            var fb = tb.DefineField(name, Type.GetType(type), FieldAttributes.Public);
            if(offset != null)
                fb.SetOffset(offset.Value);
            return fb;
        }

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

        const TypeAttributes Default = BeforeFieldInit | Public | Sealed | AnsiClass;

        public const TypeAttributes ExplicitAnsi
            = Default | ExplicitLayout;

        public const TypeAttributes SequentialAnsi
            = Default | SequentialLayout;

        [MethodImpl(Inline),Op]
        public EcmaFieldBuilder(uint capacity)
        {
            Index = 0;
            Fields = span<MemberFieldSpec>(capacity);
        }

        [MethodImpl(Inline),Op]
        public EcmaFieldBuilder WithField(in MemberFieldSpec src)
        {
            seek(Fields, Index++) = src;
            return this;
        }

        [MethodImpl(Inline),Op]
        public EcmaFieldBuilder WithField(PropertyInfo src)
            => WithField(new MemberFieldSpec(src.Name, src.PropertyType.Name, Index));

        [MethodImpl(Inline),Op]
        public EcmaFieldBuilder WithField(string name, Type type)
            => WithField(new MemberFieldSpec(name, type.Name, Index));

        [MethodImpl(Inline), Op]
        public EcmaFieldBuilder WithField(ClrFieldAdapter src)
            =>  WithField(new MemberFieldSpec(src.Name, src.FieldType.Name, Index));

        [MethodImpl(Inline), Op]
        public EcmaFieldBuilder WithFields(params PropertyInfo[] src)
        {
            foreach(var item in src)
                WithField(item);
            return this;
        }

        [MethodImpl(Inline), Op]
        public EcmaFieldBuilder WithFields(params FieldInfo[] src)
        {
            foreach(var item in src)
                WithField(item);
            return this;
        }

        [MethodImpl(NotInline), Op]
        public RecordSpec Complete(Identifier name)
        {
            var cells = Fields.Slice(0,(int)Index).ToArray();
            Fields.Clear();
            return new RecordSpec(name, cells);
        }
    }
}