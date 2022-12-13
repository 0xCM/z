//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Dependency<T> : QuikGraph.IEdge<T>, IArrow<T>, IEquatable<Dependency<T>>, IComparable<Dependency<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly T Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public Dependency(T src, T dst)
        {
            Source = src;
            Target = dst;
        }

        T IArrow<T,T>.Source
            => Source;

        T IArrow<T,T>.Target
            => Target;

        T QuikGraph.IEdge<T>.Source
            => Source;

        T QuikGraph.IEdge<T>.Target
            => Target;

        public bool Equals(Dependency<T> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target);

        public override int GetHashCode()
            => sys.hash(Source.GetHashCode(),Target.GetHashCode());

        public override bool Equals(object src)
            => src is Dependency<T> a && Equals(a);

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(Dependency<T> src)
        {
            var a = Source.CompareTo(src.Source);
            if(a != 0)
                return a;
            return Target.CompareTo(src.Target);
        }

        [MethodImpl(Inline)]
        public static implicit operator Dependency<T>((T src, T dst) def)
            => new Dependency<T>(def.src, def.dst);
    }
}