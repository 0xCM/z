//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using KVP = KeyValuePairs<MemoryAddress,ApiCodeBlock>;

    public readonly struct PartCodeAddresses
    {
        public readonly Index<PartId> Parts;

        readonly KVP Data;

        [MethodImpl(Inline)]
        public PartCodeAddresses(PartId[] parts, KVP src)
        {
            Data = src;
            Parts = parts;
        }

        public Index<ApiCodeBlock> Code
        {
            [MethodImpl(Inline)]
            get => Data.Values;
        }

        public Index<MemoryAddress> Addresses
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public ApiCodeBlock this[MemoryAddress src]
        {
            [MethodImpl(Inline)]
            get => Data[src];
        }

        public static PartCodeAddresses Empty
        {
            [MethodImpl(Inline)]
            get => new PartCodeAddresses(core.array<PartId>(), KVP.Empty);
        }
    }
}