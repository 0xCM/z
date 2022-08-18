//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum WfPartKind : byte
    {
        None = 0,

        Step = 1,

        Event = 2,
    }
}