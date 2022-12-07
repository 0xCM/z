//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class ApiDispatcher : IApiDispatcher
    {
        readonly IApiOps Ops;

        readonly IWfChannel Channel;

        [MethodImpl(Inline)]
        public ApiDispatcher(IWfChannel channel, IApiOps ops)
        {
            Ops = ops;
            Channel = channel;
        }

        public IApiOps Commands => Ops;

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            if(Ops.Find(name, out var method))
                return ApiCmd.exec(Channel, method, args);
            else
                return (false, string.Format("Command '{0}' unrecognized", name));
        }
    }
}