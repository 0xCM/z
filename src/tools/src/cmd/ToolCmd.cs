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

        [CmdOp("jobs/run")]
        void RunCliJobs()
        {
            var src = AppDb.DotNetRoot().Files(FileKind.Dll).Map(x => new FileUri(x.Format())).ToSeq();
            var name = Cmd.identify<EcmaEmissionCmd>().Format();
            var ts = timestamp();
            var dst = AppDb.Jobs(Cmd.identify<EcmaEmissionCmd>().Format()).Path($"{name}.{ts}.jobs", FileKind.Json);
            var job = new EcmaEmissionCmd();
            job.JobId = ts;
            job.Sources = src;
            job.Targets = AppDb.DbTargets("tools/jobs").Folder(Cmd.identify<EcmaEmissionCmd>().Format());
            job.Settings = EcmaEmissionSettings.Default;
            
            var data = JsonData.serialize(job);
            FileEmit(data, dst);
        }

        [CmdOp("tool/cmd")]
        void ExecToolCmd(CmdArgs args)
        {
            var tool = TB.Tool(arg(args,0).Value);

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
        void RunTool(CmdArgs args)
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

        [CmdOp("tool/mklink")]
        void Link(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            var cmd = Tools.mklink(src,dst);            
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