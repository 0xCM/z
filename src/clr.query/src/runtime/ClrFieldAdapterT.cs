//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using R = System.Reflection;

    public readonly struct ClrFieldAdapter<T> : IRuntimeMember<ClrFieldAdapter<T>,FieldInfo>
    {
        public FieldInfo Definition {get;}

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

        [MethodImpl(Inline)]
        public T GetValueDirect(TypedReference src)
            => sys.@as<object,T>(Definition.GetValueDirect(src));

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
        public static bool operator ==(ClrFieldAdapter<T> a, ClrFieldAdapter<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrFieldAdapter<T> a, ClrFieldAdapter<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator FieldInfo(ClrFieldAdapter<T> src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrFieldAdapter<T>(FieldInfo src)
            => new ClrFieldAdapter<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrFieldAdapter(ClrFieldAdapter<T> src)
            => new ClrFieldAdapter(src.Definition);
    }
}