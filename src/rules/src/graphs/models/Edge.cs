//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Edge : IEquatable<Edge>, IEdge<Vertex>
    {
        public readonly Vertex Source {get;}

        public readonly Vertex Target {get;}

        [MethodImpl(Inline)]
        public Edge(Vertex src, Vertex dst)
        {
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out Vertex src, out Vertex dst)
        {
            src = Source;
            dst = Target;
        }

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        [MethodImpl(Inline)]
        public bool Equals(Edge src)
            => Source == src.Source && Target == src.Target;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)alg.hash.combine(Source.GetHashCode(), Target.GetHashCode());

        public override bool Equals(object src)
            => src is Edge e && Equals(e);

        [MethodImpl(Inline)]
        public static implicit operator Edge((Vertex src, Vertex dst) x)
            => new Edge(x.src, x.dst);

        [MethodImpl(Inline)]
        public static bool operator ==(Edge a, Edge b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Edge a, Edge b)
            => !a.Equals(b);
    }
}