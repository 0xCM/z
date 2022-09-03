//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum LiteralUsage : byte
    {
        None = 0,

        Address = 1,

        Identifier = 2
    }
}