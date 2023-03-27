//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public sealed record class AggregateProject : Project<AggregateProject>
        {
            public AggregateProject()
                : base(ProjectKind.Aggregate, FolderPath.Empty)
            {

            }

            public AggregateProject(FilePath path, ReadOnlySeq<FolderPath> folders)
                : base(ProjectKind.Aggregate, path.FolderPath)
            {
                
                Folders = folders;        
            }

            public ReadOnlySeq<FolderPath> Folders {get;}
        }
    }
}