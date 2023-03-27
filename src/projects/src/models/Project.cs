//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public record class Project : IProject
        {
            public readonly @string Name;

            public readonly IDbArchive Root;

            public readonly ProjectKind Kind;

            public Project(FolderPath root)
            {
                Name = root.FolderName.Format();
                Kind = 0;
                Root = root.DbArchive();
            }

            public Project(ProjectKind kind, FolderPath root)
            {
                Name = root.FolderName.Format();
                Kind = kind;
                Root = root.DbArchive();
            }

            protected Project(ProjectKind kind)
            {
                Kind = kind;
                Root = FolderPath.Empty.DbArchive();
            }            

            IDbArchive IProject.Root
                => Root;

            @string IProject.Name
                => Name;
        }
    }
}