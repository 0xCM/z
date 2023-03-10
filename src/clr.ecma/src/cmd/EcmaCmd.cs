//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static EcmaModels;
    using static sys;

    partial class EcmaCmd : WfAppCmd<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        IEnvDb DataTarget => AppSettings.EnvDb();

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("ecma/emit")]
        void EcmaEmit()
            => EcmaEmitter.Emit(ApiAssemblies.Parts, EcmaEmissionSettings.Default, AppDb.ApiTargets("ecma"));

        public static ReadOnlySeq<Assembly> Parts(FolderPath src)
        {
            var modules = Archives.modules(src,false).Members().Where(x => FS.managed(x.Path) && !x.Path.FileName.Contains("System.Private.CoreLib"));
            return modules.Where(m => m.Path.FileName.StartsWith("z0.")).Map(x => Assembly.LoadFile(x.Path.Format()));
        }

        [CmdOp("api/parts")]
        void ApiPartList()
        {
            var root = FS.path(controller().Location).FolderPath;
            var src  = Parts(root);
            iter(src, a => Write(a.Path()));
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

        [CmdOp("ecma/emit/parts")]
        void EmitPartEcma()
            => EcmaEmitter.EmitCatalogs(ApiAssemblies.Parts, AppDb.ApiTargets());

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/hex"), 64);

        [CmdOp("ecma/emit/assembly-refs")]
        void EmitAssmeblyRefs(CmdArgs args)
            => EcmaEmitter.EmitAssemblyRefs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/emit/method-defs")]
        void EmitMethodDefs(CmdArgs args)
            => EcmaEmitter.EmitMethodDefs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/methods.defs").Delete());

        [CmdOp("ecma/emit/member-refs")]
        void EmitMemberRefs(CmdArgs args)
            => EcmaEmitter.EmitMemberRefs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/members.refs"));

        [CmdOp("ecma/emit/strings")]
        void EmitStrings(CmdArgs args)
            => EcmaEmitter.EmitStrings(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/strings"));

        [CmdOp("ecma/emit/blobs")]
        void EmitBlobs(CmdArgs args)
            => EcmaEmitter.EmitBlobs(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/blobs"));

        [CmdOp("ecma/emit/msil")]
        void EmitMsil()
        {
            var src = ApiMd.ApiHosts.GroupBy(x => x.Assembly).Map(x => (x.Key,x.Array())).ToDictionary();
            Ecma.EmitMsil(src, AppDb.ApiTargets("ecma/msil"));
        }

        [CmdOp("ecma/emit/msildat")]
        void EmitMsilData()
            => EcmaEmitter.EmitMsilMetadata(ApiAssemblies.Parts, AppDb.ApiTargets("ecma/msil.dat"));

        [CmdOp("ecma/emit/literals")]
        void EmitLiterals()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitLiterals(ApiAssemblies.Parts);

        [CmdOp("ecma/emit/headers")]
        void EmitHeaders()
            => EcmaEmitter.EmitSectionHeaders(sys.controller().RuntimeArchive(), Dst);

        static FolderPath nested(FolderPath root, FilePath src)
            => root + FS.folder(FS.components(src.FolderPath).Join('/'));

        static FolderPath nested(FolderPath root, FolderPath src)
            => root + FS.folder(FS.components(src).Join('/'));

        [CmdOp("ecma/emit/stats")]
        void EcmaEmitStats(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var modules = Archives.modules(src).Assemblies();
            var stats = EcmaReader.stats(modules.Select(x => x.Path));
            var folder = nested(DataTarget.Scoped("clr").Root, src);
            var path = folder.DbArchive().Table<EcmaRowStats>();
            Channel.TableEmit(stats,path);
        }

        [CmdOp("ecma/emit/typedefs")]
        void EmitTypeDefs(CmdArgs args)
        {
            var src = Archives.modules(FS.dir(args[0])).Assemblies();
            iter(src, path => {                
                using var file = Ecma.file(path.Path);
                var reader = Ecma.reader(file);
                if(!reader.IsReferenceAssembly())
                {
                    var defs = reader.ReadTypeDefs();
                    var folder = nested(DataTarget.Scoped("clr").Root, path.Path);
                    Channel.TableEmit(defs,  folder.DbArchive().Table<TypeDefInfo>(path.Path.FileName.WithoutExtension.Format()));
                }

            }, true);        
        }

        [CmdOp("ecma/tables/kinds")]
        void EmitEcmaTables()
        {
            var src = Ecma.TableKinds();
            iter(src, x => {
                Channel.Row(string.Format("{0:x2} {1}", (byte)x.Value, x.Name));
            });
        }

        [CmdOp("modules/map")]
        void EcmaMeta(CmdArgs args)
        {
            var svc = Channel.Channeled<ModuleArchives>();
            var sources = FS.dir(args[0]).DbArchive();
            using var map = svc.Map(sources);
        }

        static FilePath EcmaArchive(FilePath src)
            => AppDb.Archive("ecma").Path(src.FileName.WithExtension(FS.ext($"{src.Hash}.txt")));

        void EmitMetadumps(ItemList<uint,FilePath> src)        
        {
            iter(src, file => {
                if(file.Value.IsNot(FS.ext("resources.dll")))
                {
                    EcmaEmitter.EmitMetadump(file.Value, EcmaArchive(file.Value));
                    }
                }, PllExec);
        }

        static Outcome<FilePath> parse(string src)
            => FS.path(src);

        [CmdOp("ecma/emit/dumps")]
        void EmitMetaDumps()
            => EcmaEmitter.EmitMetadumps(Channel, ApiAssemblies.Parts, AppDb.ApiTargets("ecma/dumps"));

        [CmdOp("ecma/dump")]
        void EmitCliDump(CmdArgs args)
        {
            foreach(var arg in args)
            {
                var value = arg.Value;
                var src = FS.path(value);
                if(src.Is(FileKind.List))
                    EmitMetadumps(ListArchives.load(Channel, src, parse));
                else
                    EcmaEmitter.EmitMetadump(src, EcmaArchive(src));
            }
        }

        [CmdOp("coff/modules")]
        void ExportPeInfo(CmdArgs args)
        {
            var src = Archives.archive(args[0]);
            var targets = FS.dir(args[1].Value).ToArchive().Scoped("coff.modules");
            var modules = bag<CoffModule>();
            PeReader.modules(src,m => {
                var path = targets.Path(m.Path.FileName().WithExtension(FS.ext("records")));
                Channel.FileEmit(m.ToString(), path);
            });
        }

        [CmdOp("pe/emit/headers")]
        void PeDirs(CmdArgs args)
        {
            var archives = Channel.Channeled<ModuleArchives>();
            var sources = FS.dir(args[0]).DbArchive();
            var modules = Archives.modules(sources.Root);
            var headers = bag<PeSectionHeader>();
            var dirs = bag<PeDirectoryEntry>();
            
            iter(modules.Members(), member => {
                if(member.Path.FileKind() != FileKind.Pdb)
                {
                    try
                    {
                        using var reader = PeReader.create(member.Path);
                        var tables = reader.Tables;
                        var sections = tables.SectionHeaders;
                        iter(sections, section => headers.Add(section));
                        var directories = tables.Directories;
                        iter(directories.Values, e => dirs.Add(e));                    
                    }
                    catch(BadImageFormatException)
                    {

                    }
                }
            });

            //Channel.TableEmit(headers.Array().Sort(),)
        }

        [CmdOp("ecma/dump")]
        void EcmaEmitMetaDumps(CmdArgs args)
            => EcmaEmitter.EmitMetadumps(FS.dir(args[0]).DbArchive(), true, FS.dir(args[1]).DbArchive());

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

        [CmdOp("winmd/rsp")]
        void WinMdResponse(CmdArgs args)
        {
            var src = FS.dir(args[0]).ToArchive();
            iter(src.Files(true, FS.ext("rsp")), path => {
                Channel.Row(path, FlairKind.StatusData);
                WinMd.parse(path, out WinMd.ResponseFile response);
                iter(response.Options.Keys, name => {
                    Channel.Row($"--{name}");
                    iter(response.Options[name],  value => {
                        Channel.Row(value);
                    });
                });
            });;
        }

        [CmdOp("ecma/emit/refs")]
        void EmitModuleRefs(CmdArgs args)
        {
            var dir = FS.dir(args[0]);                        
            var src = Archives.modules(dir).Assemblies();
            var dst = bag<AssemblyRefInfo>();
            iter(src, asmfile => iter(Ecma.refs(asmfile.Path), c => dst.Add(c)), true);
            var sorted = dst.Array().Sort();
            var folder = nested(DataTarget.Scoped("clr").Root, dir);
            Channel.TableEmit(sorted, folder.DbArchive().Table<AssemblyRef>());  
        }   

        public record class EcmaHeapInfo
        {
            [Render(12)]
            public EcmaHeapKind HeapKind;

            [Render(16)]
            public MemoryAddress BaseAddress;

            [Render(16)]
            public ByteSize Size;

            [Render(1)]
            public FilePath Source;
        }

        [Op]
        public static ExecToken emit(IWfChannel channel, MemorySeg src, FilePath dst, byte bpl = HexCsvRow.BPL)
        {
            var reader = MemoryReader.create<byte>(src.Range);
            var flow = channel.EmittingTable<HexCsvRow>(dst);
            var @base = src.BaseAddress;
            var offset = MemoryAddress.Zero;
            using var writer = dst.Writer();
            var counter = 0u;
            var lines = 0u;
            while(reader.Next(out var b))
            {
                writer.Append(b.ToString("x2"));
                
                counter++;
                var newline = counter % bpl == 0;
                if(reader.HasNext && !newline)
                    writer.Append(" ");

                if(newline)
                {
                    writer.AppendLine();
                    lines++;
                }
            }
            return channel.EmittedTable(flow, lines);
        }

        [CmdOp("ecma/heaps")]
        void EmitEcmaHeaps(CmdArgs args)
        {
            var src = Archives.modules(FS.dir(args[0])).Assemblies();
            var dst = bag<EcmaHeapInfo>();
            var db = AppSettings.EnvDb().Scoped("clr");
            iter(src, a => {
                using var file = Ecma.file(a.Path);
                var reader = Ecma.reader(file);
                var heap = EcmaHeaps.strings(reader.MetadataReader, EcmaStringKind.System, reader.BaseAddress);
                var info = new EcmaHeapInfo();
                info.HeapKind = EcmaHeapKind.SystemString;
                info.BaseAddress = heap.BaseAddress;
                info.Size = heap.Size;
                info.Source = a.Path;
                dst.Add(info);
                var seg = new MemorySeg(heap.BaseAddress, heap.Size);
                var path = db.Path(a.Path.FileName.Format() + "SystemStrings", FileKind.Hex);
                emit(Channel, seg, path);        
                
            });
            Channel.TableEmit(dst.Array(), AppSettings.EnvDb().Scoped("clr").Path("ecma.heaps", FileKind.Csv));
        }
    }
}