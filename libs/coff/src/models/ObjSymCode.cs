//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// https://llvm.org/docs/CommandGuide/llvm-nm.html
    /// </summary>
    [SymSource("coff")]
    public enum ObjSymCode : byte
    {
        None = 0,

        [Symbol("a", "Absolute symbol")]
        a = 1,

        [Symbol("A", "Absolute symbol")]
        A = 2,

        [Symbol("b", ".bss section")]
        b = 3,

        [Symbol("B", "Uninitialized data (bss) object")]
        B = 4,

        [Symbol("C", "Common symbol. Multiple definitions link together into one definition")]
        C = 5,

        [Symbol("d", "Writable data object (.data)")]
        d = 6,

        [Symbol("D", "Writable data object")]
        D = 7,

        [Symbol("i", "COFF: .idata symbol or symbol in a section with IMAGE_SCN_LNK_INFO set")]
        i = 8,

        [Symbol("l", "COFF: .idata symbol or symbol in a section with IMAGE_SCN_LNK_INFO set")]
        l = 9,

        [Symbol("n", "ELF: local symbol from non-alloc section | COFF: Debug symbol")]
        n = 0xA,

        [Symbol("N", "ELF: debug section symbol, or global symbol from non-alloc section | Mach-O: absolute symbol or symbol from a section other than __TEXT_EXEC __text, __TEXT __text, __DATA __data, or __DATA __bss")]
        N = 0xB,

        [Symbol("r", "Read-only data section")]
        r = 0xC,

        [Symbol("R", "Read-only data object")]
        R = 0xD,

        [Symbol("s", "ELF: debug section symbol, or global symbol from non-alloc section | Mach-O: absolute symbol or symbol from a section other than __TEXT_EXEC __text, __TEXT __text, __DATA __data, or __DATA __bss")]
        s = 0xE,

        [Symbol("S", "ELF: debug section symbol, or global symbol from non-alloc section | Mach-O: absolute symbol or symbol from a section other than __TEXT_EXEC __text, __TEXT __text, __DATA __data, or __DATA __bss")]
        S = 0xF,

        [Symbol("t", ".text section")]
        t = 0x10,

        [Symbol("T", "Code (text) object")]
        T = 0x11,

        [Symbol("u", "ELF: GNU unique symbol")]
        u = 0x12,

        [Symbol("U", "Named object is undefined in this file")]
        U = 0x13,

        [Symbol("v", "ELF: Undefined weak object. It is not a link failure if the object is not defined")]
        v = 0x14,

        [Symbol("V", "ELF: Defined weak object symbol")]
        V = 0x15,

        [Symbol("w", "Undefined weak symbol other than an ELF object symbol. It is not a link failure if the symbol is not defined")]
        w = 0x16,

        [Symbol("W", "Defined weak symbol other than an ELF object symbol")]
        W = 0x17,

        [Symbol("-", "Mach-O: N_STAB symbo")]
        N_STAB = 0x18,
    }
}