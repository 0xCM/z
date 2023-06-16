//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NBK = NumericBaseKind;

    [SymSource("api", NBK.Base16), Flags]
    public enum OpDirection : byte
    {
        None = 0,

        [Symbol("in")]
        In = 1,

        [Symbol("out")]
        Out = 2,

        [Symbol("io")]
        IO = In | Out,
    }
}