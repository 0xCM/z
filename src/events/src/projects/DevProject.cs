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

        public DevProject(FolderPath root)
        {
            Name = root.FolderName.Format();
            Root = root.DbArchive();
        }

        IDbArchive IProject.Root
            => Root;

        @string IProject.Name
            => Name;
    }
}