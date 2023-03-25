//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;
    using Microsoft.CodeAnalysis;
    using System.Linq;

    using static sys;

    [StructLayout(LayoutKind.Sequential,Size=8)]
    public readonly record struct HANDLE
    {

    }

    public unsafe class WfAppCmd : WfAppCmd<WfAppCmd>
    {        
        ArchiveRegistry ArchiveRegistry => Wf.ArchiveRegistry();

        ProjectScripts ProjectScripts => Wf.ProjectScripts();

        ProcessMemory ProcessMemory => Wf.ProcessMemory();

        Tooling Tooling => Wf.Tooling();

        ApiMd ApiMd => Wf.ApiMd();

        WinSdk WinSdk => Wf.WinSdk();

        [CmdOp("api/tablegen")]
        void GenRecords()
        {
            var buffer = text.emitter();
            var src = ApiAssemblies.Components;
            var defs = TableDefs.defs(src);
            iter(defs, src => Tables.generate(0u,src,buffer));
            var dst = AppDb.CgStage("api.tables").Path("replicants", FileKind.Cs);
            Channel.FileEmit(buffer.Emit(),dst);         
        }

        [CmdOp("api/emit")]
        void ApiEmit()
            => ApiMd.Emitter(AppDb.ApiTargets()).Emit(ApiAssemblies.Components);

        [CmdOp("api/types")]
        void EmitApiTypes()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitApiTypes(ApiAssemblies.Components);

        [CmdOp("api/tables")]
        void EmitApiTables()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitApiTables(ApiAssemblies.Components);

        [CmdOp("archives")]        
        void ListArchives(CmdArgs args)
            => Channel.Row(AppDb.Archives().Folders().Delimit(Eol));

        [CmdOp("archives/list")]        
        void ArchiveFiles(CmdArgs args)
        {
            var src = AppDb.Archive(arg(args,0).Value);
            iter(src.Files(true), file => Channel.Write(file.ToUri()));
        }

        [CmdOp("tokens/types")]
        void TokenTypes()
        {
            var types = Tokens.types(ApiAssemblies.Components);
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
                Channel.Write(token.Format());
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
            
        [CmdOp("scripts")]
        void Scripts(CmdArgs args)
            => iter(ProjectScripts.List(args), path => Channel.Write(path.ToUri()));

        [CmdOp("scripts/cmd")]
        void Script(CmdArgs args)
            => ProjectScripts.Start(args);

        [CmdOp("archives/register")]
        void RegisterWorkspace(CmdArgs args)
        {
            ArchiveRegistry.Register(arg(args,0).Value, FS.dir(arg(args,1).Value));
            iter(ArchiveRegistry.Entries(), entry => Channel.Row(entry));            
        }

        [CmdOp("memory/working")]
        void WorkingSet()
            => Channel.Write(((ByteSize)Environment.WorkingSet));


        [CmdOp("memory/system")]
        void SysMem()
        {
            var src = WinMem.system();
            var formatter = CsvTables.formatter<SystemMemoryInfo>(16,RecordFormatKind.KeyValuePairs);
            Channel.Row(formatter.Format(src));
        }

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

            var basic = WinMem.basic(@base);
            Channel.Write(basic.ToString());
        }

        [CmdOp("dbghelp")]
        void DbgHelp()
        {
            var match = FS.file("dbghelp", FileKind.Dll);
            var path = WinSdk.DebuggerFiles(FileKind.Dll).Where(path => path.FileName == match).First();
            using var handle = SystemHandle.own(Kernel32.LoadLibrary(path.Format()));
            using var dst = new DbgHelp(path,handle);
            var ops = dst.Operations;
            Channel.Row($"{dst.Handle.Address} {dst.Path}");
            iter(ops, op => Channel.Row($"{op.Address} {op.Name}"));
        }

        [CmdOp("memory/info")]
        void ShowMemory()
        {
            var @base = ExecutingPart.Process.Adapt().BaseAddress;
            Channel.Row(@base);

            var info = WinMem.basic(@base);
            Channel.Row(info.BaseAddress);
            var formatter = CsvTables.formatter<BasicMemoryInfo>(16,RecordFormatKind.KeyValuePairs);
            Channel.Row(formatter.Format(info));
        }

        [CmdOp("memory/emit")]
        void EmitRegions()
            => ProcessMemory.EmitRegions(Process.GetCurrentProcess(), ApiPacks.create());

        [CmdOp("api/emit/impls")]
        void EmitImplMaps()
        {
            var src = Clr.impls(Parts.Lib.Assembly, Parts.Lib.Assembly);
            using var writer = AppDb.ApiTargets().Path("api.impl.maps", FileKind.Map).Utf8Writer();
            for(var i=0; i<src.Count; i++)
                src[i].Render(s => writer.WriteLine(s));
        }

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => Tooling.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => Tooling.Setup(Cmd.tool(args));

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(Tooling.LoadDocs(arg(args,0).Value), doc => Channel.Write(doc));

        [CmdOp("api/calls/check")]
        void CheckApiCalls()
        {
            CheckMullo(Rng.@default());
        }

        [CmdOp("spin")]
        void Spin()
        {
            bool OnTick(SpinStats stats)
            {
                Channel.Row($"{stats.Count} {stats.Ticks}");
                return stats.Count <= 10;
            }

            Spinners.spin(TimeSpan.FromSeconds(1), OnTick);
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
                var listing = Archives.listing(pack.Files().Array());
                var dst = AppDb.AppData().PrefixedTable<ListedFile>($"api.pack.{pack.Timestamp}");
                Channel.TableEmit(listing, dst);
            }

            return result;
        }

        [CmdOp("devshell")]
        void LaunchShell(CmdArgs args)
            => DevShells.start(Channel,args);

        [CmdOp("files/kinds")]
        void FileKinds()
        {
            var src = Symbols.index<FileKind>();
            var parser = EnumParser<FileKind>.Service;
            iter(src.Storage, s => {
                if(!parser.Parse(s.Expr.Format(), out FileKind kind))
                {
                    Channel.Error(s.Expr);                    
                }
                else
                {
                    Channel.Row(kind);
                }

            });
        }

        [CmdOp("env/gen")]
        void EnvGen(CmdArgs args)
        {
            var env = new EnvId(args[0].Value);
            var report = EnvReports.load(AppSettings.EnvDb(), env);
            iter(report.Tools, t => Channel.Row(t.Name));
            // var cg = lang.Ts.Generator(Wf);
            // var dst = FS.dir(args[1].Value);
            // cg.GenTokens(env, dst.DbArchive());
        }

        [CmdOp("runtime/files")]
        void RuntimeFiles()
        {
            var root = FS.dir(RuntimeEnvironment.GetRuntimeDirectory()).DbArchive();
            var files = root.Files();
            iter(files, file => Channel.Row(file));
        }

        [CmdOp("api/parts")]
        void ApiPartList()
        {
            var root = FS.path(controller().Location).FolderPath;
            var src  = Archives.parts(root);
            iter(src, OnPart);
        }

        void OnPart(Assembly src)
        {
            Channel.Row(src.Path());
            var types = src.Types().Tagged(nameof(FileTypeAttribute));
            iter(types, t => Channel.Row($"  {t.Name}"));
        }

        [CmdOp("api/catalog")]
        void EmitApiCatalog()
        {
            var src = ApiCatalog.catalog();
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

        [CmdOp("files/types")]
        void FileTypes()
        {
            var src = ApiCatalog.catalog().Assemblies;
            var types = Archives.FileTypes(src);
            iter(types, t => {
                Channel.Row(t.Format());
            });
        }

        [CmdOp("api/assemblies")]
        void ApiPartCompare()
        {
            var left = ApiCatalog.components().Map(x => (x.GetSimpleName(), x)).ToDictionary();
            var right = ApiCatalog.components().Map(x => (x.GetSimpleName(), x)).ToDictionary();
            var lKeys = left.Keys.ToHashSet();
            var rKeys = right.Keys.ToHashSet();
            var common = hashset<string>();
            common.Include(lKeys);
            common.IntersectWith(rKeys);
            iter(common, name => {
                var a = left[name];
                var b = right[name];
                var kA = Ecma.key(a);
                var kB = Ecma.key(b);
                if(!object.ReferenceEquals(a,b))
                    Channel.Row($"{kA} != {kB}");
            });
        }

        [CmdOp("clrmd")]
        void ClrMd()
        {
            using var clrmd = ClrMdSvc.create(Wf);
            iter(clrmd.Modules(), module => {
                
                Channel.Row($"{(MemoryAddress)module.ImageBase} {module.FileName}");
                var pdb = module.Pdb;
                if(pdb != null)
                    Channel.Row($"Pdb: {pdb.Guid} {pdb.Path}");
                });
            // iter(clrmd.Modules(), m => {
            //     Channel.Row($"{(MemoryAddress)m.Address} {m.Name}");
            // });
        }
    }
}