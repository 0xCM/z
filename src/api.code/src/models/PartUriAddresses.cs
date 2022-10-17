//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using LU = System.Collections.Generic.Dictionary<MemoryAddress,OpUri>;

    public readonly struct PartUriAddresses
    {
        readonly LU Data;

        [MethodImpl(Inline)]
        public PartUriAddresses(LU src)
        {
            Data = src;
        }

        public Index<OpUri> Identities
        {
            [MethodImpl(Inline)]
            get => Data.Values.Array();
        }

        public Index<MemoryAddress> Addresses
        {
            [MethodImpl(Inline)]
            get => Data.Keys.Array();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public static PartUriAddresses Empty
        {
            [MethodImpl(Inline)]
            get => new PartUriAddresses(new LU());
        }
    }
}