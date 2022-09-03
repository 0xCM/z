//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed record class NamedVertex<V>
        where V : IDataType<V>, IExpr
    {
        public readonly Name Name;

        public readonly V Value;

        public readonly Seq<Vertex<V>> Targets;

        [MethodImpl(Inline)]
        public NamedVertex(Name name, V value, params Vertex<V>[] targets)
        {
            Name = name;
            Value = value;
            Targets = targets;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value.Hash | hash(Name) | hash(Targets.View);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(NamedVertex<V> src)
            => Name == src.Name && Value.Equals(src.Value);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => string.Format("{0}({1})", Name, Value);

        public override string ToString()
            => Format();

        public int CompareTo(NamedVertex<V> src)
            => Name.CompareTo(src.Name);
    }
}