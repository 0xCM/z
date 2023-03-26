//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ProjectModels;

    partial class ProjectTargets
    {
        public sealed class FileIndexTarget : ProjectTarget<FileIndexTarget, FileIndexRule, FileIndex>
        {
            public override FileIndex Build(FileIndexRule rule)
            {
                throw new NotImplementedException();
            }
        }
    }
}