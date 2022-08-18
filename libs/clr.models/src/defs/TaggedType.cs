//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TaggedType<A>
        where A : Attribute
    {
        public readonly Type Type;

        public readonly A Tag;

        [MethodImpl(Inline)]
        public TaggedType(Type type, A tag)
        {
            Type = type;
            Tag = tag;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Tag == null;
        }

        [MethodImpl(Inline)]
        public static implicit operator TaggedType<A>((TypeInfo Type, A tag) src)
            => new TaggedType<A>(src.Type, src.tag);

        public static TaggedType<A> Empty
        {
            [MethodImpl(Inline)]
            get => new TaggedType<A>(EmptyVessels.EmptyType, default);
        }
    }
}