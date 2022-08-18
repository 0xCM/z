//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum BitMaskKind : uint
    {
        None,

        Lsb = 1,

        Msb = 2,

        Jsb = Lsb | Msb,

        Central = 4,

        Cjsb = Central | Jsb,

        Parity,

        Index = 128,
    }
}