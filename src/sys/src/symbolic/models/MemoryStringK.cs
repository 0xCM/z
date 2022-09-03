//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct MemoryString<K> : IMemoryString<K>
        where K : unmanaged
    {
        public readonly MemoryAddress Address;

        public readonly int Length;

        public readonly uint Size;

        [MethodImpl(Inline)]
        public MemoryString(MemoryAddress address, int length)
        {
            Address = address;
            Length = length;
            Size = (uint)length*Sized.size<K>();
        }

        public unsafe ReadOnlySpan<K> Cells
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<K>(), Length);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => recover<K,byte>(Cells);
        }

        public byte CellSize
        {
            [MethodImpl(Inline)]
            get => (byte)size<K>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Cells.Length;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Address.Hash;
        }

        MemoryAddress IAddressable.Address
            => Address;

        public override int GetHashCode()
            => Hash;

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);

        public string Format()
        {
            var dst = EmptyString;
            if(CellSize == 1)
                Unsupported.raise<K>();
            else if(CellSize == 2)
                dst = new string(sys.recover<char>(Bytes));
            else
                Unsupported.raise<K>();
            return dst;
        }

        public override string ToString()
            => Format();

        public bool Equals(MemoryString<K> src)
            => Bytes.SequenceEqual(src.Bytes);

        public int CompareTo(MemoryString<K> src)
            => sys.cmp(Format(), src.Format());
    }
}