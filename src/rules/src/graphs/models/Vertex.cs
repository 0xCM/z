//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class Vertex : IEquatable<Vertex>, IVertex
    {
        public readonly object Value;

        public readonly Seq<Vertex> Targets;

        [MethodImpl(Inline)]
        public Vertex(object value)
        {
            Value = value;
            Targets = new();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value?.GetHashCode() ?? 0;
        }

        object IVertex.Value
            => Value;

        Seq<Vertex> IVertex.Targets
            => Targets;

        public string Format()
            => Value.ToString();

        [MethodImpl(Inline)]
        public bool Equals(Vertex src)
            => Value.Equals(src.Value);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Vertex(uint key)
            => new Vertex(key);
    }
}