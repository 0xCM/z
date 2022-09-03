//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmBlockSpec block(AsmBlockLabel label)
            => new AsmBlockSpec(AsmComment.Empty, label, sys.empty<AsmInstruction>());

        [MethodImpl(Inline), Op]
        public static AsmBlockSpec block(AsmBlockLabel label, params AsmInstruction[] content)
            => new AsmBlockSpec(AsmComment.Empty, label, content);

        [MethodImpl(Inline), Op]
        public static AsmBlockSpec block(AsmComment comment, AsmBlockLabel label, params AsmInstruction[] content)
            => new AsmBlockSpec(comment, label, content);
    }
}