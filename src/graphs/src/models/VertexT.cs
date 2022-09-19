//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed record class Vertex<T>
        where T : IDataType, IExpr
    {
        public readonly T Value;

        public readonly Seq<Vertex<T>> Targets;

        [MethodImpl(Inline)]
        public Vertex(T value)
        {
            Value = value;
            Targets = sys.empty<Vertex<T>>();
        }

        [MethodImpl(Inline)]
        public Vertex(T value, Vertex<T>[] src)
        {
            Value = value;
            Targets = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value.Hash | hash(Targets.View);
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

        public string Format()
            => Value.Format();

        [MethodImpl(Inline)]
        public bool Equals(Vertex<T> src)
            => Value.Equals(src.Value);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;
    }
}