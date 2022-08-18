//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DumpArchive : IDumpArchive
    {
        public DumpArchive(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath Root {get;}
    }
}