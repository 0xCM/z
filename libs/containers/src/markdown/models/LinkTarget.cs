//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct LinkTarget<T> : ILinkTarget<LinkTarget<T>,T>
        {
            public readonly T Destination;

            [MethodImpl(Inline)]
            public LinkTarget(T dst)
            {
                Destination = dst;
            }

            T ILinkTarget<LinkTarget<T>,T>.Destination
                => Destination;

            public string Format()
                => Destination.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator LinkTarget<T>(T src)
                => new LinkTarget<T>(src);
        }
    }
}