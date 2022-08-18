//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// From https://github.com/llvm/llvm-project/blob/632ebc4ab4374e53fce1ec870465c587e0a33668/llvm/lib/MC/MCParser/COFFAsmParser.cpp
    /// </summary>
    [SymSource("coff")]
    public enum CoffDirectiveKind : byte
    {
        [Symbol(".text","")]
        Text,

        [Symbol(".data","")]
        Data,

        [Symbol(".bss")]
        Bss,

        [Symbol(".section","")]
        Section,

        [Symbol(".def","")]
        Def,

        [Symbol(".scl","")]
        Scl,

        [Symbol(".type","")]
        Type,

        [Symbol(".endef","")]
        Endef,

        [Symbol(".secrel32","")]
        SecRel32,

        [Symbol(".symidx","")]
        SymIdx,

        [Symbol(".safeseh","")]
        SafeSeh,

        [Symbol(".secidx","")]
        SecIdx,

        [Symbol(".linkonce","")]
        LinkOnce,

        [Symbol(".rva","")]
        Rva,

        [Symbol(".weak","")]
        Weak,

        [Symbol(".cg_profile","")]
        CgProfile
    }
}