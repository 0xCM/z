//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using R = System.Reflection;

    public readonly struct ClrFieldAdapter : IRuntimeMember<ClrFieldAdapter,FieldInfo>
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrFieldAdapter> adapt(FieldInfo[] src)
            => adapt<FieldInfo,ClrFieldAdapter>(src);

        [MethodImpl(Inline), Op]
        static ReadOnlySpan<V> adapt<S,V>(S[] src)
            => sys.recover<S,V>(sys.@readonly(src));

        public readonly FieldInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrFieldAdapter(FieldInfo src)
            => Definition = src;

        public ClrArtifactKind Kind
        {
            [MethodImpl(Inline)]
            get => ClrArtifactKind.Field;
        }

        public bool IsStatic
        {
            [MethodImpl(Inline)]
            get => Definition.IsStatic;
        }

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Definition.Name;
        }

        public ClrTypeAdapter FieldType
        {
            [MethodImpl(Inline)]
            get => Definition.FieldType;
        }

        public R.FieldAttributes Attributes
        {
            [MethodImpl(Inline)]
            get => Definition.Attributes;
        }

        public ClrTypeAdapter DeclaringType
        {
            [MethodImpl(Inline)]
            get => Definition.DeclaringType;
        }

        public bool IsLiteral
        {
            [MethodImpl(Inline)]
            get => Definition.IsLiteral;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Definition.FieldHandle.Value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Definition is null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public object GetValue(object src)
            => Definition.GetValue(src);

        [MethodImpl(Inline)]
        public object GetValueDirect(TypedReference src)
            => Definition.GetValueDirect(src);

        [MethodImpl(Inline)]
        public string Format()
            => Definition.Name;

        public override bool Equals(object obj)
            => Definition.Equals(obj);

        public override int GetHashCode()
            => Definition.GetHashCode();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(ClrFieldAdapter a, ClrFieldAdapter b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrFieldAdapter a, ClrFieldAdapter b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator FieldInfo(ClrFieldAdapter src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrFieldAdapter(FieldInfo src)
            => new ClrFieldAdapter(src);
    }
}