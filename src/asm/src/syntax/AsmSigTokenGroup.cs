//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmSigTokenGroup : TokenGroup<AsmSigTokenGroup,AsmSigTokenKind>
    {
        const string Group = "asm.sigs";

        public override string GroupName
            => Group;



    }
}