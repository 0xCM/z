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

    public class Archives : ApiModule<Archives>
    {        
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


        public static Task<ExecToken> symlink(IWfChannel channel, CmdArgs args)
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

            return Symlink.create().Execute(channel, CmdRunner.context(), cmd);
        }

        public static void zip(IWfChannel channel, CmdArgs args)
        {
            var folder = Cmd.arg(args,0).Value;
            var i = text.index(folder, Chars.FSlash, Chars.BSlash);
            var scope = "default";
            if(i > 0)
                scope = text.left(folder,i);
            var src = AppSettings.DbRoot().Scoped(folder).Root;
            var name = src.FolderName.Format();
            var file = FS.file($"{scope}.{name}", FileKind.Zip);
            zip(channel, src, AppDb.Archive(scope).Path(file));
        }

        public static void copy(IWfChannel channel, CmdArgs args)
            => copy(channel, FS.dir(args[0]), FS.dir(args[1]));
        
        public static Task<ExecToken> copy(IWfChannel channel, FolderPath src, FolderPath dst)
            => CmdRunner.start(channel, FS.path("robocopy.exe"), Cmd.args(src, dst, "/e"));

        public static IModuleArchive modules(FolderPath src)
            => new ModuleArchive(src);

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

        public static void catalog(IWfChannel channel, CmdArgs args)
        {
            CatalogFiles.bind(args, out CatalogFiles cmd);
            var name = identifier(cmd.Source);
            var list = cmd.Target + FS.file(name, FileKind.List);
            var src = cmd.Match.IsEmpty ? DbArchive.enumerate(cmd.Source,"*.*", true) : DbArchive.enumerate(cmd.Source, true, cmd.Match);
            var counter = 0u;
            string msg()
                => $"Collected {counter} files";

            var files = bag<FileUri>();
            iter(src, file => {
                files.Add(file);
                counter++;
                if(counter % 1024 == 0)
                    channel.Babble(msg());
            }, true);
            channel.Babble(msg());

            var collected = files.ToSeq();
            var listing = Archives.listing(collected.View);            
            channel.TableEmit(listing, cmd.Target + FS.file(name,FileKind.Csv));
            var flow = channel.EmittingFile(list);
            using var writer = list.Utf8Writer();
            counter =0;
            foreach(var file in files)
            {
                writer.AppendLine(file.ToFilePath().ToUri());
                counter++;
            }
            channel.EmittedFile(flow, counter);
        }

        public static IDbArchive archive(string src)
            => new DbArchive(FS.dir(src));

        public static IDbArchive archive(FolderPath root)
            => new DbArchive(root);

        public static IDbArchive archive(Timestamp ts, DbArchive dst)
            => dst.Scoped(ts.Format());

        public static FolderPath folder(string src)
            => FS.dir(src);

        public static FolderPaths folders(ReadOnlySpan<string> src)
            => src.Map(FS.dir);

        public static Task<ExecToken> zip(IWfChannel channel, FolderPath src, FilePath dst)
        {
            var uri = $"{app}://db/zip";
            var running = channel.Running(uri);

            ExecToken run()
            {
                zip(src, dst);
                return channel.Ran(running, uri); 
            }

            return @try(run, e => channel.Completed(running, typeof(Archives), e));
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

        public static ZipFile zip(FolderPath src, FileUri dst)
        {
            System.IO.Compression.ZipFile.CreateFromDirectory(src.Name, dst.Format(), CompressionLevel.Fastest, true);
            return new ZipFile(dst);
        }

        public static ExecToken zip(FolderPath src, FilePath dst, WfEmit channel)
        {
            var uri = $"app://archives/zip?src={src}?dst={dst.ToUri()}";
            var flow = channel.EmittingFile(dst);
            zip(src, dst);
            return channel.EmittedBytes(flow, dst.Size);
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