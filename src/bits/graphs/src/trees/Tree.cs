//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class Tree : IEquatable<Tree>, ITree
    {
        public readonly object Value;

        public readonly Seq<Tree> Children;

        [MethodImpl(Inline)]
        public Tree(object value)
        {
            Value = value;
            Children = new();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value?.GetHashCode() ?? 0;
        }


        Seq<Tree> ITree.Children
            => Children;

        public string Format()
            => Value.ToString();

        [MethodImpl(Inline)]
        public bool Equals(Tree src)
            => Value.Equals(src.Value);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Tree(uint key)
            => new Tree(key);
    }
}