//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe struct ResourceAddress : IDataType<ResourceAddress>, ILocatable<MemoryAddress>, IDataString
    {
        public readonly MemoryAddress Location;

        [MethodImpl(Inline)]
        public ResourceAddress(ulong location)
        {
            Location = location;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Location.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Location.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Location.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Location.Format();

        public override string ToString()
            => Format();

        public int CompareTo(ResourceAddress src)
            => Location.CompareTo(src.Location);

        public bool Equals(ResourceAddress src)
            => Location.Equals(src.Location);

        MemoryAddress ILocatable<MemoryAddress>.Location 
            => Location;

        [MethodImpl(Inline)]
        public static implicit operator ResourceAddress(ulong src)
            => new ResourceAddress(src);
    }
}