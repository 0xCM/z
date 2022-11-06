//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DumpArchive : DbArchive<DumpArchive>, IDumpArchive
    {
        public DumpArchive(FolderPath root)
            : base(root)
        {
        }

        public DumpArchive()
            : base(FolderPath.Empty)
        {

        }
    }
}