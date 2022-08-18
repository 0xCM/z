//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class DbArchive<A> : IDbArchive
        where A : DbArchive<A>, new()
    {
        protected DbArchive(IDbArchive home)
        {
            Home = home;
        }

        public readonly IDbArchive Home;

        FS.FolderPath IRootedArchive.Root 
            => Home.Root;
    }
}