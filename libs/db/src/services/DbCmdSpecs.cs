//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class DbCmdSpecs
    {
        [MethodImpl(Inline)]
        public static ArchiveCmd archive(FS.FolderPath src, FS.FilePath dst)
        {
            Algs.noinit(out ArchiveCmd cmd);
            cmd.Source = src;
            cmd.Target = dst;
            return cmd;
        }
    }
}