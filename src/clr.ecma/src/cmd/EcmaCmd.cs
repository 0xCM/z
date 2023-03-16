//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

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
            var modules = Archives.modules(src).AssemblyFiles();
            var stats = EcmaReader.stats(modules.Select(x => x.Path));
            var folder = nested(DataTarget.Scoped("clr").Root, src);
            var path = folder.DbArchive().Table<EcmaRowStats>();
            Channel.TableEmit(stats,path);
        }

        [CmdOp("ecma/emit/typedefs")]
        void EmitTypeDefs(CmdArgs args)
        {
            var src = Archives.modules(FS.dir(args[0])).AssemblyFiles();
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

        void Validate(AssemblyIndex src)
        {
            iter(src.Distinct(), entry => {
                var hashA = FS.hash(entry.Path).ContentHash;
                iter(src.Entries(entry.Key), e => {
                    Require.equal(hashA, FS.hash(e.Path).ContentHash);
                });
                Channel.Row($"Validated {entry.Key}");
            }, true);
        }

        [CmdOp("ecma/traverse")]
        void EcmaTraverse(CmdArgs args)
        {
            var src = Ecma.index(Channel, FS.dir(args[0]));
            using var map = src.Map();
            iter(map.Keys, key => {
                var assembly = map[key];
                Channel.Row(string.Format("{0,-48} | {1,-16} | {2,-12}",
                    key, 
                    assembly.BaseAddress, 
                    assembly.FileSize 
                    ));
            });
            // Validate(src);
            // iter(src.Distinct(), entry => {
            //     var es = src.Entries(entry.Key);
            //     Channel.Row(RP.PageBreak180);
            //     Channel.Row(entry.Key, FlairKind.StatusData);
            //     iter(es, e => {
            //         Channel.Row(e.Path);
            //     });                
            // });

        }
        
        [CmdOp("ecma/emit/streams")]
        void EmitEcmaStreams(CmdArgs args)
        {
            var source = FS.dir(args[0]).DbArchive();
            var assemblies = Archives.modules(source.Root).AssemblyFiles();
            var dst = bag<EcmaStreamHeader>();
            iter(assemblies, a => {
                using var file = EcmaFile.open(a.Path);
                var reader = file.EcmaReader();
                var memory = reader.Memory();
                var root = memory.ReadMetadataRoot();
                var tables = EcmaStreams.tables(root);
                var blobs = EcmaStreams.blobs(root);
                
            });

        }
        [CmdOp("ecma/emit/mdroots")]
        void EmitMdHeader(CmdArgs args)
        {
            var src = Ecma.index(Channel, FS.dir(args[0]));
            iter(src.Entries(), entry => {
                using var file = EcmaFile.open(entry.Path);
                var reader = file.EcmaReader();
                var memory = reader.Memory();
                var header = memory.ReadMetadataRoot();
                Channel.Row(header);
            });
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

        [CmdOp("ecma/emit/dumps")]
        void EmitMetaDumps()
            => EcmaEmitter.EmitMetadumps(Channel, ApiAssemblies.Parts, AppDb.ApiTargets("ecma/dumps"));

        [CmdOp("ecma/dump")]
        void EmitCliDump(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var assemblies = Archives.modules(src).AssemblyFiles();
            var index = FS.index(assemblies.Select(x => x.Path));
            var dst = AppSettings.EnvDb().Scoped("libs/dotnet");
            iter(index.Unique, entry => {
                using var file = MappedAssembly.map(entry.Path);
                var reader = file.EcmaReader();
                var name = reader.AssemblyName();
                var version = name.Version;
                var hash = entry.FileHash.ContentHash;
                var ext = entry.Path.Ext;
                var target = dst.Path($"{name.SimpleName()}.{version}.{ext}.{(Hex32)(uint)file.FileSize}.{(Hex64)hash.Lo}", FileKind.Txt);
                EcmaEmitter.EmitMetadump(reader.MetadataReader,target);
            },true);
        }

        [CmdOp("ecma/modules")]
        void EcmaCheck(CmdArgs args)
        {
            var paths = Archives.modules(FS.dir(args[0])).AssemblyPaths();
            var dst = AppSettings.EnvDb().Scoped("assemblies/records");
            iter(paths, path => {
                using var file = Ecma.file(path);
                var reader = file.EcmaReader();
                var name = reader.AssemblyName();
                var row = reader.ReadModuleRow().View(reader);
                Channel.Row(string.Format("{0,-64} | {1,-16} | {2}", name.SimpleName(), name.Version, row.Mvid));                
            }, true);
        }

        [CmdOp("formatters/list")]
        void CheckBinaryFormatters()
        {
            var types = Assembly.GetExecutingAssembly().Types();
            iter(types, t => {
                if(t.Name == "StringFormatter")
                {
                    var attribs = t.GetCustomAttributes();
                    iter(attribs, a => {
                        if(a.GetType() == typeof(BinaryFormatterAttribute))
                            Channel.Row(t);
                    });
                }                
            });
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


        [CmdOp("ecma/emit/refs")]
        void EmitModuleRefs(CmdArgs args)
        {
            var dir = FS.dir(args[0]);                        
            var src = Archives.modules(dir).AssemblyFiles();
            var buffer = bag<EcmaDependencySet>();
            iter(src, file => {
                using var ecma = Ecma.file(file.Path);
                var reader = ecma.EcmaReader();
                buffer.Add(reader.ReadDependencySet());
            });

            iter(buffer, set => {
                iter(set.NativeDependencies, native => {
                    Channel.Row($"{native.Source}.{native.SourceVersion} -> {native.TargetName}");
                });
            });
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
            var src = Archives.modules(FS.dir(args[0])).AssemblyFiles();
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
        
        [CmdOp("ecma/pinvokes")]
        void PInvokes(CmdArgs args)
        {
             var src = Ecma.index(Channel, FS.dir(args[0]));
            iter(src.Entries(), entry => {
                var counter = 0u;
                using var ecma = Ecma.file(entry.Path);                
                var reader = ecma.EcmaReader();
                var defs = reader.ReadPinvokeMethodDefs();
                iter(defs, d => {
                    var import = d.Import;
                    counter++;
                    Channel.Row(counter.ToString("D5") + $" {entry.Path.FileName} -> {import.Dll}::{import.DeclaringType}:{import.Name}:{EcmaSigs.format(import.MethodSignature)}");
                });
            });                        
        }

        [CmdOp("ecma/compile")]
        void Compilations(CmdArgs args)
        {
            var src = Archives.modules(FS.dir(args[0]), false).AssemblyFiles();
            var identifer = "test.a";
            var refs = list<PortableExecutableReference>();
            var dst = CsGen.emitter();
            var namespaces = hashset<string>();
            refs.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
            iter(src, file => {
                refs.Add(MetadataReference.CreateFromFile(file.Path.Format()));
                using var ecma = Ecma.file(file.Path);                
                var reader = ecma.EcmaReader();
                namespaces.AddRange(reader.ReadNamespaceNames().View);
             });

            iter(namespaces, ns => dst.UsingNamespace(0,ns));                                                    

            dst.AppendLine(@"
                class App
                {
                    static void Main(string[] args)
                    {
                        
                    }
                }
            ");


            var code = dst.Emit().Join(Chars.NL);
            Channel.Row(code);
            var syntax = CSharpSyntaxTree.ParseText(code);
            var compOptions = new CSharpCompilationOptions(OutputKind.ConsoleApplication, allowUnsafe:true, metadataImportOptions:MetadataImportOptions.All);                    
            var compilation = CSharpCompilation.Create(identifer, syntaxTrees: new []{syntax}, references: refs, options:compOptions);            
            var output = AppSettings.EnvDb().Scoped("clr").Path(identifer, FileKind.Exe).Delete();
            var emitOptions = new EmitOptions(false, DebugInformationFormat.Embedded, includePrivateMembers:true);
            using var stream = output.Stream();            
            var result = compilation.Emit(stream,options:emitOptions);
           
        }
    }
}