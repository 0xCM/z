//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed record class Tree<T>
        where T : IDataType, IExpr
    {
        public readonly T Value;

        public readonly Seq<Tree<T>> Children;

        [MethodImpl(Inline)]
        public Tree(T value)
        {
            Value = value;
            Children = sys.empty<Tree<T>>();
        }

        [MethodImpl(Inline)]
        public Tree(T value, Tree<T>[] src)
        {
            Value = value;
            Children = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value.Hash | hash(Children.View);
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
        public bool Equals(Tree<T> src)
            => Value.Equals(src.Value);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;
    }
}