//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("xed"), DataWidth(4)]
    public enum XedMapNumber : byte
    {
        [Symbol("0")]
        MAP0=0,

        [Symbol("1")]
        MAP1=1,

        [Symbol("2")]
        MAP2=2,

        [Symbol("3")]
        MAP3=3,

        [Symbol("8")]
        MAP8=8,

        [Symbol("8")]
        MAP9=9,

        [Symbol("10")]
        MAP10=10
    }
}