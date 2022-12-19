//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;
    using Types;

    using static sys;

    public class WfAppCmd : WfAppCmd<WfAppCmd>
    {
        ArchiveRegistry ArchiveRegistry => Wf.ArchiveRegistry();

        ProjectScripts ProjectScripts => Wf.ProjectScripts();

        ProcessMemory ProcessMemory => Wf.ProcessMemory();

        Tooling Tooling => Wf.Tooling();

        ApiMd ApiMd => Wf.ApiMd();


        [CmdOp("api/tablegen")]
        void GenRecords()
        {
            var generator = Wf.CsvTableGen();
            var buffer = text.emitter();
            var src = ApiAssemblies.Parts;
            var defs = TableDefs.defs(src);
            iter(defs, src => generator.Emit(0u,src,buffer));
            var dst = AppDb.CgStage("api.tables").Path("replicants", FileKind.Cs);
            FileEmit(buffer.Emit(),dst);         
        }

        [CmdOp("api/emit")]
        void ApiEmit()
            => ApiMd.Emitter(AppDb.ApiTargets()).Emit(ApiAssemblies.Parts);

        [CmdOp("api/types")]
        void EmitApiTypes()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitApiTypes(ApiAssemblies.Parts);

        [CmdOp("api/tables")]
        void EmitApiTables()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitApiTables(ApiAssemblies.Parts);

        [CmdOp("version")]
        void Version()
            => Channel.Row($"[z0.{ExecutingPart.Name}-v{ExecutingPart.Assembly.AssemblyVersion()}]({ExecutingPart.Assembly.Path().ToUri()})");

        [CmdOp("types/systems")]
        void TypeSys()
        {
            var src = TypeSystems.typedefs(ApiAssemblies.Parts);
            iter(src, s => {
                Channel.Row(s);
            });
        }

        [CmdOp("help")]
        void GetHelp(CmdArgs args)
        {
            var tool = args[0].Value;
            var dst = AppDb.DbTargets("tools/help").Path(FS.file(tool, FileKind.Help));
            //CmdRunner.run(Channel, tool, args.Length > 1 ? args[1].Value : "--help", dst);
        }

        [CmdOp("archives")]        
        void ListArchives(CmdArgs args)
            => Emitter.Row(AppDb.Archives().Folders().Delimit(Eol));

        [CmdOp("archives/list")]        
        void ArchiveFiles(CmdArgs args)
        {
            var src = AppDb.Archive(arg(args,0).Value);
            iter(src.Files(true), file => Write(file.ToUri()));
        }

        [CmdOp("tokens/types")]
        void TokenTypes()
        {
            var types = Tokens.types(ApiAssemblies.Parts);
            ApiMd.Emitter(Archives.archive(Env.cd() + FS.folder(".data"))).EmitTypeList(types, FS.file("tokens.types", FileKind.List));
        }

        [CmdOp("tokens/opcodes")]
        void AsmOpCodes()
        {
            var src = AsmOcTokens.create();
            var tokens = src.Tokens;
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var token = ref tokens[i];
                Write(token.Format());
            }
        }

        [CmdOp("tokens/list")]
        void Tokenize(CmdArgs args)
        {
            var tokens = Tokens.tokenize<Asm.AsmPrefixKind>();
            var count = tokens.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var token = ref tokens[i];
                var data = text.parenthetical(text.join(Chars.Comma, 
                    token.Index, token.Kind, @string(token.Name), @string(token.Expr)));
                Channel.Row(data);
                //Channel.Row($"{token.Index},{token.Kind},{sys.@string(token.Name)}, {sys.@string(token.Expr)});
            }
        }

            
        [CmdOp("env/paths")]
        void ProcPaths()
        {
            var src = Env.process().ToLookup();
            var names = src.Keys;
            var dst = text.emitter();
            iter(names, name => {
                dst.AppendLine(src[name]);
            });

            Channel.Row(dst.Emit());
        }

        void CalcRelativePaths()
        {
            var @base = FS.dir("dir1");
            var files = FS.dir("dir2").AllFiles;
            var links = Markdown.links(@base,files);
            iter(links, r=> Write(r.Format()));
        }

        [CmdOp("scripts")]
        void Scripts(CmdArgs args)
            => iter(ProjectScripts.List(args), path => Emitter.Write(path.ToUri()));

        [CmdOp("scripts/cmd")]
        void Script(CmdArgs args)
            => ProjectScripts.Start(args);

        [CmdOp("jobs/types")]
        void ListJobTypes()
        {
            var db = AppSettings.DbRoot();
            Write(db.Root);
            Write(RpOps.PageBreak80);
            var jobs = db.Sources("jobs");
            Write($"Jobs: {jobs.Root}");

            jobs.Root.Folders(true).Iter(f => Write(f.Format()));
        }

        [CmdOp("app/deploy")]
        void Deploy()
        {
            var dst = AppDb.Tools("z0/cmd").Targets().Root;
            var src = ExecutingPart.Assembly.Path().FolderPath;
            Archives.copy(Channel, src, dst);
        }

        [CmdOp("settings")]
        void ReadSettings(CmdArgs args)
        {
            if(args.IsEmpty)
                Channel.Row(AppSettings.Format());
            else
                Channel.Row(AppSettings.absorb(FS.path(args.First.Value)));
        }

        [CmdOp("services")]
        void GetServices()
        {
            Write(ApiRuntime.services(ApiAssemblies.Parts));
        }

        [CmdOp("archives/register")]
        void RegisterWorkspace(CmdArgs args)
        {
            ArchiveRegistry.Register(arg(args,0).Value, FS.dir(arg(args,1).Value));
            var entries = ArchiveRegistry.Entries();            
        }

        [CmdOp("env/mem-physical")]
        void WorkingSet()
            => Write(((ByteSize)Environment.WorkingSet));

        [CmdOp("memory/query")]
        void QueryMemory(CmdArgs args)
        {            
            var @base = ExecutingPart.Process.Adapt().BaseAddress;
            if(args.Count != 0)
            {
                var result = DataParser.parse(args[0].Value, out @base);
                if(result.Fail)
                {
                    Channel.Error($"Could not parse ${args[0].Value} as an address");
                    return;
                }
            }

            var basic = default(MEMORY_BASIC_INFORMATION);
            WinMem.vquery(@base, ref basic);
            Channel.Write(basic.ToString());
        }

        [CmdOp("memory/info")]
        void ShowMemory()
        {
            var info = WinMem.basic();
            var formatter = Tables.formatter<BasicMemoryInfo>(16,RecordFormatKind.KeyValuePairs);
            Channel.Row(formatter.Format(info));
        }

        [CmdOp("memory/emit")]
        void EmitRegions()
            => ProcessMemory.EmitRegions(Process.GetCurrentProcess(), ApiPacks.create());

        [CmdOp("nuget/pkg")]
        void NugetFiles(CmdArgs args)
            => Archives.nupkg(Channel, args);

        [CmdOp("nuget/stage")]
        void DevPack(CmdArgs args)
            => DevPacks.stage(Channel, PackageKind.Nuget, FS.dir(arg(args,0)));

        [CmdOp("api/emit/impls")]
        void EmitImplMaps()
        {
            var src = Clr.impls(Parts.Lib.Assembly, Parts.Lib.Assembly);
            using var writer = AppDb.ApiTargets().Path("api.impl.maps", FileKind.Map).Utf8Writer();
            for(var i=0; i<src.Count; i++)
                src[i].Render(s => writer.WriteLine(s));
        }

        [CmdOp("tool")]
        void RunTool(CmdArgs args)
        {
            var tool = arg(args,0).Value;
            var script = arg(args,1).Value;
            var count = args.Count - 2;
            var path = AppDb.Toolbase($"{tool}/scripts").Path(FS.file(script,FileKind.Cmd));
            var emitter = text.emitter();
            var j=2;
            for(var i=0; i<count; i++, j++)
            {
                emitter.Append(Chars.Space);
                emitter.Append(args[i].Value);
            }
            
            CmdProcess.start(Channel, Cmd.cmd(path, CmdKind.Tool, emitter.Emit()));        
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

        [CmdOp("dev")]
        void LaunchCmdTerm(CmdArgs args)
        {
            var channel = Channel;
            void OnA(string msg)
            {
                channel.Row(msg, FlairKind.Data);
            }

            void OnB(string msg)
            {
                channel.Row(msg, FlairKind.StatusData);
            }
            
            if(args.Count == 0)
            {
                var wd = Env.cd();
                var options = $"-NoLogo -i -wd {text.dquote(Env.cd())}";
                CmdRunner.start(channel, new SysIO(OnA,OnB), CmdArgs.create("pwsh.exe", options), wd);
            }
        }

        [CmdOp("api/calls/check")]
        void CheckApiCalls()
        {
            CheckMullo(Rng.@default());
        }

        [CmdOp("api/catalog")]
        void EmitApiCatalog()
        {
            var src = ApiRuntime.catalog();
            var parts = src.Parts;
            var hosts = src.PartHosts();
            var catalogs = src.PartCatalogs;
            var assemblies = src.Assemblies;

            var counter = 0u; 
            iter(parts, part => {
                Channel.Row(string.Format("{0:D6} | {1,-24} | {2,-16} {3}", counter++, part.Owner.GetSimpleName(), part.Owner.AssemblyVersion(), part.Owner.Path()));
            });

            counter=0u;
            iter(hosts, host => {
                Channel.Row(string.Format("{0:D6} | {1,-16} | {2}", counter++, host.Assembly.GetSimpleName(), host.HostUri));
            });            
        }

        void CheckMullo(IBoundSource Source)
        {
            var @class = ApiClassKind.MulLo;
            var key = ApiKeys.key(Parts.Math.Resolved.Name, 1, @class);
            var count = 12;
            var left = Source.Array<uint>(count,100,200);
            var right = Source.Array<uint>(count,100,200);
            var dst = alloc<uint>(count);
            var results = alloc<ApiCall<uint,uint,uint>>(count);
            var output = alloc<uint>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var a = ref skip(left,i);
                ref readonly var b = ref skip(right,i);
                seek(dst,i) = cpu.mullo(a,b);
                seek(output,i) = math.mul(a,b);
                seek(results, i) = ApiCalls.call(key, a, b, skip(dst,i));
            }

            for(var i=0; i<count; i++)
            {
                Channel.Row(skip(results,i).Format() + " | " + skip(output,i).ToString());
            }
        }            

        [CmdOp("api/packs/list")]
        void ListApiPacks()
        {
            var src = ApiPacks.discover();
            for(var i=0; i<src.Count; i++)
            {
                Channel.Write($"{i}", src[i].Timestamp);
            }
        }

        [CmdOp("api/pack/list")]
        Outcome ListApiPack(CmdArgs args)
        {
            var result = Outcome.Failure;
            var src = ApiPacks.discover();
            var pack = default(IApiPack);
            if(args.Count > 0)
            {
                result = DataParser.parse(arg(args,0), out int i);
                if(result)
                {
                    var count = src.Length;
                    if(i<count-1)
                    {
                        pack = src[i];
                        result = true;
                    }
                }
            }
            else
            {
                if(src.Count >= 0)
                {
                    pack = src.Last;
                    result = true;
                }
            }

            if(result)
            {
                var listing = Archives.listing(pack.Files());
                var dst = AppDb.AppData().PrefixedTable<ListedFile>($"api.pack.{pack.Timestamp}");
                Channel.TableEmit(listing, dst);
            }

            return result;
        }
    }
}