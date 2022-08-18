//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x32;

    [Flags]
    public enum NasmOptionKind : uint
    {
        None = 0,

        [Symbol("-o", "Specifies output file name")]
        o = P2ᐞ00,

        [Symbol("-f", "Selects output file format")]
        f = P2ᐞ01,

        [Symbol("-l", "")]
        l = P2ᐞ02,

        [Symbol("-X", "Selects error reporting format")]
        X = P2ᐞ03,

        [Symbol("-@", "Specifies a response file")]
        Response,
    }
}