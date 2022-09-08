//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct ApiDecoderStats : IExpr
    {
        public static ApiDecoderStats init()
            => new ApiDecoderStats();

        public uint MemberCount;

        public uint HostCount;

        public uint PartCount;

        public uint InstCount;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => InstCount == 0;
        }

        public string Format()
            => string.Format(RP.PSx4, PartCount, HostCount, MemberCount, InstCount);

        public override string ToString()
            => Format();
    }
}