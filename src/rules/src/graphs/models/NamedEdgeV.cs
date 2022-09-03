//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed record class NamedEdge<V> : IEdge<V>, IEquatable<NamedEdge<V>>
        where V : IEquatable<V>, IExpr, IHashed
    {
        public readonly Name Name;

        public readonly V Source;

        public readonly V Target;

        [MethodImpl(Inline)]
        public NamedEdge(Name name, V src, V dst)
        {
            Name = name;
            Source = src;
            Target = dst;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | hash(Source) | hash(Target);
        }

        V IArrow<V, V>.Source
            => Source;

        V IArrow<V, V>.Target
            => Target;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(NamedEdge<V> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target) && Name.Equals(src.Name);

        public string Format()
            => string.Format("{0}:{1} -> {2}", Name, Source, Target);

        public override string ToString()
            => Format();
    }
}