//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemberRefInfo
    {
        const string TableId = "refs";

        [Render(12)]
        public CliToken Token;

        [Render(12)]
        public CliToken Parent;

        [Render(48)]
        public string Name;

        [Render(12)]
        public MemberRefKind RefKind;

        [Render(1)]
        public CliSig Sig;
    }
}