//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    [SymSource(asm)]
    public enum AsmModifierKind : byte
    {
        None = 0,

        [Symbol("{k1}")]
        k1,

        [Symbol("{k2}")]
        k2,

        [Symbol("{z}")]
        z,

        [Symbol("{k1}{z}")]
        k1z,

        [Symbol("{er}")]
        er,

        [Symbol("{sae}")]
        sae,
    }
}