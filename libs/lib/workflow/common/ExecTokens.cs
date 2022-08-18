// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static Root;

    public sealed class ExecTokens : ConcurrentDictionary<ulong,ExecToken>
    {
        [MethodImpl(Inline)]
        public static ExecTokens init()
            => new ExecTokens();
    }
}