//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MemberAddress : IComparable<MemberAddress>
    {
        public readonly ClrMember Member;

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public MemberAddress(ClrMember member, MemoryAddress address)
        {
            Member = member;
            Address = address;
        }

        public string Format()
            => string.Format("{0}: {1}", Address, Member.Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(MemberAddress src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public static implicit operator MemberAddress(Paired<ClrMember,MemoryAddress> src)
            => new MemberAddress(src.Left, src.Right);
    }
}