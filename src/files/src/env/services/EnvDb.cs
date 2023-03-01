//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnvDb : IDbArchive
    {


    }
    
    public class EnvDb : IEnvDb
    {
        public EnvDb(FolderPath root)
        {
            Root = root;
        }

        public FolderPath Root {get;}
    }
}