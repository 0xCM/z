//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrMember : IRuntimeMember<ClrMember, MemberInfo>
    {
        [MethodImpl(Inline)]
        public static ClrMember from(MemberInfo src)
            => new ClrMember(src);

        public MemberInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrMember(MemberInfo src)
            => Definition = src;

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

        MemberInfo IRuntimeObject<MemberInfo>.Definition
            => Definition;

        ClrArtifactKind IClrArtifact.Kind
            => throw new NotImplementedException();

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
        public static bool operator ==(ClrMember a, ClrMember b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrMember a, ClrMember b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator MemberInfo(ClrMember src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrMember(MemberInfo src)
            => new ClrMember(src);
    }
}