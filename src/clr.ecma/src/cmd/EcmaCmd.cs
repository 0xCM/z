//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Windows;

    using static sys;

    partial class EcmaCmd : WfAppCmd<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        DataAnalyzer Analyzer => Wf.Analyzer();

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("ecma/emit")]
        void EcmaEmit()
            => EcmaEmitter.Emit(ApiAssemblies.Components, EcmaEmissionSettings.Default, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/emit/parts")]
        void EmitPartEcma()
            => EcmaEmitter.EmitCatalogs(ApiAssemblies.Components, AppDb.ApiTargets());

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(ApiAssemblies.Components, AppDb.ApiTargets("ecma/hex"), 64);

        [CmdOp("ecma/emit/assembly-refs")]
        void EmitAssmeblyRefs(CmdArgs args)
            => EcmaEmitter.EmitAssemblyRefs(ApiAssemblies.Components, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/emit/method-defs")]
        void EmitMethodDefs(CmdArgs args)
            => EcmaEmitter.EmitMethodDefs(ApiAssemblies.Components, AppDb.ApiTargets("ecma/methods.defs").Delete());

        [CmdOp("ecma/emit/member-refs")]
        void EmitMemberRefs(CmdArgs args)
            => EcmaEmitter.EmitMemberRefs(ApiAssemblies.Components, AppDb.ApiTargets("ecma/members.refs"));

        [CmdOp("ecma/emit/strings")]
        void EmitStrings(CmdArgs args)
            => EcmaEmitter.EmitStrings(ApiAssemblies.Components, AppDb.ApiTargets("ecma/strings"));

        [CmdOp("ecma/emit/blobs")]
        void EmitBlobs(CmdArgs args)
            => EcmaEmitter.EmitBlobs(ApiAssemblies.Components, AppDb.ApiTargets("ecma/blobs"));

        [CmdOp("ecma/emit/msil")]
        void EmitMsil()
        {
            var src = ApiMd.ApiHosts.GroupBy(x => x.Assembly).Map(x => (x.Key,x.Array())).ToDictionary();
            Ecma.EmitMsil(src, AppDb.ApiTargets("ecma/msil"));
        }

        [CmdOp("ecma/emit/msildat")]
        void EmitMsilData()
            => EcmaEmitter.EmitMsilMetadata(ApiAssemblies.Components, AppDb.ApiTargets("ecma/msil.dat"));

        [CmdOp("ecma/emit/literals")]
        void EmitLiterals()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitLiterals(ApiAssemblies.Components);

        [CmdOp("ecma/emit/headers")]
        void EmitHeaders()
            => EcmaEmitter.EmitSectionHeaders(sys.controller().RuntimeArchive(), Dst);

        [CmdOp("ecma/emit/stats")]
        void EcmaEmitStats(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var modules = Archives.modules(src);
            EcmaEmitter.EmitTableStats(modules, EnvDb.Nested("clr", src));
        }

        [CmdOp("ecma/typedefs")]
        void EmitTypeDefs(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var index = AssemblyIndex.create(Channel, src.DbArchive());
            var dst = bag<EcmaTypeDef>();
            iter(index.Distinct(), file => {
                using var ecma = Ecma.file(file.Path);
                var reader = Ecma.reader(ecma);
                iter(reader.ReadTypeDefs(), t => {
                    if(!t.Name.Contains("<") && !t.DeclaringType.Contains("<"))
                        dst.Add(t);
                });
            }, true);        

            Channel.TableEmit(dst.Array().Sort(),  EnvDb.Nested("ecma", src).Table<EcmaTypeDef>());
        }

        [CmdOp("ecma/tables/kinds")]
        void EmitEcmaTables()
        {
            var src = Ecma.TableKinds();
            iter(src, x => {
                Channel.Row(string.Format("{0:x2} {1}", (byte)x.Value, x.Name));
            });
        }

        [CmdOp("ecma/traverse")]
        void EcmaTraverse(CmdArgs args)
        {
            var src = AssemblyIndex.create(Channel, FS.dir(args[0]).DbArchive());
            using var map = src.Map();
            iter(map.Keys, key => {
                var assembly = map[key];
                Channel.Row(string.Format("{0,-48} | {1,-16} | {2,-12}",
                    key, 
                    assembly.BaseAddress, 
                    assembly.FileSize 
                    ));
            });
        }
        
        [CmdOp("ecma/methods")]
        void EmitEcmaMethods(CmdArgs args)
        {
            var src = Ecma.index(Channel, FS.dir(args[0]));
            var dst = EnvDb.Scoped("indices");
            src.Report(dst);
            var distinct = src.Distinct();
            iter(distinct, entry => {
                using var file = Ecma.file(entry.Path);
                var reader = file.EcmaReader();
                var methods = reader.ReadMethodDefs();
                iter(methods, method => {
                    
                });
            });
        }

        [CmdOp("ecma/streams")]
        void EmitEcmaStreams(CmdArgs args)
        {
            var src = Ecma.index(Channel, FS.dir(args[0]));
            var dst = bag<EcmaStreamHeader>();
            iter(src.Distinct(), a => {
                using var file = EcmaFile.open(a.Path);
                var reader = file.EcmaReader();
                var memory = reader.Memory();
                var root = memory.ReadMetadataRoot();
                var tables = EcmaStreams.tables(root);
                var blobs = EcmaStreams.blobs(root);
                var strings = EcmaStreams.strings(root,false);
                var guids = EcmaStreams.guids(root);
                Channel.Row(RP.PageBreak180, FlairKind.StatusData);
                Channel.Row(a.Path);
                Channel.Row($"Strings: {strings.BaseAddress}:{strings.Size}");
                Channel.Row($"Blobs:   {blobs.BaseAddress}:{blobs.Size}");
                Channel.Row($"Guids:   {guids.BaseAddress}:{guids.Size}");

                var counts = tables.RowCounts;
                var b = new bits<ulong>(64, (ulong)tables.Present);
                var j=0;
                for(byte i=0; i<64; i++)
                {
                    if(b[i])
                    {
                        var table = (TableIndex)i;
                        var count = counts[j++];
                        Channel.Row(string.Format("{0,-24} {1}", table, count));
                    }
                }
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

        [CmdOp("ecma/blocks")]
        void CheckSigParser(CmdArgs args)
        {
            var index = AssemblyIndex.create(Channel, FS.dir(args[0]).DbArchive());
            iter(index.Distinct(), entry => {
                using var file = EcmaFile.open(entry.Path);
                var reader = file.EcmaReader();
                var defs = reader.ReadMethodDefs();
                iter(defs, def => {
                    if(def.Rva != 0)
                    {
                        var body = file.PeReader.GetMethodBody((int)def.Rva);                                                
                        Channel.Row(string.Format("{0} | {1,-64} | {2}", def.Rva, def.Name, body.GetILBytes().FormatHex()));
                    }

                    //Channel.Row(body.GetILBytes());
                    // var data = body.GetILBytes();
                    // Channel.Row(data.FormatHex());
                });
            });

        }

        [CmdOp("ecma/emit/dumps")]
        void EmitMetaDumps()
            => EcmaEmitter.EmitMetadumps(Channel, ApiAssemblies.Components, AppDb.ApiTargets("ecma/dumps"));

        [CmdOp("ecma/dump")]
        void EmitCliDump(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var assemblies = Archives.modules(src).AssemblyFiles();
            var index = FS.index(assemblies.Select(x => x.Path));
            var dst = AppSettings.EnvDb().Scoped("libs/dotnet");
            iter(index.Unique, entry => {
                using var file = MappedAssembly.map(entry.Location);
                var reader = file.EcmaReader();
                var name = reader.AssemblyName();
                var version = name.Version;
                var hash = entry.FileHash.ContentHash;
                var ext = entry.Location.Ext;
                var target = dst.Path($"{name.SimpleName()}.{version}.{ext}.{(Hex32)(uint)file.FileSize}.{(Hex64)hash.Lo}", FileKind.Txt);
                EcmaEmitter.EmitMetadump(reader.MetadataReader,target);
            },true);
        }

        [CmdOp("ecma/modules")]
        void EcmaCheck(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var paths = Archives.modules(src).AssemblyPaths();
            var dst = AppSettings.EnvDb().Nested("assemblies", src);
            iter(paths, path => {
                using var file = Ecma.file(path);
                var reader = file.EcmaReader();
                var name = reader.AssemblyName();
                var row = reader.ReadModuleRow().View(reader);
                Channel.Row(string.Format("{0,-64} | {1,-16} | {2}", name.SimpleName(), name.Version, row.Mvid));                
            }, true);
        }

        [CmdOp("coff/modules")]
        void ExportPeInfo(CmdArgs args)
        {            
            var src = FS.dir(args[0]);
            var targets = FS.dir(args[1].Value).DbArchive().Scoped("coff.modules");
            var modules = bag<CoffModule>();
            PeReader.modules(src.DbArchive(),m => {
                var path = targets.Path(m.Path.FileName.WithExtension(FS.ext("records")));
                Channel.FileEmit(m.ToString(), path);
            });
        }

        [CmdOp("pe/headers")]
        void PeHeaders(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var modules = Archives.modules(src);
            iter(modules.Members(), member => {
                using var map = PeMap.create(member.Path);
                if(PeFiles.test(map.Segment()))
                {
                    var memory = map.PeMemory();
                    var dos = memory.DosHeader;
                    var coff = memory.CoffHeader;
                    Channel.Row(coff);
                }

            });
        }

        [CmdOp("pe/tables")]
        unsafe void EmitPeTables(CmdArgs args)
        {
            var sources = FS.dir(args[0]).DbArchive();
            var label = args.Count > 1 ? args[1].Value.Format() : FS.identifier(sources.Root);
            var dst = EnvDb.Scoped("pe").Path($"{label}.directories", FileKind.Csv);
            var modules = Archives.modules(sources.Root);
            var rows = list<PeDirectoryRow>();
            iter(modules.Members(), member => {
                using var reader = PeReader.create(member.Path);
                var tables = reader.Tables;
                rows.AddRange(tables.DirectoryRows);
                iter(tables.DirectoryRows, row => {
                    if(row.Kind == PeDirectoryKind.DebugTable)
                    {
                        var debug = *((IMAGE_DEBUG_DIRECTORY*)reader.ReadSectionData(row.Entry()).Pointer);
                        var seg = new MemorySeg<Address32,uint>((Address32)debug.AddressOfRawData, debug.SizeOfData);
                        Channel.Row(seg.Format());                        
                    }
                });
            });        

            var records = rows.Array().Sort().Resequence();
            Channel.TableEmit(records, dst);
        }

        [CmdOp("pe/emit/headers")]
        void PeDirs(CmdArgs args)
        {
            var archives = Channel.Channeled<ModuleArchives>();
            var src = FS.dir(args[0]);
            var modules = Archives.modules(src);
            var headers = bag<PeSectionHeader>();
            var dirs = bag<PeDirectoryEntry>();
            iter(modules.Members(), member => {
                if(member.Path.FileKind() != FileKind.Pdb)
                {
                    try
                    {
                        var rel = FS.relative(src, member.Path);
                        using var reader = PeReader.create(member.Path);
                        var tables = reader.Tables;
                        iter(tables.SectionHeaders, section => headers.Add(section.WithFile(FS.file(rel.Format()))));
                        iter(tables.Directories.Values, e => dirs.Add(e));                    
                    }
                    catch(BadImageFormatException)
                    {

                    }
                }
            });

            var dst = EnvDb.Nested("pe", src).Path("sections.headers", FileKind.Csv);
            Channel.TableEmit(headers.Array().Sort().Resequence(), dst);
        }

        [CmdOp("ecma/dump")]
        void EcmaEmitMetaDumps(CmdArgs args)
            => EcmaEmitter.EmitMetadumps(FS.dir(args[0]).DbArchive(), true, FS.dir(args[1]).DbArchive());

        [CmdOp("ecma/index")]
        void EcmaImport(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var index = AssemblyIndex.create(Channel, src.DbArchive());
            var dst = EnvDb.Nested("indices", src);
            index.Report(dst);
            var distict = index.Distinct();
            iter(distict, entry => {
                
                // var path = EnvDb.Scoped("ecma/dumps").Path(FS.file($"{entry.Name}.{entry.Mvid}", FileKind.Txt));
                // if(!path.Exists)
                // {
                //     using var file = Ecma.file(entry.Path);
                //     EcmaEmitter.EmitMetadump(file.MdReader, path);
                // }
            }, true);
        }   

        [CmdOp("ecma/heaps")]
        void EmitEcmaHeaps(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive();
            var dst = EnvDb.Scoped("ecma");
            EcmaHeaps.emit(Channel,src,dst);
        }
        
        [CmdOp("ecma/pinvokes")]
        void PInvokes(CmdArgs args)
        {   
            var src = FS.dir(args[0]);
            var index = Ecma.index(Channel, src);
            var dst = bag<EcmaPinvoke>();
             iter(index.Distinct(), entry => {
                var counter = 0u;
                using var ecma = Ecma.file(entry.Path);                
                var reader = ecma.EcmaReader();
                var defs = reader.ReadPinvokes();
                dst.AddRange(defs);
            });

            var path = EnvDb.Nested("ecma", src).Path("ecma.pinvokes", FileKind.Csv);
            Channel.TableEmit(dst.Array().Sort(), path);
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

        static Assembly[] CodeAnalysis 
            => FS.path(ExecutingPart.Assembly.Location).FolderPath.DbArchive().Files(FileKind.Dll, false).Where(f => f.FileName.StartsWith("Microsoft.CodeAnalysis")).Map(x => Assembly.LoadFile(x.Format()));


        [CmdOp("roslyn/nodes")]
        void RoslnNodes()
        {
            iter(CodeAnalysis, a => {
                var reader = EcmaReader.create(a);
                var name = a.GetSimpleName();
                if(name == "Microsoft.CodeAnalysis.CSharp")
                {
                    var counter = 0u;
                    var types = dict<string,Type>();
                    var ancestors = dict<Type,Type>();
                    Channel.Row(name, FlairKind.StatusData);
                    var deps = reader.ReadDependencySet();
                    iter(deps.ManagedDependencies, d => Channel.Row($"  --> {d.TargetName}"));
                    var ft = a.Types().Where(t => !t.FullName.Contains("<"));

                    iter(ft, t => types[t.FullName] = t);
                    iter(ft, t => {
                        ancestors[t] = t.BaseType;
                    });
                    var margin = 0u;
                    iter(ancestors, kvp => {
                        var def = text.emitter();
                        var type = kvp.Key;
                        var parent = kvp.Value;
                        if(!type.Name.Contains("<") && nonempty(type.Namespace))
                        {
                            if(parent != null)
                                def.Append(string.Format("{0:D5} {1}.{2} -> {3}.{4}", counter++, type.Namespace, type.Name, parent.Namespace, parent.Name));
                            else
                                def.Append(string.Format("{0:D5} {1}.{2}", counter++, type.Namespace, type.Name));
                            Channel.Row(def.Emit());
                        }

                    });
                }
            });
        }

        [CmdOp("files/analyze")]
        void Analyze(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive();
            var dst = FS.dir(args[1]).DbArchive();
            Analyzer.Run(src,dst);            
        }

        [CmdOp("ecma/debug")]
        void DebugMethods(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive().Modules();
            iter(src.AssemblyFiles(), a => {                
                using var file = Ecma.file(a.Path);                
            });
        }

        [CmdOp("clr/types")]
        void ListTypes(CmdArgs args)
        {
            var dir = FS.dir(args[0]);
            var src = Archives.modules(dir).AssemblyFiles();
            ApiMd.Emitter(Archives.archive(EnvDb.Scoped("clr"))).EmitTypeLists(src);
        }
    }
}