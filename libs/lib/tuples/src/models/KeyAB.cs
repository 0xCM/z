//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly struct Key<A,B> : IHashed
    {
        public readonly Paired<A,B> Content;

        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        public Key(A a, B b)
        {
            Content = (a,b);
            Hash = hash(a) | hash(b);
        }

        [MethodImpl(Inline)]
        public Key(Paired<A,B> src)
        {
            Content = src;
            Hash = hash(src.Left) | hash(src.Right);
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => string.Format("<{0},{1}>", Content.Left, Content.Right);

        public override string ToString()
            => Format();

       Hash32 IHashed.Hash
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Key<A,B>((A a, B b) src)
            => new Key<A,B>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator Key<A,B>(Paired<A,B> src)
            => new Key<A,B>(src);

    }
}