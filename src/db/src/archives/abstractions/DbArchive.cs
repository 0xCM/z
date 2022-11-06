//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class DbArchive<A> : IDbArchive
        where A : DbArchive<A>, new()
    {
        protected DbArchive()
        {
            Home = new DbArchive(FolderPath.Empty);
        }

        protected DbArchive(IDbArchive home)
        {
            Home = home;
        }

        protected DbArchive(FolderPath home)
        {
            Home = new DbArchive(home);
        }

        public readonly IDbArchive Home;

        public FolderPath Root => Home.Root;

        FolderPath IRootedArchive.Root 
            => Home.Root;
    }
}