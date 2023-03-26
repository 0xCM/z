//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;
    using System.Linq;
    using Microsoft.Extensions.FileSystemGlobbing;

    using Commands;

    using static sys;

    [ApiHost]
    public class Archives
    {        
        public static FileTypes FileTypes(params Assembly[] src)
            => new (src.Types().Tagged<FileTypeAttribute>().Concrete().Map(x => (IFileType)Activator.CreateInstance(x)).ToHashSet());     

        static void exec(IWfChannel channel, CatalogFiles cmd)
            => index(channel, query(cmd.Source, cmd.Match), cmd.Target.DbArchive());

        internal static FileIndexEntry IndexEntry(FilePath src)
        {
            var hash = FS.hash(src);
            var dst = new FileIndexEntry();
            dst.Path = src;
            dst.FileHash = hash.FileHash;
            return dst;
        }

        static FilePath IndexPath(IDbArchive src, IDbArchive dst)
            =>  dst.Path(FS.file($"files.index", FileKind.Csv));

        public static ExecToken<FilePath> index(IWfChannel channel, FileQuery query, IDbArchive dst)
        {
            var flow = channel.Running($"Indexing {query.Root}");
            var buffer = cdict<FileHash,FileIndexEntry>();
            var counter = 0u;
            Archives.query(channel, query, path => {
                var entry = Archives.IndexEntry(path);
                if(entry.IsNonEmpty)
                {
                    buffer.TryAdd(entry.FileHash, entry);
                    sys.inc(ref counter);

                    if(counter%1000 == 0)
                        channel.Row($"Indexed {counter} files");
                }                
            });

            var target = IndexPath(query.Root.DbArchive(), dst);
            var entries = buffer.Values.Array().Sort().Resequence();
            return(channel.TableEmit(entries, target), target);
        }

        public static FileQuery query(FolderPath src, params FileExt[] ext)
        {
            var dst = new FileQuery();
            var filter = FileFilter.Empty;
            if(ext.Length != 0)
                filter.Extensions = ext;
            else
                filter.Inclusions = array(SearchPattern.All);
            dst.Root = src;
            dst.Filter = filter;
            return dst;
        }

        [MethodImpl(Inline), Op]
        static SearchPattern pattern(params string[] src)
            => string.Join(Chars.Pipe, src);

        public static FileQuery query(FolderPath src, string match, params FileExt[] ext)
        {
            var dst = new FileQuery();
            var filter = FileFilter.Empty;
            filter.Extensions = ext;
            filter.Inclusions = array(pattern(match));
            dst.Root = src;
            dst.Filter = filter;
            return dst;
        }

        public static Matcher matcher(FileQuery query)
        {
            var matcher = new Matcher();  
            var filter = query.Filter;
            iter(filter.Extensions, t => matcher.AddInclude($"${t.SearchPattern}${Z0.SearchPattern.All}" ));
            iter(filter.FileKinds, t => matcher.AddInclude($"${t.Ext().SearchPattern}${Z0.SearchPattern.All}" ));
            iter(filter.Inclusions, i => matcher.AddInclude(i.Format()));
            iter(filter.Exclusions, x => matcher.AddExclude(x.Format()));
            return matcher;
        }

        public static ExecToken query(IWfChannel channel, FileQuery query, Action<FilePath> dst)        
        {
            var running = channel.Running($"Executing query over {query.Root}");
            var matcher = Archives.matcher(query);
            iter(matcher.GetResultsInFullPath(query.Root.Format()), f => dst(FS.path(f)), true);
            return channel.Ran(running);
        }

        public static FolderPath nested(FolderPath root, FilePath src)
            => root + FS.folder(FS.components(src.FolderPath).Join('/'));

        public static FolderPath nested(FolderPath root, FolderPath src)
            => root + FS.folder(FS.components(src).Join('/'));

        static AppSettings AppSettings => AppSettings.Default;

        public static IDbArchive archive(Timestamp ts, DbArchive dst)
            => dst.Scoped(ts.Format());

        public static LineMap<string> map<T>(Index<TextLine> lines, Index<T> relations)
            where T : struct, ILineRelations<T>
        {
            const uint BufferLength = 256;
            var count = relations.Length;
            var buffer = span<TextLine>(BufferLength);
            var intervals = list<LineInterval<string>>();
            for(var i=0;i<count; i++)
            {
                ref readonly var relation = ref relations[i];
                var k=0;
                buffer.Clear();
                var index = relation.SourceLine.Value;
                for(var j=index; j<lines.Count && k<BufferLength; j++)
                {
                    ref readonly var line = ref lines[j];
                    if(SQ.index(line.Content, Chars.RBrace) != 0)
                        seek(buffer,k++) = line;
                    else
                        break;
                }

                if(k>0)
                    intervals.Add(Lines.interval(relation.Name, first(buffer).LineNumber, skip(buffer,k-1).LineNumber));
            }

            return Lines.map(intervals.ToArray());
        }

        public static EnvPath folders(ReadOnlySpan<string> src)
            => src.Map(FS.dir);

        public static IDbArchive archive(string src)
            => new DbArchive(FS.dir(src));

        public static IDbArchive archive(FolderPath root)
            => new DbArchive(root);


        public static IModuleArchive modules(FolderPath src, bool recurse = true)
            => new ModuleArchive(src, recurse);

        public static ReadOnlySeq<Assembly> parts(FolderPath src)
        {
            var modules = Archives.modules(src,false).Members().Where(x => FS.managed(x.Path) && !x.Path.FileName.Contains("System.Private.CoreLib"));
            return modules.Where(m => m.Path.FileName.StartsWith("z0.")).Map(x => Assembly.LoadFile(x.Path.Format()));
        }

        public static ExecToken symlink(IWfChannel channel, CmdArgs args)
        {
            var a0 = args[0].Value;
            var a1 = args[1].Value;
            var result = Outcome.Failure;
            var isfile = (new FileInfo(a0)).Exists;
            var cmd = CreateSymLink.Empty;        
            if(isfile)
                cmd = new (FS.path(a0), FS.path(a1), true);
            else
                cmd = new (FS.dir(a0), FS.dir(a1), true);

            var running = channel.Running();
            if(cmd.Kind == Windows.SymLinkKind.File)
                result = FS.symlink((FilePath)cmd.Source, (FilePath)cmd.Target, cmd.Overwrite);
            else
                result = FS.symlink((FolderPath)cmd.Source, (FolderPath)cmd.Target, cmd.Overwrite);
            return channel.Ran(running);
        }

        public static void catalog(IWfChannel channel, CmdArgs args)
        {
            bind(args, out CatalogFiles cmd);
            exec(channel, cmd);
        }

        public static Task<ExecToken> zip(IWfChannel channel, CmdArgs args)
            => zip(channel, FS.dir(args[0]), FS.path(args[1]));

        public static Task<ExecToken> zip(IWfChannel channel, FolderPath src, FilePath dst)
        {
            ExecToken run()
            {
                var msg = $"{src} -> {dst}";
                var running = channel.Running(msg);
                zip(src, dst);
                return channel.Ran(running, msg); 
            }
            return start(run);
        }

        static Task<ExecToken> ungzip(IWfChannel channel, FilePath src, FilePath dst)
        {
            ExecToken run()
            {
                var running = channel.Running($"Extracting {src} to {dst}");
                using (var stream = src.Stream())
                {
                    using(var expansion = new GZipStream(stream, CompressionMode.Decompress))
                    using (var target = dst.Stream())
                    {
                        expansion.CopyTo(target);
                    }

                }
                return channel.Ran(running, $"Extracted {src} to {dst}");
            }
            return start(run);
        }

        public static Task<ExecToken> unzip(IWfChannel channel, FilePath src, FolderPath dst)
        {
            ExecToken run()
            {
                var running = channel.Running($"Extracting {src} to {dst}");
                using (var stream = src.Stream())
                {
                    var zip = new ZipArchive(stream);
                    foreach (var entry in zip.Entries)
                    {
                        var extractedFilePath = (dst + FS.file(entry.FullName)).CreateParentIfMissing();
                        using (var zfs = entry.Open())
                        {
                            using (var extractedFileStream = extractedFilePath.Stream())
                                zfs.CopyTo(extractedFileStream);
                        }
                    }
                }
                return channel.Ran(running, $"Extracted {src} to {dst}");
            }
            return start(run);
        }
        
        public static ZipFile zip(FolderPath src, FilePath dst)
        {
            System.IO.Compression.ZipFile.CreateFromDirectory(src.Format(), dst.Format(), CompressionLevel.Fastest, true);
            return new ZipFile(dst);
        }

        public static Outcome bind(CmdArgs src, out CatalogFiles dst)
        {
            dst = new();
            dst.Target = AppSettings.EnvDb().Scoped("files");
            var count = src.Count;
            try
            {
                if(count >= 1)
                    dst.Source = FS.dir(src[0]);
                
                if(count >= 2)
                    switch(src[1].Value)
                    {
                        case "--ext":
                        dst.Match = sys.map(text.split(src[2].Value, Chars.Semicolon), x => FS.ext(x));
                        break;
                    }
            }
            catch(Exception e)
            {
                return e;
            }
        
            return true;
        }   

        [Op]
        public static string format(ListedFiles src)
        {
            var dst = text.emitter();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void render(ListedFiles src, ITextEmitter dst)
        {
            var formatter = CsvTables.formatter<ListedFile>();
            dst.AppendLine(formatter.FormatHeader());
            for(var i=0u; i<src.Count; i++)
                dst.AppendLine(formatter.Format(src[i]));
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

        public static void nupkg(IWfChannel channel, CmdArgs args)
        {
            var src = FS.dir(args[0]);
            iter(packages(src, PackageKind.Nuget), p => channel.Write(p));
        }

        public static FileKind filekind(PackageKind src)
            => src switch{
                PackageKind.Zip => FileKind.Zip,
                PackageKind.Nuget => FileKind.Nuget,
                PackageKind.Msi => FileKind.Msi,
                _ => FileKind.None
            };

        public static ReadOnlySeq<Package> packages(FolderPath src, PackageKind kind)
        {
            var files = src.EnumerateFiles(filekind(kind).Ext(), true).ToSeq();
            var count = files.Count;
            var dst = alloc<Package>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var uri = $"file://{file.Name.Text}";
                seek(dst,i) = package(new FileUri(uri));
            }
            return dst;
        }

        public static Package package(FileUri src)
        {
            var kind = src.Ext().FileKind();
            var dst = default(Package);
            switch(kind)
            {
                case FileKind.Zip:
                    dst = new ZipFile(src);
                break;
                case FileKind.Msi:
                    dst = new MsiFile(src);
                break;
                case FileKind.Nuget:
                    dst = new NugetPackge(src);
                break;
                default:
                    sys.@throw($"File type for '{src}' unknown");
                break;
            }
            return dst;
        }
         

        [Parser]
        public static bool parse(string src, out FilePoint dst)
        {
            dst = FilePoint.Empty;
            var indices = text.indices(src,Chars.Colon);
            if(indices.Length < 2)
                return false;

            var j = indices.Length -1;
            ref readonly var i0 = ref indices[j-1];
            ref readonly var i1 = ref indices[j];
            var l = text.inside(src,i0,i1);
            var c = text.right(src, i1);
            if(uint.TryParse(l, out var line) && uint.TryParse(c, out var col))
            {
                var loc = (line,col);
                var path = FS.path(text.left(src,i0));
                dst = new FilePoint(path,loc);
            }
            return true;
        }

       public static string identifier(FolderPath src)
            => FS.identifier(src);

        public static FileName timestamped(string name, FileExt ext)
            => FS.file(string.Format("{0}.{1}", name, (sys.timestamp()).Format()),ext);

        [Op]
        public static FilePath timestamped(FilePath src)
        {
            var name = src.FileName.WithoutExtension;
            var ext = src.Ext;
            var stamped = FS.file(string.Format("{0}.{1}.{2}", name, sys.timestamp(), ext));
            return src.FolderPath + stamped;
        }

        public static Outcome timestamp(FolderPath src, out Timestamp dst)
        {
            dst = Timestamp.Zero;
            if(src.IsEmpty)
                return false;

            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;

            var outcome = Timing.parse(fmt.RightOfIndex(idx), out dst);
            if(outcome)
            {
                return true;
            }
            else
                return(false, outcome.Message);
        }        
    }
}