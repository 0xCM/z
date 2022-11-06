//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct KeySpec : IDataType<KeySpec>
    {
        public readonly @string Accessor;

        public readonly @string Name;

        public KeySpec(string accessor, string name)
        {
            Accessor = accessor;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty || Accessor.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty && Accessor.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Accessor,Name);
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"accessor:'{Accessor}', name:'{Name}'";

        public override string ToString()
            => Format();

        public bool Equals(KeySpec src)
            => Accessor == src.Accessor && Name == src.Name;

        public int CompareTo(KeySpec src)
        {
            var result = Accessor.CompareTo(src.Accessor);
            if(result == 0)
                result = Name.CompareTo(src.Name);
            return result;
        }
    }
}