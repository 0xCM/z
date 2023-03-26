//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public sealed record class FileSource : DataSource<FileSource>
        {
            const string SourceName = "File";

            public FileSource()
                : base(SourceName,EmptyString)
            {

            }

            public FileSource(FilePath path)
                : base(SourceName, path.Format())
            {
                Path = path;
            }

            public readonly FilePath Path;
        }
    }
}