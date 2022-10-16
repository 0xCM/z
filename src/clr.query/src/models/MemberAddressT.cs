//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MemberAddress<T>
        where T : IRuntimeMember
    {
        public readonly T Member;

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public MemberAddress(T member, MemoryAddress address)
        {
            Member = member;
            Address = address;
        }

        [MethodImpl(Inline)]
        public static implicit operator MemberAddress<T>(Paired<T,MemoryAddress> src)
            => new MemberAddress<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator MemberAddress(MemberAddress<T> src)
            => new MemberAddress(new ClrMember(src.Member.Definition), src.Address);
    }
}