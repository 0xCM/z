//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class ToolCmd : AppCmdService<ToolCmd>
    {
        ImageRegions Regions => Wf.ImageRegions();

        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.BuildCmd(),
                };


        [CmdOp("memory/regions")]
        void EmitRegions()
            => Regions.EmitRegions(Process.GetCurrentProcess(), ApiPacks.create());

        [CmdOp("api/emit/impls")]
        void EmitImplMaps()
        {
            var src = Clr.impls(Parts.Lib.Assembly, Parts.Lib.Assembly);
            using var writer = AppDb.ApiTargets().Path("api.impl.maps", FileKind.Map).Utf8Writer();
            for(var i=0; i<src.Count; i++)
                src[i].Render(s => writer.WriteLine(s));
        }

        // public static ToolCmd commands(IWfRuntime wf)
        //     => create(wf, providers(wf));

        Tooling Tooling => Wf.Tooling();

        static readonly Toolbase TB = new();

        [CmdOp("env/modules")]
        void ListModules()
        {
            var src = ImageMemory.modules(ExecutingPart.Process);
            var dst = AppDb.AppData().Targets(tables).Path($"process.modules.{timestamp()}", FileKind.Csv);
            var formatter = Tables.formatter<ProcessModuleRow>();
            for(var i=0; i<src.Length; i++)
                Row(formatter.Format(src[i]));
            TableEmit(src, dst);
        }

        [CmdOp("tools")]
        void ListTools()
        {
            var tools = TB.Tools();
            var dst = AppDb.App().Path("tools",FileKind.Env);
            var emitting = Emitter.EmittingFile(dst);
            var counter = 0u;
            var indent = 0u;
            using var emitter = dst.Emitter();
            for(var i=0; i<tools.Count; i++)
            {
                ref readonly var tool = ref tools[i];
                var location = tool.Location;                
                var docs = tool.Docs().Files();
                emitter.AppendLine(RP.PageBreak120);
                emitter.AppendLine($"Tool={tool.Name},");             
                emitter.AppendLine($"Home={tool.Location.Root},");
                
                if(docs.Count != 0)
                {
                    emitter.AppendLine("Docs={");
                    
                    indent += 4;

                    core.iteri(docs.View, (i,doc) => emitter.IndentLine(indent, $"{text.quote(doc.ToUri())},"));
                    counter += (4 + docs.Count);
                    indent -= 4;
                    emitter.AppendLine("},");
                }

                var envpath = tool.Location.Path(tool.Name, FileKind.Env);
                if(envpath.Exists)
                {
                    emitter.AppendLine($"ConfigPath={text.quote(envpath.ToUri())},");
                    var settings = Tooling.settings(envpath);
                    emitter.WriteLine("Settings={");
                    indent += 4;
                    emitter.Write(settings.Format(indent));
                    emitter.WriteLine("}");
                    indent -= 4;
                    counter += 2*6;
                }
            }

            EmittedFile(emitting, counter);
        }

        [CmdOp("tool/cmd")]
        void ExecToolCmd(CmdArgs args)
        {
            var tool = TB.Tool(arg(args,0).Value);

        }

        [CmdOp("tools/env")]
        void ShowToolEnv()
            => iter(Tooling.LoadEnv(), s => Write(s));

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => Tooling.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => Tooling.Setup(Tooling.tool(args));

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(Tooling.LoadDocs(arg(args,0).Value), doc => Write(doc));

        [CmdOp("tool/env")]
        void ToolConfig(CmdArgs args)
        {
            var tool = TB.Tool(arg(args,0).Value);
            var path = tool.EnvPath();
            var settings = Tooling.settings(path);
            Row(settings.Format());
        }

        [CmdOp("tool/mklink")]
        void Link(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            var cmd = Tools.mklink(src,dst);            
        }
    }
}