//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Windows;

    using static sys;

    class EcmaFlows : WfAppCmd<EcmaFlows>
    {
        IDbArchive Source;

        Alloc Alloc;

        public EcmaFlows()
        {
            Alloc = Alloc.create();
        }
        
        ConcurrentDictionary<FolderPath,AssemblyIndex> AssemblyIndex = new();

        ConcurrentDictionary<FolderPath,FileIndex> ModuleIndex = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaRowStats>> EcmaStats = new();

        ConcurrentDictionary<AssemblyFile,AssemblyTypes> EcmaTypeDefs = new();

        ConcurrentDictionary<FolderPath,AssemblyFiles> AssemblyFiles = new();

        ConcurrentDictionary<FilePath,ReadOnlySeq<AssemblyMethods>> MethodDefs = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<MetadataRoot>> EcmaRoots = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<SectionHeaderRow>> SectionHeaderRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<PeDirectoryRow>> PeDirectoryRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<PeFileInfo>> PeFileInfoRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<MemberComments>> MemberCommentRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaDependencySet>> EcmaDependencySets = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaPinvoke>> EcmaPinvokes = new();

        const string Tag = "projects";

        ApiMd ApiMd => Wf.ApiMd();

        Ecma Ecma => Wf.Ecma();

        IDbArchive Target 
            => EnvDb.Nested(Tag, Source);

        FilePath TablePath<T>(string scope, AssemblyFile file)
        {            
            var filename = CsvTables.filename<T>(file.Path.FileName.WithoutExtension.Format(), file.Path.Hash.Format());
            return EnvDb.Nested(Tag, (IDbArchive)Source.Scoped(scope)).Path(filename);
        }

        AssemblyFiles GetAssemblyFiles()
            => AssemblyFiles.GetOrAdd(Source.Root, _ => Ecma.assemblies(Channel,Source));

        AssemblyIndex GetAssemblyIndex()
            => AssemblyIndex.GetOrAdd(Source.Root,  _ => Ecma.index(Channel, GetAssemblyFiles()));

        ReadOnlySeq<EcmaRowStats> GetEcmaStats()
            => EcmaStats.GetOrAdd(Source.Root, _ => Ecma.stats(GetAssemblyIndex()));

        ReadOnlySeq<MetadataRoot> GetMetadataRoots(IDbArchive src)
            => EcmaRoots.GetOrAdd(src.Root, _ => CalcMetadataRoots(src));

        AssemblyTypes GetTypeDefs(AssemblyFile src)
            => EcmaTypeDefs.GetOrAdd(src, _ => CalcTypeDefs(src));

        ReadOnlySeq<MemberComments> GetMemberComments()
            =>  MemberCommentRows.GetOrAdd(Source.Root, _ => Ecma.CalcMemberComments(Source));

        ReadOnlySeq<EcmaDependencySet> GetDependencies(AssemblyIndex src)
            => EcmaDependencySets.GetOrAdd(src.Source.Root, _ => Ecma.CalcDependencies(src));        

        ReadOnlySeq<EcmaPinvoke> CalcPinvokes(IDbArchive src)
        {
            var index = GetAssemblyIndex();
            var dst = bag<EcmaPinvoke>();
            iter(index.Distinct(), entry => {
                using var ecma = Ecma.file(entry.Path);                
                var reader = ecma.EcmaReader();
                var defs = reader.ReadPinvokes();
                dst.AddRange(defs);
            },true);
            
            return dst.Array().Sort();
        }

        ReadOnlySeq<EcmaPinvoke> GetPinvokes()
            => EcmaPinvokes.GetOrAdd(Source.Root, _ => CalcPinvokes(Source));

        AssemblyTypes CalcTypeDefs(AssemblyFile file)
        {
            var types = bag<EcmaTypeDef>();
            using var ecma = Ecma.file(file.Path);
            var reader = Ecma.reader(ecma);
            iter(reader.ReadTypeDefs(), t => {
                if(!t.Name.Contains("<") && !t.DeclaringType.Contains("<"))
                    types.Add(t);
            });
            return new AssemblyTypes(file, types.Array().Sort());
        }

        ReadOnlySeq<AssemblyTypes> CalcTypeDefs()
        {
            var dst = bag<AssemblyTypes>();
            iter(GetAssemblyIndex().Distinct(), entry => {
                    dst.Add(CalcTypeDefs(new AssemblyFile(entry.Path, entry.Key.AssemblyName)));
                }, true);                
            return dst.Array();
        }

        ReadOnlySeq<AssemblyTypes> GetTypeDefs()
        {
            return CalcTypeDefs();            
        }

        ReadOnlySeq<MetadataRoot> CalcMetadataRoots(IDbArchive src)
        {
            var dst = bag<MetadataRoot>();
            iter(GetAssemblyIndex().Distinct(), entry => {
                using var file = EcmaFile.open(entry.Path);
                var reader = file.EcmaReader();
                var memory = reader.Memory(reader.AssemblyKey());
                var root = memory.ReadMetadataRoot();
                dst.Add(root);                
            });
            return dst.Array().Sort();
        }

        ReadOnlySeq<AssemblyMethods> CalcMethods()
        {
            var dispenser = Alloc.Composite();
            var index = GetAssemblyIndex();
            var dst = bag<AssemblyMethods>();
            var distinct = index.Distinct();
            var counter = 0u;
            iter(distinct, entry => {
                using var file = Ecma.file(entry.Path);
                var reader = file.EcmaReader();
                var key = reader.AssemblyKey();
                var methods = reader.ReadMethodInfo().Where(m => !text.contains(m.MethodName, '<') && !text.contains(m.DeclaringType, '<'));
                dst.Add(new AssemblyMethods(new AssemblyFile(entry.Path,key.AssemblyName), methods.Storage));
                if((++counter % 1000) == 0)
                {
                    Channel.Row($"Computed methods for {counter} assemblies");
                }

            },true);
            return dst.Array();
        }

        ReadOnlySeq<AssemblyMethods> GetMethodDefs()
            => CalcMethods();

        FileIndex GetModules()
            => ModuleIndex.GetOrAdd(Source.Root, _ => FS.index(Archives.modules(Source).MemberPaths()));
    
        void Emit(ReadOnlySeq<AssemblyMethods> src)
        {
            iter(src, methods => {                
                if(methods.IsNonEmpty)
                    Channel.TableEmit(methods.View, TablePath<EcmaMethodInfo>("methods", methods.File));
            },true);
        }

        void Emit(ReadOnlySeq<MemberComments> src)
        {
            Channel.TableEmit(src, Target.Table<MemberComments>());
        }

        void Emit(ReadOnlySeq<SectionHeaderRow> src)
        {
            Channel.TableEmit(src, Target.Table<SectionHeaderRow>());
            SectionHeaderRows.TryAdd(Source.Root, src);                
        }

        void Emit(ReadOnlySeq<PeDirectoryRow> src)
        {
            Channel.TableEmit(src, Target.Table<PeDirectoryRow>());
            PeDirectoryRows.TryAdd(Source.Root, src);                
        }

        void Emit(ReadOnlySeq<PeFileInfo> src)
        {
            Channel.TableEmit(src, Target.Table<PeFileInfo>());
            PeFileInfoRows.TryAdd(Source.Root, src);
        }

        void Emit(ReadOnlySeq<EcmaPinvoke> pinvokes)
        {
            Channel.TableEmit(pinvokes, Target.Table<EcmaPinvoke>());
        }

        void Emit(ReadOnlySeq<EcmaDependencySet> src)
        {
            var managed = src.SelectMany(x => x.ManagedDependencies).Sort();
            var native = src.SelectMany(x => x.NativeDependencies).Sort();
            Channel.TableEmit(managed, Target.Table<ManagedDependency>());
            Channel.TableEmit(native, Target.Table<NativeDependency>());
        }

        void EmitStats()
        {
            Channel.TableEmit(GetEcmaStats(), Target.Table<EcmaRowStats>());
        }

        [CmdOp("ecma/heaps")]
        unsafe void EmitEcmaHeaps(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            iter(GetAssemblyIndex().Distinct(), src => {
                using var file = Ecma.file(src.Path);
                var reader = file.EcmaReader();
                var @base = reader.BaseAddress;
                Channel.RowFormat("{0,-16} | {1,-16} | {2,-12} | {3}", HeapIndex.UserString, @base + reader.GetHeapOffset(HeapIndex.UserString), reader.GetHeapSize(HeapIndex.UserString), file.Path);
                Channel.RowFormat("{0,-16} | {1,-16} | {2,-12} | {3}", HeapIndex.String, @base + reader.GetHeapOffset(HeapIndex.String), reader.GetHeapSize(HeapIndex.String), file.Path);
                Channel.RowFormat("{0,-16} | {1,-16} | {2,-12} | {3}", HeapIndex.Blob, @base + reader.GetHeapOffset(HeapIndex.Blob), reader.GetHeapSize(HeapIndex.Blob), file.Path);
                Channel.RowFormat("{0,-16} | {1,-16} | {2,-12} | {3}", HeapIndex.Guid, @base + reader.GetHeapOffset(HeapIndex.Guid), reader.GetHeapSize(HeapIndex.Guid), file.Path);
                {
                    var size = reader.GetHeapSize(HeapIndex.String);
                    if(size != 0)
                    {
                        var start = @base + reader.GetHeapOffset(HeapIndex.String);
                        var data = cover(start.Pointer<byte>(), size);
                        Utf8.decode(data, out var s);
                        iter(s.Split(Chars.Null), x => {
                            if(!text.contains(x, '<'))
                                Channel.Row(x);
                        });

                    }
                }
            });
        }
        
        void EmitTypeDefs()
        {
            var defs = GetTypeDefs();
            iter(defs, def => {
                if(def.IsNonEmpty)
                {
                    Channel.TableEmit(def.View, TablePath<EcmaTypeDef>("types", def.File));
                }
            },true);
        }

        void EmitMetadataRoots()
        {
            Channel.TableEmit(GetMetadataRoots(Source), Target.Table<MetadataRoot>());
        }

        void EmitReports()
        {
            EmitReports(GetAssemblyIndex());
        }

        void EmitReports(AssemblyIndex src)
        {
            Ecma.EmitReports(src, EnvDb);
        }

        void EmitMethodDefs()
        {            
            Emit(GetMethodDefs());
        }

        void EmitDeps()
        {
            Emit(GetDependencies(GetAssemblyIndex()));
        }

        void EmitPinvokes()
        {
            Emit(GetPinvokes());
        }

        [CmdOp("ecma/stats")]
        void EcmaEmitStats(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitStats();
        }

        [CmdOp("ecma/types")]
        void EmitTypeDefs(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitTypeDefs();
        }

        [CmdOp("ecma/roots")]
        void EmitMdHeader(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitMetadataRoots();
        }

        [CmdOp("ecma/comments")]
        void EcmaComments(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            Emit(GetMemberComments());
        }
            
        [CmdOp("ecma/const")]
        void EmitLiterals(CmdArgs args)
        {
            var dst = bag<EcmaConstInfo>();
            Source = FS.archive(args[0]);
            var index = GetAssemblyIndex();
            var seq = 0u;
            iter(index.Distinct(), entry => {
                using var file = Ecma.file(entry.Path);
                var reader = file.EcmaReader();
                iter(reader.ReadConstants(ref seq), k => dst.Add(k));
            }, true);
            Channel.TableEmit(dst.Array(), Target.Table<EcmaConstInfo>());
        }

        [CmdOp("ecma/reports")]
        void EmitEcmaReports(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitReports();
        }

        [CmdOp("ecma/deps")]
        void EmitEcmaDeps(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitDeps();
        }

        [CmdOp("ecma/pinvokes")]
        void PInvokes(CmdArgs args)
        {   Source = FS.archive(args[0]);
            EmitPinvokes();
        }

        [CmdOp("ecma/methods")]
        void EmitEcmaMethods(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitMethodDefs();
        }

        [CmdOp("projects/analyze")]
        void EmitEcmaAnalyses(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitPeInfo();
            EmitPinvokes();
            EmitReports();
            EmitStats();
            EmitDeps();
        }

        [CmdOp("coff/objects")]
        void ReadCoffHeaders(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            var objects = GetModules().Distinct().Where(e => e.Path.Is(FileKind.Obj));
            var formatter = CsvTables.formatter<CoffHeader>();
            var counter = 0u;
            iter(objects, obj => {
                var o = CoffObjects.@object(obj.Path);
                var strings = o.Strings;
                foreach(var symbol in o.Symbols)
                {
                    Channel.Row(string.Format("{0,-48} | {1,-8} | {2,-12} | {3,-8} | {4}", obj.Path.FileName, symbol.Section, symbol.Value, symbol.Type, strings.Text(symbol)));
                }

                foreach(var section in o.SectionHeaders)
                {
                    Channel.Row(string.Format("{0,-12} | {1} | {2}", section.Name, section.PointerToRawData, section.PointerToRelocations));
                }
                
            });
        }

        [CmdOp("libs/docs")]
        void EmitLibDocs(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            var index = GetAssemblyIndex();
            EmitReports(index);
        }

        [CmdOp("memdb/store")]
        void LoadMemDb(CmdArgs args)
        {
            var db = MemDb.open(EnvDb.Path("memdb", FS.ext("dat")), new Gb(1));
            Channel.Row(db.Description.Path);
            Source = FS.archive(args[0]);
            var files = Source.Files();
            var tokens = dict<FilePath, AllocToken>();
            foreach(var file in files)
            {
                var token = db.Store(file.ReadBytes());
                if(token.IsNonEmpty)
                {
                    tokens[file] = token;
                    Channel.Row(string.Format("{0} | {1,-12} | {2}",token.Base + token.Offset, (ByteSize)token.Size, file));
                }
                else
                {
                    Channel.Warn("Capacity exceeded");
                    break;
                }
            }
        }

        unsafe Dictionary<PeDirectoryKind,IImageDirectory> CalcDirectories(PeReader reader)
        {
            var directories = reader.Tables.DirectoryRows;
            var image = reader.GetImage();
            var memory = MemoryReaders.reader(image);
            var dst = dict<PeDirectoryKind,IImageDirectory>();
            iter(directories, d => {
                var kind = d.Kind;
                var data = memory.View(d.Rva, d.Size);
                switch(kind)
                {
                    case PeDirectoryKind.BaseRelocationTable:
                    break;   
                    case PeDirectoryKind.ExportTable:
                        dst[kind] = memory.View<ExportDirectory>(d.Rva);
                    break;   
                    case PeDirectoryKind.ImportTable:
                    break;   
                }
            });

            return dst;
        }
        
        void EmitDirectories()
        {
            var src = GetModules();
            iter(src.Distinct(), entry => {
                try
                {
                    using var reader = PeReader.create(entry.Path);                
                    var directories = CalcDirectories(reader);
                    iter(directories.Keys, k => {
                        var directory = directories[k];
                        Channel.Row(entry.Path, FlairKind.StatusData);
                        Channel.Row(directory.Format());
                    });
                }
                catch(Exception e)
                {
                    Channel.Warn($"{e.Message}: {entry.Path}");
                }
            },false);
        }

        [CmdOp("pe/directories")]
        void EmitPeDirectories(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitDirectories();

        }
        unsafe void EmitPeInfo()
        {
            var index = GetModules();
            var headers = bag<SectionHeaderRow>();
            var dirs = bag<PeDirectoryRow>();
            var info = sys.bag<PeFileInfo>();
            var debug = sys.bag<IMAGE_DEBUG_DIRECTORY>();
            iter(index.Distinct(), entry => {
                try
                {
                    var rel = FS.relative(Source.Root, entry.Path);
                    using var reader = PeReader.create(entry.Path);
                    var tables = reader.Tables;
                    info.Add(reader.PeInfo());
                    iter(tables.SectionHeaders, section => headers.Add(section.WithFile(FS.file(rel.Format()))));
                    iter(tables.DirectoryRows, dir => {
                            if(dir.Size != 0)
                            {
                                dirs.Add(dir);
                                if(dir.Kind == PeDirectoryKind.DebugTable)
                                {
                                    var dbdir = *((IMAGE_DEBUG_DIRECTORY*)reader.ReadSectionData(dir.Entry()).Pointer);
                                    var seg = new MemorySeg<Address32,uint>((Address32)dbdir.AddressOfRawData, dbdir.SizeOfData);
                                    debug.Add(dbdir);

                                }

                            }
                        });  
                    Channel.Row($"Indexed {entry.Path}");
                }
                catch(Exception e)
                {
                    Channel.Warn($"{e.Message}: {entry.Path}");
                }
            }, true);

            exec(true, 
                () => Emit(headers.Array().Sort().Resequence()),
                () => Emit(dirs.Array().Sort().Resequence()), 
                () => Emit(info.Array().Sort().Resequence()));
             
        }
        [CmdOp("pe/info")]
        unsafe void EmitPeInfo(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            EmitPeInfo();
        }
    }
}