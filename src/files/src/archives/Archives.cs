//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Archives : Stateless<Archives>
    {                
        public static FileIndex index(IEnumerable<FilePath> src)
        {
            var dst = new FileIndex();
            dst.Include(src);
            return dst.Seal();
        }

        public static ItemList<uint,string> list(IWfChannel channel, FilePath src)
            => list(channel, src, x => (Outcome<string>)text.trim(x));

        public static ItemList<uint,T> list<T>(IWfChannel channel, FilePath src, Func<string,Outcome<T>> parser)
        {
            var dst = sys.list<ListItem<uint, T>>();
            var counter = 0u;
            var result = Outcome<T>.Empty;
            var line = EmptyString;
            using var reader = src.Utf8Reader();
            while(true)
            {
                line = reader.ReadLine();
                if(empty(line))
                    break;
                
                result = parser(line);
                if(result)
                {
                    dst.Add((counter++, result.Data));
                }
                else
                {
                    channel.Error(result.Message);
                    break;
                }                                
            }
            return dst.Array();            
        }

        public static FileIndex index(IDbArchive src, params FileExt[] ext)
            => index(src.Files(true,ext));

        public static FileIndex index(IDbArchive src, params FileKind[] kinds)
            => index(src.Files(true, kinds));

        public static FolderIndex index(IWfChannel channel, FolderQuery q)
        {
            var flow = channel.Running($"Indexing {q.Root}");
            var index = new FolderIndex();
            iter(FS.folders(q.Root, q.Match, true), folder => index.Include(folder),true);
            channel.Ran(flow);
            return index.Seal();
        }

        public static FileIndex index(IWfChannel channel, FileQuery q)
        {
            var flow = channel.Running($"Indexing {q.Root}");
            var counter = 0u;
            var matcher = FS.matcher(q);
            var index = new FileIndex();
            void Include(FilePath src)
            {
                index.Include(src).OnSuccess(entry => {
                    inc(ref counter);                    
                });

                if(counter % 1000 == 0)
                    channel.Row($"Indexed {counter} files");
            }

            FS.search(q, path => Include(path));
            channel.Ran(flow);
            return index.Seal();
        }

        static FilePath IndexPath(IDbArchive src, FileIndexKind kind, IDbArchive dst)
            => dst.Path(FS.file(name(kind), FileKind.Csv));

        public static ExecToken index(IWfChannel channel, FileQuery q, IDbArchive dst)
        {
            var index = Archives.index(channel,q);
            return channel.TableEmit(index.Sorted(), IndexPath(q.Root.DbArchive(), FileIndexKind.Files, dst));
        }

        public static ExecToken index(IWfChannel channel, FolderQuery q, IDbArchive dst)
        {
            var index = Archives.index(channel,q);
            var target = IndexPath(q.Root.DbArchive(), FileIndexKind.Folders, dst);
            return channel.TableEmit(index.Sorted(), target);
        }

        public static ListedFile listing(FilePath src)
        {
            var dst = new ListedFile();
            var info = new FileInfo(src.Name);
            dst.Size = ((ByteSize)info.Length).Kb;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Path = src;
            dst.Attributes = info.Attributes;
            return dst;
        }

        public static ListedFile listing(FileUri src)
        {
            var dst = new ListedFile();
            var info = new FileInfo(src.ToFilePath().Format(PathSeparator.BS));
            dst.Size = ((ByteSize)info.Length).Kb;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Path = src;
            dst.Attributes = info.Attributes;
            return dst;
        }

        public static ListedFiles listing(FolderPath src, bool recurse)
            => src.Files(recurse).Map(listing).Array();

        public static ListedFiles listing(FolderPath src, bool recurse, params FileKind[] kinds)
            => src.Files(recurse,kinds).Map(listing).Array();

        public static ListedFiles listing(ReadOnlySpan<FileUri> src)
            => src.Select(listing);

        public static ListedFiles listing(ReadOnlySpan<FilePath> src)
            => src.Select(listing);

        [Op]
        public static Task<FileEmission> emissions(IWfChannel channel, Files src, bool uri, FilePath dst)
        {
            var counter  = 0;
            FileEmission run()
            {
                var emission = FileEmission.Empty;
                try
                {
                    var flow = channel.EmittingFile(dst);
                    using var writer = dst.Writer();
                    for(var i=0; i<src.Count; i++)
                    {
                        ref readonly var file = ref src[i];
                        writer.WriteLine(uri ? file.ToUri().Format() : file.Format());
                        counter++;
                    }

                    emission = new FileEmission(channel.EmittedFile(flow), dst, (int)counter);
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
                return emission;
            }
            return sys.start(run);
        }

        public static string name(FileIndexKind kind)
            => kind switch {
                FileIndexKind.Folders => "folders.index",
                FileIndexKind.Files=> "files.index",
                FileIndexKind.Assemblies=> "assemblies.index",
                FileIndexKind.Pe=> "pe.index",
                _ => EmptyString
            };
    }
}