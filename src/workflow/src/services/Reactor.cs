//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class Reactor : CmdReactor<Reactor,RunWf,CmdResult>
    {
        [Op]
        public static Index<ICmdReactor> discover(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }        

        static ConcurrentDictionary<string,Action> _Lookup = new ConcurrentDictionary<string, Action>();

        CmdFlows Flows;

        protected override void Initialized()
        {
            Flows = CmdFlows.flows(Wf, discover(Wf));
        }

        public void Run(CmdLine src)
        {
            var args = src.Parts;
            if(args.IsEmpty)
                return;

            var cmd = new RunScriptCmd();
            var name =  first(args).Content;
            var path = args.Length >= 2 ? args[1].Content : EmptyString;
            cmd.ScriptPath = FS.path(path);
            Flows.Run(cmd);
        }

        public Task<CmdResult> Start(CmdLine src)
        {
            var args = src.Parts;
            if(args.IsEmpty)
                return sys.start(() => CmdResult.Empty);

            var cmd = new RunScriptCmd();
            var name =  first(args).Content;
            var path = args.Length >= 2 ? args[1].Content : EmptyString;
            cmd.ScriptPath = FS.path(path);
            return Flows.Start(cmd);
        }

        // public static CmdResult<ListFilesCmd,Files> exec(ListFilesCmd cmd)
        // {
        //     var _list = Z0.DbArchive.search(cmd.SourceDir, cmd.Extensions, cmd.EmissionLimit);
        //     var outcome = Z0.DbArchive.emissions(_list, cmd.FileUriMode, cmd.TargetPath);
        //     return outcome ? CmdResults.ok(cmd,_list) : CmdResults.fail(cmd, outcome.Message);
        // }

        [Op]
        public static void assign(string name, Action handler)
        {
            if(!_Lookup.TryAdd(name, handler))
                @throw(string.Format("{0}:Unable to include {1}", "Cmd", name));
        }

        public static bool find(RunWf cmd, out Action handler)
            => _Lookup.TryGetValue(cmd.WorkflowName, out handler);

        [Op]
        public static bool find(string name, out RunWf cmd)
        {
            if(_Lookup.ContainsKey(name))
            {
                cmd = name;
                return true;
            }
            else
            {
                cmd = RunWf.Empty;
                return false;
            }
        }

        protected override CmdResult Run(RunWf cmd)
        {
            if(find(cmd, out var handler))
            {
                handler();
                return CmdResults.ok(cmd, string.Format("Executed <{0}> workflow", cmd.WorkflowName));
            }
            return CmdResults.fail(cmd, "Handler not found");
        }
    }
}