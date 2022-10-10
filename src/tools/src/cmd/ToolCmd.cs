//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class ToolCmd : AppCmdService<ToolCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.BuildCmd(),
                };

        [CmdOp("api/emit/impls")]
        void EmitImplMaps()
        {
            var src = Clr.impls(Parts.Lib.Assembly, Parts.Lib.Assembly);
            using var writer = AppDb.ApiTargets().Path("api.impl.maps", FileKind.Map).Utf8Writer();
            for(var i=0; i<src.Count; i++)
                src[i].Render(s => writer.WriteLine(s));
        }

        public new static ToolCmd create(IWfRuntime wf)
            => create(wf, providers(wf));

        Tooling Tooling => Wf.Tooling();

        static readonly Toolbase TB = new();

        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
        }

        void RunJobs(string match)
        {
            var paths = AppDb.Service.Jobs().Files();
            var counter = 0u;
            for(var i=0; i<paths.Count; i++)
            {
                ref readonly var path = ref paths[i];
                if(path.FileName.Format().StartsWith(match))
                {
                    var dispatching = Running(string.Format("Dispatching job {0} defined by {1}", counter, path.ToUri()));
                    DispatchJobs(path);
                    Ran(dispatching, string.Format("Dispatched job {0}", counter));
                    counter++;
                }
            }

            if(counter == 0)
                Warn($"No jobs identified by '{match}'");
        }


        [CmdOp("pwsh")]
        void RunPwshCmd(CmdArgs args)
        {
            var cmd = Cmd.pwsh(Cmd.join(args));
            Status($"Executing '{cmd}'");
            ProcExec.start(cmd,Channel);
        }

        [CmdOp("devenv")]
        void DevEnv(CmdArgs args)
            => ProcExec.start(Channel, Cmd.args("devenv.exe",args[0].Value));

        [CmdOp("cmd")]
        void RunCmd(CmdArgs args)
            => ProcExec.start(Channel, args);

        [CmdOp("help")]
        void GetHelp(CmdArgs args)
        {
            var tool = args[0].Value;
            var dst = AppDb.DbTargets("tools/help").Path(FS.file(tool, FileKind.Help));
            Toolsets.help(Channel, args, dst);
        }

        [CmdOp("tool")]
        void RunTool(CmdArgs args)
        {
            var tool = arg(args,0).Value;
            var script = arg(args,1).Value;
            var count = args.Count - 2;
            var _args = count > 0 ? sys.alloc<string>(count) : sys.empty<string>();
            var path = AppDb.Toolbase($"{tool}/scripts").Path(FS.file(script,FileKind.Cmd));
            var emitter = text.emitter();
            var j=2;
            for(var i=0; i<count; i++, j++)
            {
                emitter.Append(Chars.Space);
                emitter.Append(args[i].Value);
            }
            
            var cmd = Cmd.cmd(path, CmdKind.Tool, emitter.Emit());        
            ProcExec.start(cmd, Channel);        
        }

        [CmdOp("hexify")]
        void Hexify(CmdArgs args)
        {
            var src = arg(args,0).Value;
            var pattern = arg(args,1).Value;
            var files = FS.files(FS.dir(src),pattern,true);
            var dst = AppDb.DbTargets("hexify");
            Hex.hexify(Channel, files, dst);
            //iter(files, file => Write(file));
        }

        [CmdOp("tool/shim")]
        void RunShim(CmdArgs args)
        {
            var count = args.Length;
            if(count < 3)
            {
                Error($"Not enough");
                return;                
            }

            var values = args.Values().View;
            var def = ToolShims.validate(ToolShims.parse(slice(values,0,3).ToArray()));            
            var ops = slice(values,3).ToArray();
            var task = ToolShims.start(def,Emitter,slice(values,3).ToArray());
        }

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => Tooling.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => Tooling.Setup(Cmd.tool(args));

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(Tooling.LoadDocs(arg(args,0).Value), doc => Write(doc));

        [CmdOp("tool/env")]
        void ToolConfig(CmdArgs args)
        {
            var tool = TB.Tool(arg(args,0).Value);
            var path = tool.CfgPath();
            var settings = Cmd.settings(path);
            Row(settings.Format());
        }

        [CmdOp("symlink")]
        void Link(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            var cmd = Tools.symlink(src,dst);
            //ProcExec.run(Channel, Cmd.script(CmdFormat.format(cmd)));

        }

        [CmdOp("child")]
        void Child(CmdArgs args)
        {
            Demand.neq<uint>(args.Count,0);
            var path = FS.path(args.First);
            var _args = sys.slice(args.Values().View,1).ToArray();
            ProcExec.passthrough(path,Emitter,_args);
        }
    }
}