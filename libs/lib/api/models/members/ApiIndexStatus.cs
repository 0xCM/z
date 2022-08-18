//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ApiIndexStatus : IRecord<ApiIndexStatus>, ITextual
    {
        public const string TableId = "api-index.status";

        public PartId[] Parts;

        public ApiHostUri[] Hosts;

        public MemoryAddress[] Addresses;

        public Count MemberCount;

        public PartCodeAddresses Encoded;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.PSx5, Parts.Length, Hosts.Length, MemberCount, Addresses.Length, Encoded.Count);

        public override string ToString()
            => Format();
    }
}