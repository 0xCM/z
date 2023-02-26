//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvDb : IDbArchive
    {
        public EnvDb(FolderPath root)
        {
            Root = root;
        }

        public FolderPath Root {get;}
    }
}