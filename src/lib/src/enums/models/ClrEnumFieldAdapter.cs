//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using R = System.Reflection;

    public readonly struct ClrEnumFieldAdapter : IRuntimeMember<ClrEnumFieldAdapter,FieldInfo>
    {
        public uint Index {get;}

        public FieldInfo Definition {get;}

        public ulong Value {get;}

        [MethodImpl(Inline)]
        public ClrEnumFieldAdapter(uint index, FieldInfo src, ulong value)
        {
            Index = index;
            Definition = src;
            Value = value;
        }

        public ClrArtifactKind Kind
        {
            [MethodImpl(Inline)]
            get => ClrArtifactKind.EnumField;
        }

        public ClrTypeAdapter RefinedType
        {
            [MethodImpl(Inline)]
            get => DeclaringType.Definition.GetEnumUnderlyingType();
        }

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public ClrMemberName Name
        {
            [MethodImpl(Inline)]
            get => Definition;
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
        public string Format()
            => Definition.Name;

        public override bool Equals(object obj)
            => Definition.Equals(obj);

        public override int GetHashCode()
            => Definition.GetHashCode();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(ClrEnumFieldAdapter a, ClrEnumFieldAdapter b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrEnumFieldAdapter a, ClrEnumFieldAdapter b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator FieldInfo(ClrEnumFieldAdapter src)
            => src.Definition;
    }
}