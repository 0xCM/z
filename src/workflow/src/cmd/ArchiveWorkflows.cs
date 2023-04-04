//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    using Windows;


    class ArchiveWorkflows : WfAppCmd<ArchiveWorkflows>
    {
        ApiMd ApiMd => Wf.ApiMd();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        Ecma Ecma => Wf.Ecma();
        //Alloc Alloc;

        IDbArchive Source;

        Alloc Alloc;

        public ArchiveWorkflows()
        {
            Alloc = Alloc.create();
        }
        
        ConcurrentDictionary<FolderPath,AssemblyIndex> AssemblyIndex = new();

        ConcurrentDictionary<FolderPath,FileIndex> FileIndex = new();

        ConcurrentDictionary<FolderPath,FileIndex> ModuleIndex = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaRowStats>> EcmaStats = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaTypeDef>> EcmaTypeDefs = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<MetadataRoot>> EcmaRoots = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<SectionHeaderRow>> SectionHeaderRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<PeDirectoryRow>> PeDirectoryRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<PeFileInfo>> PeFileInfoRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<MemberComments>> MemberCommentRows = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaDependencySet>> EcmaDependencySets = new();

        AssemblyIndex GetAssemblyIndex(IDbArchive src)
            => AssemblyIndex.GetOrAdd(src.Root,  _ => Ecma.index(Channel, src));

        AssemblyIndex GetAssemblyIndex()
            => AssemblyIndex.GetOrAdd(Source.Root,  _ => Ecma.index(Channel, Source));

        ReadOnlySeq<EcmaRowStats> GetEcmaStats(IDbArchive src)
            => EcmaStats.GetOrAdd(src.Root, _ => Ecma.stats(GetAssemblyIndex(src)));

        FileIndex GetFileIndex(IDbArchive src)
            => FileIndex.GetOrAdd(src.Root, _ => FS.index(src.Files()));

        ReadOnlySeq<EcmaTypeDef> CalcTypeDefs(IDbArchive src)
        {
            var dst = bag<EcmaTypeDef>();
            iter(GetAssemblyIndex(src).Distinct(), file => {
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
            iter(GetAssemblyIndex(src).Distinct(), entry => {
                using var file = EcmaFile.open(entry.Path);
                var reader = file.EcmaReader();
                var memory = reader.Memory(reader.AssemblyKey());
                var root = memory.ReadMetadataRoot();
                dst.Add(root);                
            });
            return dst.Array().Sort();
        }

        ReadOnlySeq<MetadataRoot> GetMetadataRoots(IDbArchive src)
            => EcmaRoots.GetOrAdd(src.Root, _ => CalcMetadataRoots(src));

        ReadOnlySeq<EcmaTypeDef> GetTypeDefs(IDbArchive src)
            => EcmaTypeDefs.GetOrAdd(src.Root, _ => CalcTypeDefs(src));

        [CmdOp("ecma/stats")]
        void EcmaEmitStats(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            Channel.TableEmit(GetEcmaStats(Source), EnvDb.Nested("ecma", Source).Table<EcmaRowStats>());                        
        }

        [CmdOp("ecma/typedefs")]
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

        ReadOnlySeq<MemberComments> CalcMemberComments()
        {            
            var comments = Ecma.comments(Channel, Source);
            var dst = bag<MemberComments>();
            iter(comments.Commented, name => {
                iter(comments.Comments(name).Values, x => dst.Add(x));                
            }, true);
            return dst.Array().Sort();
        }

        ReadOnlySeq<MemberComments> GetMemberComments()
            =>  MemberCommentRows.GetOrAdd(Source.Root, _ => CalcMemberComments());

        [CmdOp("ecma/comments")]
        void EcmaComments(CmdArgs args)
        {
            Source = FS.archive(args[0]);
            Channel.TableEmit(GetMemberComments(), EnvDb.Nested("ecma", Source).Table<MemberComments>());
        }

        ReadOnlySeq<EcmaDependencySet> GetDependencies(AssemblyIndex src)
            => EcmaDependencySets.GetOrAdd(src.Source.Root, _ => Ecma.CalcDependencies(src,EnvDb));        
            
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
        
        void Emit(ReadOnlySeq<EcmaDependencySet> src)
        {
            var managed = src.SelectMany(x => x.ManagedDependencies).Sort();
            var native = src.SelectMany(x => x.NativeDependencies).Sort();
            Channel.TableEmit(managed, EnvDb.Nested("ecma", Source).Table<ManagedDependency>());
            Channel.TableEmit(native, EnvDb.Nested("ecma", Source).Table<NativeDependency>());
        }

        [CmdOp("ecma/methods")]
        void EmitEcmaMethods(CmdArgs args)
        {
            var dispenser = Alloc.Strings();
            var src = FS.archive(args[0]);
            var index = Ecma.index(Channel, src);

            index.Report(EnvDb.Nested("ecma", src));

            var keys = bag<MemberKey>();
            var distinct = index.Distinct();
            var counter = 0u;
            iter(distinct, entry => {
                using var file = Ecma.file(entry.Path);
                var reader = file.EcmaReader();
                var key = reader.AssemblyKey();
                var methods = reader.ReadMethodDefs().Where(m => !text.contains(m.MethodName, '<') && !text.contains(m.DeclaringType, '<'));
                iter(methods, method => {
                    keys.Add(Ecma.key(dispenser,method));
                });
            },true);
            
            Channel.TableEmit(keys.Array().Sort(), EnvDb.Nested("ecma", src).Table<MemberKey>());
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
    }
}