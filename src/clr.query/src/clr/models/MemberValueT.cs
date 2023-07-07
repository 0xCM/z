//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct MemberValue<T>
    {
        public readonly Label Member;

        public readonly T Value;

        [MethodImpl(Inline)]
        public MemberValue(Label member, T value)
        {
            Member = member;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator MemberValue<T>(MemberValue src)
            => new (src.Member, src.Value);
    }
}