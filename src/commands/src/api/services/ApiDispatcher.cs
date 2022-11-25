//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class ApiDispatcher : IApiDispatcher
    {
        IApiOps Ops;

        Func<string,CmdArgs,Outcome> Fallback;

        readonly IWfChannel Channel;

        ConstLookup<Name,ApiOp> Catalog;

        [MethodImpl(Inline)]
        public ApiDispatcher(IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers, IApiOps ops)
        {
            Ops = ops;
            Fallback = NotFound;
            Channel = channel;
            Catalog = Cmd.defs(this);
        }

        public @string Name => "router";

        public Hash32 Hash => Name.Hash;
        
        public bool IsEmpty => false;
        
        public IApiOps Commands => Ops;

        static Outcome NotFound(string cmd, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", cmd));

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            var result = Outcome.Success;
            var method = default(ApiOp);
            if(Ops.Find(name, out method))
            {
                result = ApiCmd.run(Channel,method, args);
            }
            else
            {
                if(Fallback != null)
                    result = Fallback(name, args);
                else
                    result = (false, string.Format("Command '{0}' unrecognized", name));
            }

            return result;
        }
    }
}