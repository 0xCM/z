//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileIndexer : Channeled<FileIndexer>
    {
        readonly IDbArchive Targets;

        public Task<ExecToken> IndexFiles(IEnumerable<FilePath> src)
            => sys.start(() => Absorb(src));

        ExecToken Absorb(IEnumerable<FilePath> src)
        {
            var running = Channel.Running();


            return Channel.Ran(running);

        }
    }
}