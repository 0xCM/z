//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    public sealed record class Archives : ApiSet<Archives>
    {
        [Api]
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
            => FS.file(string.Format("{0}.{1}", name, (Timestamp.now()).Format()),ext);

        [Op]
        public static FilePath timestamped(FilePath src)
        {
            var name = src.FileName.WithoutExtension;
            var ext = src.Ext;
            var stamped = FS.file(string.Format("{0}.{1}.{2}", name, Algs.timestamp(), ext));
            return src.FolderPath + stamped;
        }

        public static CmdProcess robocopy(FolderPath src, FolderPath dst)
        {
            var spec = $"robocopy {src} {dst} /e";
            var cmd = Cmd.cmd(spec);
            return Cmd.process(cmd);
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