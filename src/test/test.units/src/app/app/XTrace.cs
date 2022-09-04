//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    static partial class XQueue
    {
        public static string prefix(object title, Type host, string caller)
            => string.Concat(ExecutingPart.Name.Format(), Chars.FSlash, host.Name, Chars.FSlash, caller, Chars.LBrace, title, Chars.RBrace).PadRight(60);

        public static IAppMsg message(object title, object msg, Type host, string caller, FlairKind color)
            => AppMsg.colorize(string.Concat(prefix(title, host, caller), Chars.Pipe, Chars.Space, msg), color);

        public static IAppMsg TraceMsg(object msg, Type host, string caller, FlairKind color)
            => message(string.Empty, msg, host, caller, color);

        public static void Deposit(this IMessageQueue dst, IAppMsg msg)
            => dst.NotifyConsole(msg);

        public static void Deposit(this IMessageQueue dst, object msg, Type host, [CallerName] string caller = null)
            => Deposit(dst, TraceMsg(msg, host, caller, FlairKind.Running));

        public static void Deposit(this IMessageQueue dst, string title, object msg, FlairKind color, Type host, [CallerName] string caller = null)
            => Deposit(dst, message(title, msg, host, caller, color));

        public static void Deposit(this IMessageQueue dst, string title, string msg, Type host, [CallerName] string caller = null)
            => Deposit(dst, message(title, msg, host, caller, FlairKind.Running));
    }
}