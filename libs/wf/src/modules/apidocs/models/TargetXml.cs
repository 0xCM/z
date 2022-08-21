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
            public class TargetXml : Dictionary<string,string>
            {
                public static TargetXml create(FS.FilePath path, Dictionary<string,string> src)
                    => new(path,src);

                public readonly FS.FilePath SourcePath;

                public TargetXml(FS.FilePath path, Dictionary<string,string> src)
                    : base(src)
                {
                    SourcePath = path;
                }
            }
        }
    }
}