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

    public class WfAppCmd : WfAppCmd<WfAppCmd>
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
            var src = ApiAssemblies.Parts;
            var defs = TableDefs.defs(src);
            iter(defs, src => Tables.generate(0u,src,buffer));
            var dst = AppDb.CgStage("api.tables").Path("replicants", FileKind.Cs);
            Channel.FileEmit(buffer.Emit(),dst);         
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

        [CmdOp("archives")]        
        void ListArchives(CmdArgs args)
            => Channel.Row(AppDb.Archives().Folders().Delimit(Eol));

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
            var handle = SystemHandle.own(Kernel32.LoadLibrary(path.Format()));
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
            => iter(Tooling.LoadDocs(arg(args,0).Value), doc => Write(doc));

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
                var listing = Archives.listing(pack.Files());
                var dst = AppDb.AppData().PrefixedTable<ListedFile>($"api.pack.{pack.Timestamp}");
                Channel.TableEmit(listing, dst);
            }

            return result;
        }


        [CmdOp("pe/import")]
        void PeFiles(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive().Enumerate(true, FileKind.Dll, FileKind.Exe, FileKind.Obj, FileKind.Sys);
            var dst = bag<PeSectionHeader>();
            iter(src, path => {
                try
                {
                    var flow = Channel.Running($"Reading section headers from {path}");
                    using var reader = PeReader.create(path);
                    var tables = reader.Tables;
                    iter(tables.SectionHeaders, sh => dst.Add(sh));
                    Channel.Ran(flow,$"Read {tables.SectionHeaders.Count} section headers from ${path}");
                                        
                }
                catch(Exception e)
                {
                    Channel.Error(e);
                }
            });
            
            var path = EnvDb.Scoped("flows/import").Table<PeSectionHeader>();
            Channel.TableEmit(dst.Array(),path);
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

        [CmdOp("files/index")]
        void FileQuery(CmdArgs args)
        {
            var query = FileQueries.query(FS.dir(args[0]));
            var index = FS.index();
            var counter = 0u;
            void Handler(FilePath src)
            {
                var kind = src.FileKind();
                if(index.Include(src) && (kind == FileKind.Dll || kind == FileKind.Exe || kind == FileKind.Sys || kind == FileKind.Obj))
                {
                    using var reader = src.BinaryReader();
                    Span<byte> buffer = stackalloc byte[1024];
                    var length = reader.Read(buffer);
                    if(length >= (0x3C + 4))
                    {
                        var sigloc = u32(slice(buffer,0x3C, 4));
                        if(sigloc + 4 <= 1024)
                        {
                            var sig = slice(buffer,sigloc, 4);
                            if((char)skip(sig,0) == 'P' && (char)skip(sig,1) == 'E' && skip(sig,2) == 0 && skip(sig,3) == 0)
                            {
                                Channel.Row($"PE file: {src}");
                            }
                        }
                    }
                }

                if(sys.inc(ref counter) % 1000 == 0)
                    Channel.Babble($"Indexed {counter} files");
            }

            var receiver = QueryReceiver.create(query, r => r.WithHandler(Handler));
            receiver.Run(Channel);
            var duplicates = index.Duplicates.Map(x => x.Value).SelectMany(x => x);
            var unique = index.Unique;
            Require.equal(counter, (uint)(unique.Count + duplicates.Length));

            Channel.Status($"Indexed {unique.Count} unique files with {duplicates.Length} duplicates");
        }
    }
}