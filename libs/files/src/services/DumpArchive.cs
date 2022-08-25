//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DumpArchive : IDumpArchive
    {
        public DumpArchive(FolderPath root)
        {
            Root = root;
        }

        public FolderPath Root {get;}
    }
}