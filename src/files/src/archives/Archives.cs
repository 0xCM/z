//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Commands;

    using static sys;

    [ApiHost]
    public class Archives : Stateless<Archives>
    {        
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
            var index = FileIndex.create();
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

        public static FileTypes FileTypes(params Assembly[] src)
            => new (src.Types().Tagged<FileTypeAttribute>().Concrete().Map(x => (IFileType)Activator.CreateInstance(x)).ToHashSet());     

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

        public static IModuleArchive modules(FolderPath src, bool recurse = true)
            => new ModuleArchive(src, recurse);

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

        [Op]
        public static string format(ListedFiles src)
        {
            var dst = text.emitter();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        static void render(ListedFiles src, ITextEmitter dst)
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