//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ApiMemberInfo : IComparableRecord<ApiMemberInfo>
    {
        public const string TableId = "api.members";

        public const byte FieldCount = 7;

        [Render(16)]
        public MemoryAddress EntryPoint;

        [Render(16)]
        public ApiClassKind ApiKind;

        [Render(16)]
        public CliToken Token;

        [Render(80)]
        public CliSig CliSig;

        [Render(120)]
        public utf8 DisplaySig;

        [Render(120)]
        public utf8 Uri;

        [Render(60)]
        public BinaryCode MsilCode;

        [MethodImpl(Inline)]
        public int CompareTo(ApiMemberInfo src)
            => EntryPoint.CompareTo(src.EntryPoint);
    }
}