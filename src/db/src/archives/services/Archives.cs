//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    using static sys;

    public class Archives
    {        
        public static DbArchive archive(string src)
            => new DbArchive(FS.dir(src));

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
            var formatter = Tables.formatter<ListedFile>();
            dst.AppendLine(formatter.FormatHeader());
            for(var i=0u; i<src.Count; i++)
                dst.AppendLine(formatter.Format(src[i]));
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

        public static DbArchive archive(FolderPath root)
            => new DbArchive(root);

        public static DbArchive archive(Timestamp ts, DbArchive dst)
            => dst.Scoped(ts.Format());

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