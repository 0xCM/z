//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public unsafe readonly struct NullArgMsg
    {
        [MethodImpl(Inline)]
        public static string format(string caller, string file, int? line)
            => string.Concat(MsgText, " | ", AppMsg.source(caller,file,line));

        public const string MsgText = "A null argument was provided";

        public static Func<string> Formatter
            => () => MsgText;

        public static Func<string, string, int?, string> Sourced
            => format;
    }
}