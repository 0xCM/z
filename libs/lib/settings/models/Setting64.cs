//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout)]
    public readonly record struct Setting64 : IDataType<Setting64>, IDataString<Setting64>
    {
        public readonly Name Name;

        public readonly asci64 Value;

        [MethodImpl(Inline)]
        public Setting64(Name name, asci64 value)
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
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | Value.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(Setting64 src)
            => Name == src.Name && Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(Setting64 src)
        {
            var result = Name.CompareTo(src.Name);
            if(result==0)
                result = Value.CompareTo(src.Value);
            return result;
        }

        public string Format()
            => $"{Name}:{Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Setting64 ((Name name, asci64 value) src)
            => new Setting64(src.name,src.value);

        public static Setting64 Empty => default;

    }
}