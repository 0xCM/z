//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmFileSpec file(Identifier name, params IAsmSourcePart[] parts)
            => new AsmFileSpec(name, parts);
    }
}