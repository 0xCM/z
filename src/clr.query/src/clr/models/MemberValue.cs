//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct MemberValue
    {
        public readonly Label Member;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public MemberValue(Label member, dynamic value)
        {
            Member = member;
            Value = value;
        }
    }
}