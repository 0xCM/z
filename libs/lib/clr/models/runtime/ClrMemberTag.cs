//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Pairs a member attribute value with its target
    /// </summary>
    public readonly struct ClrMemberTag<M,A>
        where M : MemberInfo
        where A : Attribute
    {
        /// <summary>
        /// The target member
        /// </summary>
        public readonly M Member;

        /// <summary>
        /// The tag value
        /// </summary>
        public readonly A Tag;

        [MethodImpl(Inline)]
        public ClrMemberTag(M member, A tag)
        {
            Member = member;
            Tag = tag;
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberTag<M,A>((M member, A tag) src)
            => new ClrMemberTag<M,A>(src.member, src.tag);
    }
}