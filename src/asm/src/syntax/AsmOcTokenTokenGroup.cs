//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using TK = AsmOcTokenKind;
    using G = AsmOcTokenTokenGroup;

    [ApiHost]
    public class AsmOcTokenTokenGroup : TokenGroup<G,TK>
    {
        const string Group = "asm.opcodes";

        public override string GroupName
            => Group;
    }
}