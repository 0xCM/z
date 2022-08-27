//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileQuery : Deferred<FileQuery,FilePath>
    {
        public FileQuery()
        {

        }

        public FileQuery(IEnumerable<FilePath> src)
            : base(src)
        {

        }
    }
}