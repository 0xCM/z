//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmQuery : WfSvc<LlvmQuery>
    {
        LlvmPaths Paths => Service(Wf.LlvmPaths);

        public void Emit(string name, FS.Files src)
            => FileEmit(name, @readonly(src.View.Map(x => x.ToUri())));

        public void Emit(ListedFiles src, string name, bool display = true)
        {
            if(display)
                Row(src.Format());
            TableEmit(src.View, Paths.QueryOut().Path(name, FileKind.Csv));
        }

        public uint FileEmit<T>(string name, ReadOnlySpan<T> src)
            => FileEmit(src, name, string.Empty);

        public void FileEmit(string data, string name, FS.FileExt ext)
            => FileEmit(data, 0, Paths.QueryOut().Path(FS.file(name, ext)));

        public uint FileEmit<T>(ReadOnlySpan<T> src, string name, string tag = EmptyString)
        {
            var count = (uint)src.Length;
            var file = FS.file(text.replace(name, Chars.FSlash, Chars.Dot) + LlvmQuery.tag(tag), FS.Txt);
            var dst = Paths.QueryOut(file);
            var emitting = EmittingFile(dst);
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i));
            EmittedFile(emitting,count);
            return count;
        }

        public void FileEmit<T>(ReadOnlySpan<T> src, string name, FileKind kind)
        {
            var file = FS.file(name,kind);
            var dst = Paths.QueryOut(file);
            var flow = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Length; i++)
                writer.AppendLine(skip(src,i));
            EmittedFile(flow,src.Length);
        }

        public void FileEmit<T>(Index<T> src, string name, FileKind kind)
            => FileEmit(src.View, name, kind);

        public void FileEmit<T>(T[] src, string name, FileKind kind)
            => FileEmit(@readonly(src), name, kind);

        static string tag(string args)
            => text.empty(args) ? string.Empty : "-" + args;

        public void TableEmit<T>(string name, ReadOnlySpan<T> src)
            where T : struct
                => TableEmit(src, Paths.DbTable(name));
    }
}