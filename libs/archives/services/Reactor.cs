//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class Reactor : AppService<Reactor>
    {
        CmdFlows Flows;

        protected override void Initialized()
        {
            Flows = CmdFlows.flows(Wf, Cmd.reactors(Wf));
        }

        public void Dispatch(CmdLine src)
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
    }
}