//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class ArchiveWorkflows : WfAppCmd<ArchiveWorkflows>
    {
        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        StringDispenser StringDispenser;

        public ArchiveWorkflows()
        {
            
        }
        ConcurrentDictionary<FolderPath,AssemblyIndex> Assemblies = new();

        new ConcurrentDictionary<FolderPath,FileIndex> Files = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaRowStats>> EcmaStats = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<EcmaTypeDef>> EcmaTypeDefs = new();

        ConcurrentDictionary<FolderPath,ReadOnlySeq<MetadataRoot>> EcmaRoots = new();

        AssemblyIndex GetAssemblyIndex(IDbArchive src)
            => Assemblies.GetOrAdd(src.Root,  _ => Ecma.index(Channel, src));

        ReadOnlySeq<EcmaRowStats> GetEcmaStats(IDbArchive src)
            => EcmaStats.GetOrAdd(src.Root, _ => Ecma.stats(GetAssemblyIndex(src)));

        FileIndex GetFileIndex(IDbArchive src)
            => Files.GetOrAdd(src.Root, _ => FS.index(src.Files()));

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
            var src = FS.archive(args[0]);
            Channel.TableEmit(GetEcmaStats(src), EnvDb.Nested("ecma", src).Table<EcmaRowStats>());                        
        }

        [CmdOp("ecma/typedefs")]
        void EmitTypeDefs(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            Channel.TableEmit(GetTypeDefs(src), EnvDb.Nested("ecma", src).Table<EcmaTypeDef>());
        }

        [CmdOp("ecma/roots")]
        void EmitMdHeader(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            Channel.TableEmit(GetMetadataRoots(src), EnvDb.Nested("ecma", src).Table<MetadataRoot>());
        }
        
        [CmdOp("memdb/store")]
        void LoadMemDb(CmdArgs args)
        {
            var db = MemDb.open(EnvDb.Path("memdb", FS.ext("dat")), new Gb(1));
            Channel.Row(db.Description.Path);
            var src = FS.archive(args[0]);
            var files = src.Files();
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
    }
}