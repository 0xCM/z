//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class NDisasm : WfToolCmd<NDisasm>
    {
        public NDisasm()
            : base("ndisasm")
        {

        }

        public static CmdScript script(Bitness mode, FilePath src, FilePath dst)
        {
            const string Pattern = "{0} -b {1} -p intel {2} > {3}";
            var name = src.FileName.WithoutExtension.Format();
            return new CmdScript(name,string.Format(Pattern, (byte)mode, "ndisasm", src.Format(PathSeparator.BS), dst.Format(PathSeparator.BS)));
        }

        public FilePath Job(Bitness mode, FolderPath input, FolderPath output)
        {
            var src = input.Files(FS.Bin);
            var _scripts = scripts(mode, src, output);
            var count = _scripts.Length;
            var scriptDir = FolderPath.Empty + FS.folder(Id.Format());
            scriptDir.Clear();

            var paths = span<FilePath>(count);
            var runner = scriptDir + FS.file("run", FS.Cmd);
            using var writer = runner.Writer();
            for(var i=0; i<count; i++)
            {
                ref readonly var script = ref skip(_scripts,i);
                ref var path = ref seek(paths,i);
                path = scriptDir + FS.file(script.Name.Format(), FS.Cmd);
                path.Overwrite(script.Format());
                writer.WriteLine(string.Format("call {0}", path.Format(PathSeparator.BS)));
            }
            return runner;
        }

        public static ReadOnlySpan<CmdScript> scripts(Bitness mode, ReadOnlySpan<FilePath> src, FolderPath dst)
        {
            var count = src.Length;
            var buffer = alloc<CmdScript>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref skip(src,i);
                var output = dst + file.FileName.WithExtension(FS.Asm);
                seek(target,i) = script(mode, file, output);
            }
            return buffer;
        }
    }
}