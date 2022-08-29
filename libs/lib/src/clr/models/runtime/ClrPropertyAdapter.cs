//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrPropertyAdapter : IRuntimeMember<ClrPropertyAdapter, PropertyInfo>
    {
        public PropertyInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrPropertyAdapter(PropertyInfo data)
            => Definition = data;

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public ClrMemberName Name
        {
            [MethodImpl(Inline)]
            get => Definition;
        }

        public ClrArtifactKind Kind
            => ClrArtifactKind.Property;

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
        public string Format()
            => Definition.Name;

        PropertyInfo IRuntimeObject<PropertyInfo>.Definition
            => Definition;

        public override bool Equals(object obj)
            => Definition.Equals(obj);

        public override int GetHashCode()
            => Definition.GetHashCode();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(ClrPropertyAdapter lhs, ClrPropertyAdapter rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrPropertyAdapter lhs, ClrPropertyAdapter rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static implicit operator PropertyInfo(ClrPropertyAdapter src)
            => src.Definition;
    }
}