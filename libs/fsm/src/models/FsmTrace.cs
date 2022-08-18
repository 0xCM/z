//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum FsmTrace
    {
        None = 0,

        Transitions = 1,

        Events = 2,

        Completions = 4,

        Errors = 8,

        All = Transitions | Events | Completions | Errors
    }
}