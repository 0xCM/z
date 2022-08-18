//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly record struct Setting<K,V> : IComparable<Setting<K,V>>, IDataType<Setting<K,V>>, ISetting<K,V>
        where K : unmanaged, IDataType, IExpr, IComparable<K>
    {
        public readonly K Name;

        public readonly V Value;

        [MethodImpl(Inline)]
        public Setting(K name, V value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash |  hash(Value);
        }

        public string Format(char sep)
            => $"{Name}{sep}{Value}";

        public int CompareTo(Setting<K,V> src)
            => Name.CompareTo(src.Name);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Format(Chars.Eq);

        public override string ToString()
            => Format();

        public static Setting<K,V> Empty => default;

        V ISetting<V>.Value
            => Value;

        K INamed<K>.Name
            => Name;
    }
}