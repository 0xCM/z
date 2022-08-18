//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiComments
    {
        partial class CommentDataset
        {
            public class TargetComments : Dictionary<string,ApiComment>
            {
                public static TargetComments create(FS.FilePath path, Dictionary<string,ApiComment> src)
                    => new(path,src);

                public readonly FS.FilePath SourcePath;

                public TargetComments(FS.FilePath path, Dictionary<string,ApiComment> src)
                    : base(src)
                {
                    SourcePath = path;
                }
            }
        }
    }
}