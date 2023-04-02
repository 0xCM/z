//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    public class XmlCommentData
    {
        public readonly SortedLookup<FilePath,TargetXml> FileXml;

        public readonly SortedLookup<FilePath,TargetComments> FileComments;

        public readonly SortedLookup<FilePath,Index<ApiComment>> FileRows;

        public readonly Index<TargetComments> Comments;

        public readonly ReadOnlySeq<ApiComment> CommentRows;

        public readonly Index<TargetXml> Xml;

        public Files XmlSources;

        public readonly Files Sources;

        public XmlCommentData(
                Dictionary<FilePath, Dictionary<string,string>> xml,
                Dictionary<FilePath, Dictionary<string,ApiComment>> comments,
                Dictionary<FilePath, List<ApiComment>> csvFormat,
                Files dlls
                )
        {
            FileXml = xml.Map(x => (x.Key, TargetXml.create(x.Key, x.Value))).ToDictionary();
            FileComments = comments.Map(x => (x.Key, TargetComments.create(x.Key, x.Value))).ToDictionary();
            Comments = FileComments.Values.ToArray();
            Xml = FileXml.Values.ToArray();
            XmlSources = xml.Keys.Array().Sort();
            FileRows = csvFormat.Map(x => (x.Key, x.Value.Index())).ToDictionary();
            Sources = dlls;
            CommentRows = csvFormat.Values.SelectMany(x => x).Array().Sort();
        }

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


        static Dictionary<string,string> TypeNameReplacements;

        static XmlCommentData()
        {
            TypeNameReplacements = new();
            TypeNameReplacements.Add("System.Byte","uint8");
            TypeNameReplacements.Add("System.SByte","int8");
            TypeNameReplacements.Add("System.UInt16","uint16");
            TypeNameReplacements.Add("System.Int16","int16");
            TypeNameReplacements.Add("System.UInt32","uint32");
            TypeNameReplacements.Add("System.Int32","int32");
            TypeNameReplacements.Add("System.UInt64","uint64");
            TypeNameReplacements.Add("System.Int64","int64");
            TypeNameReplacements.Add("System.Float","float32");
            TypeNameReplacements.Add("System.Double","float64");
            TypeNameReplacements.Add("System.String","string");
        }

        public static string TypeDisplayName(string src)
        {
            var name = src.Remove("System.Runtime.Intrinsics.").Replace(Chars.LBrace, Chars.Lt).Replace(Chars.RBrace, Chars.Gt).Remove("@");
            sys.iter(TypeNameReplacements, x => name = name.Replace(x.Key,x.Value));
            return name;
        }
    }
}
