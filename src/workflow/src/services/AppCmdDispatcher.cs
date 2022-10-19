//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCmdDispatcher : IAppCmdDispatcher
    {
        public static void exec(IWfContext context, FilePath src)
        {
            if(src.Missing)
            {
                context.Channel.Error(AppMsg.FileMissing.Format(src));
            }
            else
            {
                var lines = src.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(AppCmd.parse(content, out AppCmdSpec spec))
                    {
                        //Dispatch(spec.Name, spec.Args);
                    }
                    else
                    {
                        context.Channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }

        IAppCommands _Commands;

        Func<string,CmdArgs,Outcome> Fallback;

        readonly IWfChannel Channel;

        ConstLookup<Name,AppCmdMethod> Catalog;

        [MethodImpl(Inline)]
        public AppCmdDispatcher(IWfChannel channel, ReadOnlySeq<ICmdProvider> providers, IAppCommands lookup)
        {
            _Commands = lookup;
            Fallback = NotFound;
            Channel = channel;
            Providers = providers;
            Catalog = AppCmd.defs(this);
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