//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Tool : ITool, IDataString<Tool>
    {
        public readonly @string Name;

        [MethodImpl(Inline)]
        public Tool(@string name)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public Tool(Actor actor)
        {
            Name = actor.Name;
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

        public override int GetHashCode()
            => Hash;
    
        public string Format()
            => Name.Format();

        [MethodImpl(Inline)]
        public int CompareTo(Tool src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(Tool src)
            => Name.Equals(src.Name);

        public override string ToString()
            => Format();

        @string INamed.Name 
            => Name;

        [MethodImpl(Inline)]
        public static implicit operator Tool(Actor src)
            => new Tool(src);

        [MethodImpl(Inline)]
        public static implicit operator Actor(Tool src)
            => src.Name;

        [MethodImpl(Inline)]
        public static implicit operator Tool(string src)
            => new Tool(src);

        public static Tool Empty => default;
    }
}