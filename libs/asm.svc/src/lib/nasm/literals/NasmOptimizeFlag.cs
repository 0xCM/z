//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x8;

    [Flags]
    public enum NasmOptimizeFlag : byte
    {
        None,

        [Symbol("O0", "no optimization")]
        O0 = P2ᐞ00,

        [Symbol("O1", "minimal optimization")]
        O1 = P2ᐞ01,

        [Symbol("Ox", "multipass optimization (default)")]
        Ox = P2ᐞ02,

        [Symbol("Ov", "display the number of passes executed at the end")]
        Ov = P2ᐞ03,
    }
}