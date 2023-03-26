//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public record class FolderSource : DataSource<FolderSource>
        {
            const string SourceName = "Folder";

            public FolderSource()
                : base(SourceName,EmptyString)
            {

            }

            public FolderSource(FolderPath path)
                : base(SourceName, path.Format())
            {
                Path = path;
            }

            public readonly FolderPath Path;
        }
    }
}