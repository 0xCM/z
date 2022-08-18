//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public record struct RawMemberCode
    {
        const string TableId = "member.code.raw";

        public ApiToken Token;

        public Disp32 Disp;

        public AsmHexCode StubCode;

        public OpUri Uri;

        public JmpStub Stub;

        public MemoryAddress Entry;

        public MemoryAddress Target;

        public static RawMemberCode Empty => default;
    }
}