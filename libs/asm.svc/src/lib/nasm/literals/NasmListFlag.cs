//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x16;

    public enum NasmListFlag : ushort
    {
        None = 0,

        [Symbol("b", "Show builtin macro packages (standard and %use)")]
        b = P2ᐞ00,

        [Symbol("d", "Show byte and repeat counts in decimal, not hex")]
        d = P2ᐞ01,

        [Symbol("e", "Show the preprocessed output")]
        e = P2ᐞ02,

        [Symbol("f", "Ignore .nolist (force output)")]
        f = P2ᐞ03,

        [Symbol("m", "Show multi-line macro calls with expanded parmeters")]
        m = P2ᐞ04,

        [Symbol("p", "Output a list file every pass, in case of errors")]
        p = P2ᐞ05,

        [Symbol("s", "Show all single-line macro definitions")]
        s = P2ᐞ06,

        [Symbol("w", "Flush the output after every line")]
        w = P2ᐞ07,

        [Symbol("+", "Enable all listing options except -Lw")]
        plus = P2ᐞ08,
    }
}