//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Actor : IDataType<Actor>, IActor
    {
        public readonly Name Name;

        [MethodImpl(Inline)]
        public Actor(Name name)
        {
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        Name INamed.Name 
            => Name;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(Actor src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(Actor src)
            => Name.Equals(src.Name);

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Actor(string src)
            => new Actor(src);

        [MethodImpl(Inline)]
        public static implicit operator Actor(Name src)
            => new Actor(src);

        public static Actor Empty => default;

    }
}