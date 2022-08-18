//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x16;

    [SymSource("coff")]
    public enum CoffSectionFlags : ushort
    {
        [Symbol("")]
        None = 0,

        [Symbol("b",".bss section")]
        b = P2ᐞ00,

        [Symbol("d","Data section")]
        d = P2ᐞ01,

        [Symbol("e","Section excluded from linking")]
        e = P2ᐞ02,

        [Symbol("n","Unloaded section")]
        n = P2ᐞ03,

        [Symbol("r","Readonly section")]
        r = P2ᐞ04,

        [Symbol("s","Shared section")]
        s = P2ᐞ05,

        [Symbol("w","Writable section")]
        w = P2ᐞ06,

        [Symbol("x","Executable section")]
        x = P2ᐞ07,

        [Symbol("y","Unreadable section")]
        y = P2ᐞ08,
    }
}