//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Dependency<K,T> : QuikGraph.IEdge<T>, IArrow<T>, IEquatable<Dependency<K,T>>, IComparable<Dependency<K,T>>
        where T : IEquatable<T>, IComparable<T>
        where K : unmanaged
    {
        public readonly K Kind;

        public readonly T Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public Dependency(K kind, T src, T dst)
        {
            Kind = kind;
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

        ulong KindValue
        {
            [MethodImpl(Inline)]
            get => core.bw64(Kind);
        }

        public bool Equals(Dependency<K,T> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target);

        public override int GetHashCode()
            => (int)alg.hash.combine(Source.GetHashCode(), Target.GetHashCode(), KindValue.GetHashCode());

        public override bool Equals(object src)
            => src is Dependency<K,T> a && Equals(a);

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(Dependency<K,T> src)
        {
            var k = KindValue.CompareTo(src.Kind);
            if(k == 0)
            {
                var m = Source.CompareTo(src.Source);
                if(m == 0)
                    return Target.CompareTo(src.Target);
                else
                    return m;
            }
            else
                return k;
        }

        [MethodImpl(Inline)]
        public static implicit operator Dependency<K,T>((K kind, T src, T dst) def)
            => new Dependency<K,T>(def.kind, def.src, def.dst);
    }
}