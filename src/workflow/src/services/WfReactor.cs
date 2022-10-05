//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class WfReactor: CmdReactor<WfReactor,RunWf,CmdResult>
    {
        static ConcurrentDictionary<string,Action> _Lookup = new ConcurrentDictionary<string, Action>();

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