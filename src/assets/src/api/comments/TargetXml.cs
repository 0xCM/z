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
            public class TargetXml : Dictionary<string,string>
            {
                public static TargetXml create(FilePath path, Dictionary<string,string> src)
                    => new(path,src);

                public readonly FilePath SourcePath;

                public TargetXml(FilePath path, Dictionary<string,string> src)
                    : base(src)
                {
                    SourcePath = path;
                }
            }
        }
    }
}