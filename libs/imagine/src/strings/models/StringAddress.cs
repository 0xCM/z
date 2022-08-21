//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = MemoryStrings;

    /// <summary>
    /// Specifies an address for a null-terminated unicode string
    /// </summary>
    public unsafe readonly struct StringAddress : IAddressable
    {
        [MethodImpl(Inline), Op]
        public static unsafe string format(StringAddress src)
            => new string(src.Address.Pointer<char>());

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public StringAddress(MemoryAddress location)
        {
            Address = location == 0 ? address(EmptyString) : location;
        }

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<char>(), Length);
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => MemoryStrings.length(this);
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Address.IsNonZero;
        }

        public Hash32 ContentHash
        {
            [MethodImpl(Inline)]
            get => hash(Chars);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(hash(Address),(uint)Size);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*2;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => api.render(this, ref i, dst);

        [MethodImpl(Inline)]
        public unsafe string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(StringAddress src)
            => Address.Equals(src.Address);

        MemoryAddress IAddressable.Address
            => Address;

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(StringAddress src)
            => src.Address;

        [MethodImpl(Inline)]
        public static explicit operator StringAddress(ulong src)
            => new StringAddress(src);

        [MethodImpl(Inline)]
        public static explicit operator StringAddress(MemoryAddress src)
            => new StringAddress(src);

        [MethodImpl(Inline)]
        public static implicit operator StringAddress(string src)
            => api.address(src);

        public static StringAddress Zero
        {
            [MethodImpl(Inline)]
            get => new StringAddress(0);
        }
    }
}