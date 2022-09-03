//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum FlowGateKind : byte
    {
        None,

        And = 0b0001,

        Xor = 0b0110,

        Or = 0b0111,

        Not = 0b1010,

        Xnor = 0b1001,

        Nor = 0b1000,

        Nand = 0b1110,

        Mux = 0b11_0101,
    }
}