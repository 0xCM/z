//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Identifies a resource of parametric type along with a reference to the memory segment it occupies
    /// </summary>
    public readonly record struct Asset<T> : IComparable<Asset<T>>, IAddressable
    {
        public readonly string Name;

        public readonly MemorySeg Segment;

        [MethodImpl(Inline)]
        public Asset(Identifier name, MemorySeg seg)
        {
            Name = name;
            Segment = seg;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Segment.BaseAddress;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Size/CellSize;
        }

        public ByteSize CellSize
        {
            [MethodImpl(Inline)]
            get => size<T>();
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Segment.Length;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Address.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(Asset<T> src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public bool Equals(Asset<T> src)
            => Address.Equals(src.Address);

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.PSx3, Address, Size, Name);

        public override string ToString()
            => Format();

        public static Asset<T> Empty
            => new Asset<T>(Identifier.Empty, MemorySeg.Empty);
    }
}