//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    unsafe class AppApiCmd : WfAppCmd<AppApiCmd>
    {        
        ArchiveRegistry ArchiveRegistry => Channel.Channeled<ArchiveRegistry>();

        ProcessMemory ProcessMemory => Wf.ProcessMemory();

        ApiMd ApiMd => Wf.ApiMd();

        [CmdOp("api/tablegen")]
        void GenRecords()
        {
            var buffer = text.emitter();
            var src = ApiAssemblies.Components;
            var defs = CsvTables.defs(src);
            iter(defs, src => CsvTables.generate(0u, src, buffer));
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
            var archive = (Env.cd() + FS.folder(".data")).DbArchive();
            ApiMd.Emitter(archive).EmitTypeList(types, FS.file("tokens.types", FileKind.List));    
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
            }
        }
            
        [CmdOp("archives/register")]
        void RegisterWorkspace(CmdArgs args)
        {
            ArchiveRegistry.Register(arg(args,0).Value, FS.dir(arg(args,1).Value));
            iter(ArchiveRegistry.Entries(), entry => Channel.Row(entry));            
        }

        [CmdOp("system/memory/working")]
        void WorkingSet()
            => Channel.Write(((ByteSize)Environment.WorkingSet));

        [CmdOp("process/memory/emit")]
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
            var report = Env.load(AppSettings.EnvDb(), env);
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
            iter(ApiAssemblies.Components, OnPart);
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
    }
}