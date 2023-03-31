//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public abstract class ToolWfCmd<T,F> : WfAppCmd<T>
        where T : ToolWfCmd<T,F>, new()
        where F : ToolFlow<F>, new()
    {
        protected static FileIndex index(IDbArchive src)
            => FS.index(Archives.modules(src).Unmanaged());

        protected ExecStatus Run(CmdArgs args, FilePath src, FilePath dst)
        {
            var flow = Channel.Channeled<F>();
            return flow.Run(args, ToolPath, src,dst);
        }

        protected abstract FilePath ToolPath {get;}

        protected virtual bool Include(FilePath src)
            => true;

        protected virtual IEnumerable<FileIndexEntry> Sources(CmdArgs args)
        {
            if(args.IsNonEmpty)
            {
                var archive = FS.archive(args[0]);
                var index = FS.index(archive.Files().Where(Include));
                foreach(var file in index.Distinct())
                    yield return file;
            }
        }
    }
}
