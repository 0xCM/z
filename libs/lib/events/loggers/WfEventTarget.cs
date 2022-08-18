//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static IWfEventTarget ToTarget(this WfEventLogger src, Type host)
            => new WfEventTarget(host, src );
    }

    public readonly struct WfEventTarget : IWfEventTarget
    {
        readonly WfEventLogger Logger;

        public readonly Type Host;

        Type IWfEventTarget.Host
            => Host;

        [MethodImpl(Inline)]
        public WfEventTarget(Type host, WfEventLogger logger)
        {
            Host = host;
            Logger = logger;
        }

        [MethodImpl(Inline)]
        public void Deposit(IWfEvent src)
            => Logger(src);
    }
}