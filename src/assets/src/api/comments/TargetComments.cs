//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XmlComments
    {
        partial class CommentDataset
        {
            public class TargetComments : Dictionary<string,ApiComment>
            {
                public static TargetComments create(FilePath path, Dictionary<string,ApiComment> src)
                    => new(path,src);

                public readonly FilePath SourcePath;

                public TargetComments(FilePath path, Dictionary<string,ApiComment> src)
                    : base(src)
                {
                    SourcePath = path;
                }
            }
        }
    }
}