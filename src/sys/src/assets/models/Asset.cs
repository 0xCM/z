//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Asset : IAsset<Asset>
    {
        public readonly AssetName Name;

        public readonly MemoryAddress Address;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public Asset(AssetName name, MemoryAddress address, ByteSize size)
        {
            Name = name;
            Address = address;
            Size = size;
        }

        ByteSize ISized.ByteCount
            => Size;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Address == 0 || Size == 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Address.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public BitWidth BitWidth
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        public MemorySeg Segment
        {
            [MethodImpl(Inline)]
            get => new MemorySeg(Address, Size);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset src)
            => sys.view(src.Address, src.Size);

        public ReadOnlySpan<byte> ResBytes
        {
            [MethodImpl(Inline)]
            get => sys.view(Address, Size);
        }

        [MethodImpl(Inline)]
        public bool NameLike(string match)
            => Name.Contains(match);

        [MethodImpl(Inline)]
        public int CompareTo(Asset src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public bool Equals(Asset src)
            => Address.Equals(src.Address);

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx3, Address, Size, Name);

        public override string ToString()
            => Format();

        MemoryAddress IAddressable.Address
            => Address;

        public static Asset Empty
            => new Asset(AssetName.Empty, 0, 0);
    }
}