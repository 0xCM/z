//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public record class CollectedCodeExtract
    {
        public ApiToken Token;

        public AsmHexCode StubCode;

        public Disp32 Disp;

        public BinaryCode TargetExtract;

        public CollectedCodeExtract()
        {
            Token = ApiToken.Empty;
            StubCode = AsmHexCode.Empty;
            Disp = 0;
            TargetExtract = BinaryCode.Empty;
        }

        public CollectedCodeExtract(in RawMemberCode raw, BinaryCode extracted)
        {
            Token = raw.Token;
            StubCode = raw.StubCode;
            Disp = raw.Disp;
            TargetExtract = extracted;
        }

        public static CollectedCodeExtract Empty => new();
    }
}