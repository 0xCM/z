//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XmlComments
    {
        public partial class CommentDataset
        {
            public readonly SortedLookup<FilePath,TargetXml> XmlLookup;

            public readonly SortedLookup<FilePath,TargetComments> TargetCommentLookup;

            public readonly SortedLookup<FilePath,Index<ApiComment>> CsvLookup;

            public readonly Index<TargetComments> Comments;

            public readonly Index<TargetXml> Xml;

            public Files XmlSources;

            public readonly Files Sources;

            public CommentDataset(
                    Dictionary<FilePath, Dictionary<string,string>> xml,
                    Dictionary<FilePath, Dictionary<string,ApiComment>> comments,
                    Dictionary<FilePath, List<ApiComment>> csvFormat,
                    Files dlls
                    )
            {
                XmlLookup = xml.Map(x => (x.Key, TargetXml.create(x.Key, x.Value))).ToDictionary();
                TargetCommentLookup = comments.Map(x => (x.Key, TargetComments.create(x.Key, x.Value))).ToDictionary();
                Comments = TargetCommentLookup.Values.ToArray();
                Xml = XmlLookup.Values.ToArray();
                XmlSources = xml.Keys.Array().Sort();
                CsvLookup = csvFormat.Map(x => (x.Key, x.Value.Index())).ToDictionary();
                Sources = dlls;
            }
        }
    }
}