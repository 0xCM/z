//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(0x0A), Record(TableId), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct MemberRef
        {
            const string TableId = "refs";

            [Render(12)]
            public EcmaToken Token;

            [Render(12)]
            public EcmaToken Parent;

            [Render(48)]
            public string Name;

            [Render(12)]
            public MemberRefKind RefKind;

            [Render(1)]
            public EcmaSig Sig;
        }

    }
}