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
    using static EcmaModels;

    class EcmaFlows : WfAppCmd<EcmaFlows>
    {
        ApiMd ApiMd => Wf.ApiMd();

        Ecma Ecma => Wf.Ecma();

        IDbArchive Source;

        Alloc Alloc;

        public EcmaFlows()
        {
            Alloc = Alloc.create();
        }
        
        ConcurrentDictionary<FolderPath,AssemblyIndex> AssemblyIndex = new();

        ConcurrentDictionary<FolderPath,FileIndex> ModuleIndex = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaRowStats>> EcmaStats = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaTypeDef>> EcmaTypeDefs = new();

        ConcurrentDictionary<FolderPath,AssemblyFiles> AssemblyFiles = new();

        ConcurrentDictionary<FilePath,ReadOnlySeq<EcmaModels.Methods>> MethodDefs = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<MetadataRoot>> EcmaRoots = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<SectionHeaderRow>> SectionHeaderRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<PeDirectoryRow>> PeDirectoryRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<PeFileInfo>> PeFileInfoRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<MemberComments>> MemberCommentRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaDependencySet>> EcmaDependencySets = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaPinvoke>> EcmaPinvokes = new();

        AssemblyFiles GetAssemblyFiles()
            => AssemblyFiles.GetOrAdd(Source.Root, _ => Ecma.assemblies(Channel,Source));

        AssemblyIndex GetAssemblyIndex()
            => AssemblyIndex.GetOrAdd(Source.Root,  _ => Ecma.index(Channel, GetAssemblyFiles()));

        ReadOnlySeq<EcmaRowStats> GetEcmaStats()
            => EcmaStats.GetOrAdd(Source.Root, _ => Ecma.stats(GetAssemblyIndex()));

        ReadOnlySeq<MetadataRoot> GetMetadataRoots(IDbArchive src)
            => EcmaRoots.GetOrAdd(src.Root, _ => CalcMetadataRoots(src));

        ReadOnlySeq<EcmaTypeDef> GetTypeDefs(IDbArchive src)
            => EcmaTypeDefs.GetOrAdd(src.Root, _ => CalcTypeDefs(src));

        ReadOnlySeq<MemberComments> GetMemberComments()
            =>  MemberCommentRows.GetOrAdd(Source.Root, _ => Ecma.CalcMemberComments(Source));

        ReadOnlySeq<EcmaDependencySet> GetDependencies(AssemblyIndex src)
            => EcmaDependencySets.GetOrAdd(src.Source.Root, _ => Ecma.CalcDependencies(src));        

        ReadOnlySeq<EcmaTypeDef> CalcTypeDefs(IDbArchive src)
        {
            var dst = bag<EcmaTypeDef>();
            iter(GetAssemblyIndex().Distinct(), file => {
            using var ecma = Ecma.file(file.Path);
            var reader = Ecma.reader(ecma);
            iter(reader.ReadTypeDefs(), t => {
                if(!t.Name.Contains("<") && !t.DeclaringType.Contains("<"))
                    dst.Add(t);
            }                
            );
                
            }, true);
            return dst.Array().Sort();
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

        [CmdOp("ecma/stats")]
        void EcmaEmitStats(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            Channel.TableEmit(GetEcmaStats(), EnvDb.Nested("ecma", Source).Table<EcmaRowStats>());                        
        }

        [CmdOp("ecma/types")]
        void EmitTypeDefs(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            Channel.TableEmit(GetTypeDefs(Source), EnvDb.Nested("ecma", Source).Table<EcmaTypeDef>());
        }

        [CmdOp("ecma/roots")]
        void EmitMdHeader(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            Channel.TableEmit(GetMetadataRoots(Source), EnvDb.Nested("ecma", Source).Table<MetadataRoot>());
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
            Channel.TableEmit(dst.Array(), EnvDb.Nested("ecma", Source).Table<EcmaConstInfo>());
        }

        [CmdOp("ecma/reports")]
        void EmitEcmaReports(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            var index = GetAssemblyIndex();
            Ecma.EmitReports(index, EnvDb);
        }

        [CmdOp("ecma/deps")]
        void EmitEcmaDeps(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            var index = GetAssemblyIndex();
            var deps = GetDependencies(index);
            Emit(deps);
        }
        
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

        [CmdOp("ecma/pinvokes")]
        void PInvokes(CmdArgs args)
        {   Source = FS.archive(args[0]);
            Emit(GetPinvokes());
        }

        ReadOnlySeq<EcmaModels.Methods> CalcEcmaMethods()
        {
            var dispenser = Alloc.Composite();
            var index = GetAssemblyIndex();
            var dst = bag<EcmaModels.Methods>();
            var distinct = index.Distinct();
            var counter = 0u;
            iter(distinct, entry => {
                using var file = Ecma.file(entry.Path);
                var reader = file.EcmaReader();
                var key = reader.AssemblyKey();
                var methods = reader.ReadMethodDefs().Where(m => !text.contains(m.MethodName, '<') && !text.contains(m.DeclaringType, '<'))
                    .Map(m => new EcmaModels.Method(Ecma.key(dispenser, m), m));
                dst.Add(new (key, entry.Path, methods));
                if((++counter % 1000) == 0)
                {
                    Channel.Row($"Computed methods for {counter} assemblies");
                }

            },true);
            return dst.Array();
        }

        ReadOnlySeq<EcmaModels.Methods> GetMethodDefs()
            => CalcEcmaMethods();

        [CmdOp("ecma/methods")]
        void EmitEcmaMethods(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            var defs = GetMethodDefs();
            var lookup = defs.GroupBy(x => x.AssemblyName).Map(x => (x.Key, x.ToHashSet())).ToDictionary();
            iter(lookup.Keys, k => {
                var value = lookup[k];
                if(value.Count > 1)
                {
                    iter(value, v => Channel.Row(v.AssemblyPath));
                }
            });
            
            //Channel.TableEmit(keys.Array().Sort(), EnvDb.Nested("ecma", Source).Table<MemberKey>());
        }

        void Emit(ReadOnlySeq<EcmaModels.Methods> src)
        {
            iter(src, m => {
                var root = EnvDb.Scoped("ecma");
                var folder = EnvDb.Nested("ecma", Source);
                var dst =  EnvDb.Nested("ecma", Source).Path(FS.file($"{m.AssemblyKey.Name}.{m.AssemblyKey.Version}.{m.Hash}.ecma.methods", FileKind.Csv));                
                Channel.TableEmit(m.View, dst);
            },true);

        }
        [CmdOp("ecma/analyze")]
        void EmitEcmaAnalyses(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            Emit(GetMethodDefs());
            Emit(GetPinvokes());
            
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

        FileIndex Modules()
            => ModuleIndex.GetOrAdd(Source.Root, _ => FS.index(Archives.modules(Source).MemberPaths()));

        [CmdOp("pe/info")]
        unsafe void EmitPeInfo(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            var index = Modules();
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

        void Emit(ReadOnlySeq<MemberComments> src)
        {
            Channel.TableEmit(src, EnvDb.Nested("ecma", Source).Table<MemberComments>());
        }

        void Emit(ReadOnlySeq<SectionHeaderRow> src)
        {
            Channel.TableEmit(src, EnvDb.Nested("pe", Source).Table<SectionHeaderRow>());
            SectionHeaderRows.TryAdd(Source.Root, src);                
        }

        void Emit(ReadOnlySeq<PeDirectoryRow> src)
        {
            Channel.TableEmit(src, EnvDb.Nested("pe", Source).Table<PeDirectoryRow>());
            PeDirectoryRows.TryAdd(Source.Root, src);                
        }

        void Emit(ReadOnlySeq<PeFileInfo> src)
        {
            Channel.TableEmit(src, EnvDb.Nested("pe", Source).Table<PeFileInfo>());
            PeFileInfoRows.TryAdd(Source.Root, src);
        }

        void Emit(ReadOnlySeq<EcmaPinvoke> pinvokes)
        {
            var path = EnvDb.Nested("ecma", Source).Path("ecma.pinvokes", FileKind.Csv);
            Channel.TableEmit(pinvokes, path);
        }

        void Emit(ReadOnlySeq<EcmaDependencySet> src)
        {
            var managed = src.SelectMany(x => x.ManagedDependencies).Sort();
            var native = src.SelectMany(x => x.NativeDependencies).Sort();
            Channel.TableEmit(managed, EnvDb.Nested("ecma", Source).Table<ManagedDependency>());
            Channel.TableEmit(native, EnvDb.Nested("ecma", Source).Table<NativeDependency>());
        }
    }
}