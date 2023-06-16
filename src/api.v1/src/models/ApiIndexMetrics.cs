//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public record struct ApiIndexMetrics
    {
        public const string TableId = "api.index.metrics";

        public uint HostCount;

        public uint AddressCount;

        public uint BlockCount;

        public uint IdentityCount;

        public ByteSize ByteCount;
    }
}