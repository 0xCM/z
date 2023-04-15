//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class DevProject : IProject
    {
        public readonly @string Name;

        public readonly IDbArchive Root;

        public readonly ProjectKind Kind;

        public DevProject(FolderPath root)
        {
            Name = root.FolderName.Format();
            Kind = 0;
            Root = root.DbArchive();
        }

        public DevProject(ProjectKind kind, FolderPath root)
        {
            Name = root.FolderName.Format();
            Kind = kind;
            Root = root.DbArchive();
        }

        protected DevProject(ProjectKind kind)
        {
            Kind = kind;
            Root = FolderPath.Empty.DbArchive();
        }            

        IDbArchive IProject.Root
            => Root;

        @string IProject.Name
            => Name;

        ProjectKind IProject.Kind 
            => Kind;
    }

}