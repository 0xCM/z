//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum NasmDebugFormat : byte
    {
        None,

        Elf32 = 1,

        Elf64 = 2,

        Macho32 = 3,

        Macho64 = 4,

        Win32 = 5,

        Win64 = 6,
    }
}