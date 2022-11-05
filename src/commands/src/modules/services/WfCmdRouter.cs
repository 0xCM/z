//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfCmdRouter : IWfDispatcher
    {
        IWfCmdSpecs _Commands;

        Func<string,CmdArgs,Outcome> Fallback;

        readonly IWfChannel Channel;

        ConstLookup<Name,WfOp> Catalog;

        [MethodImpl(Inline)]
        public WfCmdRouter(IWfChannel channel, ReadOnlySeq<ICmdProvider> providers, IWfCmdSpecs lookup)
        {
            _Commands = lookup;
            Fallback = NotFound;
            Channel = channel;
            Providers = providers;
            Catalog = Cmd.defs(this);
        }

        public ReadOnlySeq<ICmdProvider> Providers {get;}

        public @string Name => "router";

        public Hash32 Hash => Name.Hash;
        
        public bool IsEmpty => false;
        
        public IWfCmdSpecs Commands => _Commands;

        static Outcome NotFound(string cmd, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", cmd));

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            var result = Outcome.Success;
            var runner = default(IWfCmdRunner);
            if(Commands.Find(name, out runner))
            {
                result = runner.Run(Channel, args);
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