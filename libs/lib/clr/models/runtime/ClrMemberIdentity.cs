//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Identifies a metadata element
    /// </summary>
    public readonly struct ClrMemberIdentity : ITextual, IEquatable<ClrMemberIdentity>, INullity
    {
        readonly ulong Data;

        public CliToken OwnerId
        {
            [MethodImpl(Inline)]
            get => (uint)(Data >> 32);
        }

        public CliToken MemberId
        {
            [MethodImpl(Inline)]
            get => (uint)(Data);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        [MethodImpl(Inline)]
        internal ClrMemberIdentity(FieldInfo src)
            : this(src.DeclaringType.MetadataToken, src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        internal ClrMemberIdentity(PropertyInfo src)
            : this(src.DeclaringType.MetadataToken, src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        internal ClrMemberIdentity(MethodInfo src)
            : this(src.DeclaringType.MetadataToken, src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        internal ClrMemberIdentity(EventInfo src)
            : this(src.DeclaringType.MetadataToken, src.MetadataToken)
        {

        }

        [MethodImpl(Inline)]
        ClrMemberIdentity(uint owner, uint member)
            => Data = ((ulong)owner << 32) | (ulong)member;

        [MethodImpl(Inline)]
        internal ClrMemberIdentity(int owner, int member)
            : this((uint)owner, (uint)member)
        {

        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0}:{1}", OwnerId, MemberId);

        [MethodImpl(Inline)]
        public bool Equals(ClrMemberIdentity src)
            => Data == src.Data;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is ClrMemberIdentity t && Equals(t);

        [MethodImpl(Inline)]
        public static bool operator ==(ClrMemberIdentity x, ClrMemberIdentity y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrMemberIdentity x, ClrMemberIdentity y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberIdentity(FieldInfo src)
            => new ClrMemberIdentity(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberIdentity(PropertyInfo src)
            => new ClrMemberIdentity(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberIdentity(MethodInfo src)
            => new ClrMemberIdentity(src);

        public static ClrMemberIdentity Empty
            => default;
    }
}