//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// From winnt.h
    /// </summary>
    [SymSource("coff")]
    public enum ImageRelocKind : ushort
    {
        [Symbol("IMAGE_REL_AMD64_ABSOLUTE"," Reference is absolute, no relocation is necessary")]
        AMD64_ABSOLUTE = 0x0000,

        [Symbol("IMAGE_REL_AMD64_ADDR64","64-bit address (VA)")]
        AMD64_ADDR64 =  0x0001,

        [Symbol("IMAGE_REL_AMD64_ADDR32","32-bit address (VA)")]
        AMD64_ADDR32 = 0x0002,

        [Symbol("IMAGE_REL_AMD64_ADDR32NB","32-bit address w/o image base (RVA)")]
        AMD64_ADDR32NB = 0x0003,

        [Symbol("IMAGE_REL_AMD64_REL32","32-bit relative address from byte following reloc")]
        AMD64_REL32 = 0x0004,

        [Symbol("IMAGE_REL_AMD64_REL32_1","32-bit relative address from byte distance 1 from reloc")]
        AMD64_REL32_1 = 0x0005,

        [Symbol("IMAGE_REL_AMD64_REL32_2","32-bit relative address from byte distance 2 from reloc")]
        AMD64_REL32_2 = 0x0006,

        [Symbol("IMAGE_REL_AMD64_REL32_3","32-bit relative address from byte distance 3 from reloc")]
        REL32_3 = 0x0007,

        [Symbol("IMAGE_REL_AMD64_REL32_4","32-bit relative address from byte distance 4 from reloc")]
        AMD64_REL32_4 = 0x0008,

        [Symbol("IMAGE_REL_AMD64_REL32_5","32-bit relative address from byte distance 5 from reloc")]
        AMD64_REL32_5 = 0x0009,

        [Symbol("IMAGE_REL_AMD64_SECTION","Section index")]
        AMD64_SECTION = 0x000A,

        [Symbol("IMAGE_REL_AMD64_SECREL","32 bit offset from base of section containing target")]
        AMD64_SECREL =  0x000B,

        [Symbol("IMAGE_REL_AMD64_SECREL7","7 bit unsigned offset from base of section containing target")]
        AMD64_SECREL7 = 0x000C,

        [Symbol("IMAGE_REL_AMD64_TOKEN","32 bit metadata token")]
        AMD64_TOKEN = 0x000D,

        [Symbol("IMAGE_REL_AMD64_SREL32","32 bit signed span-dependent value emitted into object")]
        AMD64_SREL32 = 0x000E,

        [Symbol("IMAGE_REL_AMD64_PAIR")]
        AMD64_PAIR = 0x000F,

        [Symbol("IMAGE_REL_AMD64_SSPAN32","32 bit signed span-dependent value applied at link time")]
        AMD64_SSPAN32 = 0x0010,

        [Symbol("IMAGE_REL_AMD64_EHANDLER")]
        AMD64_EHANDLER = 0x0011,

        [Symbol("IMAGE_REL_AMD64_IMPORT_BR","Indirect branch to an import")]
        AMD64_IMPORT_BR= 0x0012,

        [Symbol("IMAGE_REL_AMD64_IMPORT_CALL","Indirect call to an import")]
        AMD64_IMPORT_CALL = 0x0013,

        [Symbol("IMAGE_REL_AMD64_CFG_BR","Indirect branch to a CFG check")]
        AMD64_CFG_BR = 0x0014,

        [Symbol("IMAGE_REL_AMD64_CFG_BR_REX","Indirect branch to a CFG check, with REX.W prefix")]
        AMD64_CFG_BR_REX = 0x0015,

        [Symbol("IMAGE_REL_AMD64_CFG_CALL","Indirect call to a CFG check")]
        AMD64_CFG_CALL = 0x0016,

        [Symbol("IMAGE_REL_AMD64_INDIR_BR","Indirect branch to a target in RAX (no CFG)")]
        AMD64_INDIR_BR = 0x0017,

        [Symbol("IMAGE_REL_AMD64_INDIR_BR_REX","Indirect branch to a target in RAX, with REX.W prefix (no CFG)")]
        AMD64_INDIR_BR_REX = 0x0018,

        [Symbol("IMAGE_REL_AMD64_INDIR_CALL","Indirect call to a target in RAX (no CFG)")]
        AMD64_INDIR_CALL = 0x0019,

        [Symbol("IMAGE_REL_AMD64_INDIR_BR_SWITCHTABLE_FIRST","Indirect branch for a switch table using Reg 0 (RAX)")]
        AMD64_INDIR_BR_SWITCHTABLE_FIRST = 0x0020,

        [Symbol("IMAGE_REL_AMD64_INDIR_BR_SWITCHTABLE_LAST","Indirect branch for a switch table using Reg 15 (R15)")]
        AMD64_INDIR_BR_SWITCHTABLE_LAST = 0x002F,
    }
}