//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct SymAddress : IDataString<SymAddress>
    {
        [MethodImpl(Inline), Op]
        public static SymAddress define(uint selector, MemoryAddress address)
            => new SymAddress(selector, address);

        public readonly uint Selector;

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public SymAddress(uint selector, MemoryAddress address)
        {
            Selector = selector;
            Address = address;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Selector == 0 && Address == 0u;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasSelector
        {
            [MethodImpl(Inline)]
            get => Selector != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (Hash32)Selector | Address.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => HasSelector ? string.Format("{0:x8}:{1:x6}h", Selector, (ulong)Address) : Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(SymAddress src)
            => Selector == src.Selector && Address == src.Address;

        [MethodImpl(Inline)]
        public int CompareTo(SymAddress src)
        {
            var result = Selector.CompareTo(src.Selector);
            if(result == 0)
                result = Address.CompareTo(src.Address);
            return result;
        }

        [MethodImpl(Inline)]
        public static implicit operator SymAddress((uint sel, MemoryAddress address) src)
            => new SymAddress(src.sel, src.address);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(SymAddress src)
            => src.Address;

        public static SymAddress Zero => default;
    }
}