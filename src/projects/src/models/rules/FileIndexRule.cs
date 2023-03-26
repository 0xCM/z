//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public sealed record class FileIndexRule : ProjectRule<FileIndexRule>
        {
            public readonly FileQuery Query;

            public FileIndexRule()
            {
                Query = FileQuery.Empty;
            }
            
            public FileIndexRule(FileQuery q)
            {
                Query = q;
            }
        }

    }
}