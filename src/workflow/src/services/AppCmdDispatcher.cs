//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCmdDispatcher : IAppCmdDispatcher
    {
        IAppCommands _Commands;

        Func<string,CmdArgs,Outcome> Fallback;

        readonly IWfChannel Channel;

        [MethodImpl(Inline)]
        public AppCmdDispatcher(IWfChannel channel, ReadOnlySeq<ICmdProvider> providers, IAppCommands lookup)
        {
            _Commands = lookup;
            Fallback = NotFound;
            Channel = channel;
            Providers = providers;
        }

        public ReadOnlySeq<ICmdProvider> Providers {get;}

        public IAppCommands Commands => _Commands;

        static Outcome NotFound(string cmd, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", cmd));

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            var result = Outcome.Success;
            var runner = default(IAppCmdRunner);
            if(Commands.Find(name, out runner))
            {
                result = runner.Run(Channel,args);
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