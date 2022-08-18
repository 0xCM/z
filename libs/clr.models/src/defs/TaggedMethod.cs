//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TaggedMethod<A>
        where A : Attribute
    {
        public readonly MethodInfo Method;

        public readonly A Tag;

        [MethodImpl(Inline)]
        public TaggedMethod(MethodInfo method, A tag)
        {
            Method = method;
            Tag = tag;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Tag == null;
        }

        [MethodImpl(Inline)]
        public static implicit operator TaggedMethod<A>((MethodInfo method, A tag) src)
            => new TaggedMethod<A>(src.method, src.tag);

        public static TaggedMethod<A> Empty
        {
            [MethodImpl(Inline)]
            get => new TaggedMethod<A>(EmptyVessels.EmptyMethod, default);
        }
    }
}