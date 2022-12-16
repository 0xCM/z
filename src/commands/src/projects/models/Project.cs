//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Project : IProject
    {
        public @string Name {get;}

        public IDbArchive Root {get;}

        public Project(string name, IDbArchive root)
        {
            Name = name;
            Root = root;
        }

        public Project()
        {
            Name = EmptyString;
            Root = DbArchive.Empty;
        }

        public static Project Empty => new Project();
    }
}