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
            public struct PartComments
            {
                public PartId Part;

                public FilePath XmlPath;

                public FilePath CsvPath;

                public List<string> CsvRowData;

                public TargetComments CommentLookup;

                public TargetXml XmlLookup;

                public static PartComments Empty => default;
            }
        }
    }
}