//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WfCmdRouter : IWfDispatcher
    {
        public static CmdUriSeq supported<S>(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var part = src.Controller;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<defs.Count; i++)
                seek(dst,i) = defs[i].Uri;
            return dst;            
        }

        public static void dispatch(IWfContext context, FilePath defs)
        {
            if(defs.Missing)
            {
                context.Channel.Error(AppMsg.FileMissing.Format(defs));
            }
            else
            {
                var lines = defs.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(WfCmd.parse(content, out AppCmdSpec spec))
                    {
                        context.Dispatcher.Dispatch(spec.Name, spec.Args);
                    }
                    else
                    {
                        context.Channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }

        public @string Name => "router";

        public Hash32 Hash => Name.Hash;
        
        public bool IsEmpty => false;
        
        IAppCommands _Commands;

        Func<string,CmdArgs,Outcome> Fallback;

        readonly IWfChannel Channel;

        ConstLookup<Name,WfCmdMethod> Catalog;

        [MethodImpl(Inline)]
        public WfCmdRouter(IWfChannel channel, ReadOnlySeq<ICmdProvider> providers, IAppCommands lookup)
        {
            _Commands = lookup;
            Fallback = NotFound;
            Channel = channel;
            Providers = providers;
            Catalog = WfCmd.defs(this);
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