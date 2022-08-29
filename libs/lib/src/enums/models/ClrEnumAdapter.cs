//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrEnumAdapter
    {
        [MethodImpl(Inline)]
        public static ClrEnumAdapter adapt(Type src)
            => new ClrEnumAdapter(src);

        [MethodImpl(Inline)]
        public static ClrEnumAdapter<E> adapt<E>()
            where E : unmanaged, Enum
                => default;

        public Type Definition {get;}

        [MethodImpl(Inline)]
        public ClrEnumAdapter(Type src)
            => Definition = src;

        public CliToken Id
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public ClrTypeName Name
        {
            [MethodImpl(Inline)]
            get => Definition;
        }

        public ClrStructAdapter RefinedType
        {
            [MethodImpl(Inline)]
            get => new ClrStructAdapter(Definition.GetEnumUnderlyingType());
        }

        [MethodImpl(Inline)]
        public string Format()
            => Definition.FullName;

        [MethodImpl(Inline)]
        public bool Equals(ClrEnumAdapter src)
            => Definition.Equals(src.Definition);

        public ReadOnlySpan<ClrFieldAdapter> Members
        {
            [MethodImpl(Inline)]
            get => ClrFieldAdapter.adapt(Definition.LiteralFields());
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ClrTypeAdapter(ClrEnumAdapter src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator Type(ClrEnumAdapter src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumAdapter(Type src)
            => new ClrEnumAdapter(src);
    }
}