//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [SymSource(api_kinds), Flags]
    public enum FpErrorMode
    {
        /// <summary>
        /// Raise exceptions upon error
        /// </summary>
        Raise = 0,

        /// <summary>
        /// Suppress exceptions upon error
        /// </summary>
        Suppress = 8
    }
}