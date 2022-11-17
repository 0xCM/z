//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System.IO.Compression;

    using Microsoft.Extensions.FileSystemGlobbing;

    using static sys;
    using static Archives.CommandNames;

    public class Archives : ApiModule<Archives>
    {        
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
            Archives.zip(channel, src, AppDb.Archive(scope).Path(file));
        }

        public static void copy(IWfChannel channel, CmdArgs args)
            => copy(channel, FS.dir(args[0]), FS.dir(args[1]));
        
        public static Task<ExecToken> copy(IWfChannel channel, FolderPath src, FolderPath dst)
            => Cmd.start(channel, FS.path("robocopy.exe"), Cmd.args(src, dst, "/e"));

        public class CommandNames 
        {
            public const string FilesGather = "files/gather";

            public const string FilesCopy = "files/copy";

            public const string FilesPack = "files/pack";
        }

        public static IModuleArchive modules(FolderPath src)
            => new ModuleArchive(src);

        [Cmd(FilesCopy)]
        public record struct CopyFiles(FolderPath Source, FolderPath Target) 
            : IApiCmdFlow<CopyFiles,FolderPath,FolderPath> {}

        [Cmd(FilesPack)]
        public record struct PackFolder(FolderPath Source, FileUri Target) 
            : IApiCmdFlow<PackFolder,FolderPath,FileUri> {}

        [Cmd(FilesGather)]
        public record struct GatherFiles(FolderPath Source, FolderPath Target, FileExt Ext) 
            : IApiCmdFlow<GatherFiles,FolderPath,FolderPath> {}

        [MethodImpl(Inline), CmdFx(FilesCopy)]
        public static CopyFiles copy(FolderPath src, FolderPath dst)
            => new (src,dst);        

        [MethodImpl(Inline), CmdFx(FilesPack)]
        public static PackFolder pack(FolderPath src, FileUri dst)
            => new (src,dst);        

        [MethodImpl(Inline), CmdFx]
        public static GatherFiles gather(FolderPath src, FolderPath dst, FileExt ext)
            => new (src,dst,ext);

        [CmdOp(FilesGather)]
        public static Task<ExecToken> gather(IWfChannel channel, CmdArgs args)
            => exec(channel, gather(FS.dir(args[0]), FS.dir(args[1]), FileKind.Nuget.Ext()));

        static Task<ExecToken> exec(IWfChannel channel, GatherFiles cmd)
        {
            ExecToken exec()
            {
                var flow = channel.Running(cmd);
                var paths = cmd.Source.Files(cmd.Ext,true);
                iter(paths, src => {
                    var dst = src.CopyTo(cmd.Target);
                    channel.Babble($"Copied {src} -> {dst}");
                });
                return channel.Ran(flow);
            }

            return start(exec);            
        }

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

        public static ListedFiles catalog(IWfChannel channel, CmdArgs args)
        {
            var files = bag<FileUri>();
            var table = FilePath.Empty;
            var list = FilePath.Empty;
            var name = identifier(FS.dir(args[0]));
            var src = query(channel,args);
            var counter = 0u;

            string msg()
                => $"Collected {counter} files";

            iter(src, file => {
                files.Add(file);
                counter++;
                if(counter % 1024 == 0)
                    channel.Babble(msg());
            }, true);
            channel.Babble(msg());

            var collected = files.ToSeq();
            var listing = Archives.listing(collected.View);
            
            if(args.Count >=2)    
            {
                table = FS.dir(args[1]) + Tables.filename<ListedFile>(name);
                list = FS.dir(args[1]) + FS.file(name, FileKind.List);
            }
            else
            {
                table = AppDb.Service.Catalogs("files").Table<ListedFile>(name);
                list = AppDb.Service.Catalogs("files").Path(name, FileKind.List);
            }

            channel.TableEmit(listing, table);
            var flow = channel.EmittingFile(list);
            using var writer = list.Utf8Writer();
            counter =0;
            foreach(var file in files)
            {
                writer.AppendLine(file.ToFilePath().ToUri());
                counter++;
            }
            channel.EmittedFile(flow, counter);
            return listing;
        }

        static IEnumerable<FileUri> query(IWfChannel channel, CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var files = default(IEnumerable<FileUri>);
            var it = default(IEnumerator<FileUri>);
            if(args.Count > 1)
            {
                var kinds = args.Values().Span().Slice(1).Select(x => FS.kind(FS.ext(x))).Where(x => x!=0);
                iter(kinds, kind => channel.Babble(kind));
                files = DbArchive.enumerate(src,true,kinds); 
            }
            else
            {
                files = DbArchive.enumerate(src,"*.*", true);
            }            

            it = files.GetEnumerator();
            var file = next(channel,it, out var @continue);
            while(@continue)
            {
                if(file.IsNonEmpty)
                    yield return file;
                
                if(!@continue)
                    break;
                file = next(channel,it, out @continue);
            }
        }

        static FileUri next(IWfChannel channel, IEnumerator<FileUri> src, out bool @continue)
        {
            var file = FileUri.Empty;            
            try
            {
                @continue = src.MoveNext();
                file = src.Current;
            }
            catch(Exception e)
            {
                channel.Babble($"Trapped {e}");
                @continue = true;
            }
            return file;
        }


        public static DbArchive archive(string src)
            => new DbArchive(FS.dir(src));

        public static DbArchive archive(FolderPath root)
            => new DbArchive(root);

        public static DbArchive archive(Timestamp ts, DbArchive dst)
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
                ZipFile.CreateFromDirectory(src.Format(), dst.Format(), CompressionLevel.Fastest, true);
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

        public static ExecToken zip(FolderPath src, FilePath dst, WfEmit channel)
        {
            var uri = $"app://archives/zip?src={src}?dst={dst.ToUri()}";
            var flow = channel.EmittingFile(dst);
            ZipFile.CreateFromDirectory(src.Name, dst.Name, CompressionLevel.SmallestSize, true);
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