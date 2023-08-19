//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct LocatedSymbol : IDataString<LocatedSymbol>
    {
        [MethodImpl(Inline)]
        public static LocatedSymbol anonymous(MemoryAddress location)
            => new (new SymAddress(0,location), Label.Empty);

        public readonly SymAddress Location;

        public readonly Label Name;

        [MethodImpl(Inline)]
        public LocatedSymbol(SymAddress address, Label name)
        {
            Name = name;
            Location = address;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty && Location.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty || Location.IsNonEmpty;
        }

        [MethodImpl(Inline)]

        public bool Equals(LocatedSymbol src)
            => Name.Address.Equals(src.Name.Address) && Location == src.Location;

        [MethodImpl(Inline)]
        public int CompareTo(LocatedSymbol src)
            => Location.CompareTo(src.Location);

        public string Format()
            => Name.IsNonEmpty ? string.Format("{0} ({1})", Location, Name) : Location.Format();

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Location.Hash | Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator LocatedSymbol(MemoryAddress src)
            => anonymous(src);

        public static LocatedSymbol Empty
        {
            [MethodImpl(Inline)]
            get => new LocatedSymbol(SymAddress.Zero, Label.Empty);
        }
    }
}