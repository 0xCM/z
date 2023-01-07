//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Handlers
{
    [CmdRoute(Route)]
    sealed class DevNul : CmdHandler
    {
        public const string Route = "dev/null";

        public override void Run(CmdArgs args)
            => Channel.Error($"Handler not found: {args}");
    }
}