//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System.IO.Compression;
    using Microsoft.Extensions.FileSystemGlobbing;
    using Commands;

    using static ArchiveExecutors;
    using static sys;

    public class Archives
    {        
        public static BuildArchive build(FolderPath root)
            => new BuildArchive(archive(root));
            
        public static void nupkg(IWfChannel channel, CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var packs = Archives.packages(src, PackageKind.Nuget);
            iter(packs, p => channel.Write(p));
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

        [MethodImpl(Inline), Op]
        public static FilePoint point(FilePath src, LineOffset offset)
            => new FilePoint(src,offset);

        [MethodImpl(Inline), Op]
        public static FilePoint point(FilePath src, Count line, Count col)
            => new FilePoint(src, ((uint)line,(uint)col));

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

        public static Task<CmdResult<CreateSymLink,Symlink>> symlink(IWfRuntime wf, CmdArgs args)
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

            return SymlinkExecutor.create(wf).Execute(CmdRunner.context(), cmd);
        }

        public static Task<ExecToken> zip(IWfChannel channel, CmdArgs args)
            => zip(channel, FS.dir(args[0]), FS.path(args[1]));

        public static void copy(IWfChannel channel, CmdArgs args)
            => copy(channel, FS.dir(args[0]), FS.dir(args[1]));
        
        public static Task<ExecToken> copy(IWfChannel channel, FolderPath src, FolderPath dst)
            => CmdRunner.start(channel, FS.path("robocopy.exe"), Cmd.args(src, dst, "/e"));

        public static IModuleArchive modules(FolderPath src, bool recurse = true)
            => new ModuleArchive(src, recurse);

        public record struct CopyFiles(FolderPath Source, FolderPath Target) 
            : ICmdFlow<CopyFiles,FolderPath,FolderPath> {}

        public record struct PackFolder(FolderPath Source, FileUri Target) 
            : ICmdFlow<PackFolder,FolderPath,FileUri> {}

        public static CopyFiles copy(FolderPath src, FolderPath dst)
            => new (src,dst);        

        public static PackFolder pack(FolderPath src, FileUri dst)
            => new (src,dst);        

        public static IEnumerable<FileUri> query(FileQuery spec)
        {
            var filter = spec.Filter;
            var matcher = new Matcher();  
            iter(filter.FileTypes, t => matcher.AddInclude($"${t.SearchPattern}${SearchPattern.Recurse}" ));
            iter(filter.FileKinds, t => matcher.AddInclude($"${t.Ext().SearchPattern}${SearchPattern.Recurse}" ));
            iter(filter.Inclusions, i => matcher.AddInclude(i.Format()));
            iter(filter.Exclusions, x => matcher.AddExclude(x.Format()));        
            var result  = matcher.GetResultsInFullPath(spec.Source.Format());
            foreach(var item in result)
                yield return new FileUri(item);
        }

        public static void search(IWfChannel channel, in CreateFileCatalog cmd, Action<FilePath> dst, bool pll = true)
        {
            var src = cmd.Match.IsEmpty ? DbArchive.enumerate(cmd.Source,"*.*", true) : DbArchive.enumerate(cmd.Source, true, cmd.Match);
            var counter = 0u;
            var flow = channel.Running($"Searching {cmd.Source}");
            string msg()
                => $"Collected {counter} files";

            iter(src, file => {
                dst(file);
                counter++;
                if(counter % 1024 == 0)
                    channel.Babble(msg());
            }, pll);
            channel.Ran(flow, $"Found {counter} files from {cmd.Source}");
        }

        public static void catalog(IWfChannel channel, CmdArgs args)
        {
            CreateFileCatalog.bind(args, out CreateFileCatalog cmd);
            var name = Archives.identifier(cmd.Source);
            var dst = cmd.Target + FS.file(name, FileKind.Csv);
            var running =  channel.Running($"Adding files from {cmd.Source} to catalog");
            var counter = 0u;
            var paths = bag<FilePath>();
            var rows = bag<ListedFile>();
            void Accept(FilePath file)
            {
                paths.Add(file);
                rows.Add(new ListedFile{
                    Seq = counter++,
                    Size = file.Size.Kb,
                    Path = file,
                    CreateTS = file.Info.CreationTime,
                    UpdateTS = file.Info.LastWriteTime,
                    Attributes = file.Info.Attributes
                });                
            }

            Archives.search(channel, cmd, Accept);

            channel.TableEmit(rows.ToSeq().Sort().Resequence(), dst);
            channel.Ran(running, counter);
        }

        public static IDbArchive archive(string src)
            => new DbArchive(FS.dir(src));

        public static IDbArchive archive(FolderPath root)
            => new DbArchive(root);

        public static IDbArchive archive(Timestamp ts, DbArchive dst)
            => dst.Scoped(ts.Format());

        public static FolderPath folder(string src)
            => FS.dir(src);

        public static EnvPath folders(ReadOnlySpan<string> src)
            => src.Map(FS.dir);

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
         
        public static ListedFiles listing(FolderPath src, bool recurse)
            => src.Files(recurse).Map(listing).Array();

        public static ListedFiles listing(FolderPath src, bool recurse, params FileKind[] kinds)
            => src.Files(recurse,kinds).Map(listing).Array();

        public static ListedFiles listing(ReadOnlySpan<FileUri> src)
            => src.Select(listing);

        public static ListedFiles listing(ReadOnlySpan<FilePath> src)
            => src.Select(listing);

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

        public static ZipFile zip(FolderPath src, FilePath dst)
        {
            System.IO.Compression.ZipFile.CreateFromDirectory(src.Format(), dst.Format(), CompressionLevel.Fastest, true);
            return new ZipFile(dst);
        }

        public static string identifier(FolderPath src)
            => src.Format(PathSeparator.FS).Replace(Chars.FSlash, Chars.Dot).Replace(Chars.Colon, Chars.Dot).Replace("..", ".");

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

            var outcome = Time.parse(fmt.RightOfIndex(idx), out var ts);
            if(outcome)
            {
                dst = ts;
                return true;
            }
            else
                return(false,outcome.Message);
        }
    }
}