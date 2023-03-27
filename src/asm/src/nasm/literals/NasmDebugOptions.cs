//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x16;
    using static NasmDebugFormat;

    [Flags]
    public enum NasmDebugOptions : ushort
    {
        None = 0,

        g = P2ᐞ01,

        Elf32DbgFormat = P2ᐞ03 << Elf32,

        Elf64DbgFormat = P2ᐞ04 << Elf64,

        Macho32DbgFormat = P2ᐞ05 << Macho32,

        Macho64DbgFormat = P2ᐞ06 << Macho64,

        Win32DbgFormat = P2ᐞ07 << Win32,

        Win64DbgFormat = P2ᐞ08 << NasmDebugFormat.Win64,
    }
}