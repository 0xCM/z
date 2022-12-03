//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static sys;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/td/links")]
        void EmitTdSymLinks()
        {
            var sources = TdFiles();
            var count = sources.Length;
            var links = Paths.Targets("links");
            for(var i=0; i<count; i++)
            {
                ref readonly var srcpath = ref sources[i];
                var relative = srcpath.Relative(Paths.LlvmRoot.Root);
                var linkpath = links.Root + relative;
                var result = FS.symlink(linkpath, srcpath, true);
                if(result.Fail)
                    Channel.Error(result.Message);
            }

            var dst = Paths.File("links", "tabledefs", FileKind.Md);
            using var writer = dst.AsciWriter();
            iter(TdFiles(), f => writer.WriteLine(f.ToUri().MarkdownBullet()));
        }
    }
}