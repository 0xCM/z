//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class ApiDispatcher : IApiDispatcher
    {
        IApiOps Ops;

        readonly IWfChannel Channel;

        [MethodImpl(Inline)]
        public ApiDispatcher(IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers, IApiOps ops)
        {
            Ops = ops;
            Channel = channel;
        }

        public @string Name => "router";

        public Hash32 Hash => Name.Hash;
        
        public bool IsEmpty => false;
        
        public IApiOps Commands => Ops;

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            var result = Outcome.Success;
            if(Ops.Find(name, out var method))
                result = ApiCmd.exec(Channel, method, args);
            else
                result = (false, string.Format("Command '{0}' unrecognized", name));
            return result;
        }
    }
}