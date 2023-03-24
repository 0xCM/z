//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class ApiDispatcher : ICmdDispatcher
    {
        readonly ICmdMethods Ops;

        readonly IWfChannel Channel;

        [MethodImpl(Inline)]
        public ApiDispatcher(IWfChannel channel, ICmdMethods ops)
        {
            Ops = ops;
            Channel = channel;
        }

        public ICmdMethods Commands => Ops;

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            if(Ops.Find(name, out var fx))
                return ApiServers.exec(Channel, fx, args);
            else
                return (false, string.Format("Command '{0}' unrecognized", name));
        }
    }
}