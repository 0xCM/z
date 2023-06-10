//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;

    using static sys;

    class AssemblyCommentCalcs
    {
        readonly IWfChannel Channel;

        readonly IDbArchive Source;

        public AssemblyCommentCalcs(IWfChannel channel, IDbArchive src)
        {
            Channel = channel;
            Source = src;
            Parse();
        }

        AssemblyIndex _Assemblies;

        ConcurrentDictionary<VersionedName,ConstLookup<string,string>> Buffer = new();

        ConcurrentDictionary<VersionedName,ConstLookup<string,MemberComments>> CommentBuffer = new();

        SortedLookup<VersionedName, ConstLookup<string,string>> Lookup;

        SortedLookup<VersionedName, ConstLookup<string,MemberComments>> CommentLookup;

        public ref readonly AssemblyIndex Assemblies()
        {
            if(_Assemblies == null)
                _Assemblies = Ecma.index(Channel, Source);
            return ref _Assemblies;
        }

        void Parse(AssemblyIndex.Entry src)
        {            
            var file = src.File;
            if(file.HasComments)                
            {
                try
                {
                    var parsing = Channel.Running($"Parsing {file.CommentsFile}");
                    var data = elements(file);
                    var _comments = dict<string,MemberComments>();
                    if(Buffer.TryAdd(file.Identifier, data))
                    {
                        iter(data.Keys, name => {
                            if(parse(name, out var kind, out var _name))
                            {
                                _comments.TryAdd(name, new MemberComments(file, kind, _name, data[name]));
                            }
                            else
                                Channel.Warn($"Name parse error:{name}");
                        });
                        CommentBuffer.TryAdd(file.Identifier, _comments);
                    }
                    
                    
                    Channel.Ran(parsing, $"Parsed {data.Count} elements from {file.CommentsFile}");
                }
                catch(Exception e)
                {
                    Channel.Error($"{file.CommentsFile}:{e.Message}");
                }
            }
        }

        static ApiCommentTarget target(char src)
            => src switch {
                'T' => ApiCommentTarget.Type,
                'M' => ApiCommentTarget.Method,
                'P' => ApiCommentTarget.Property,
                'F' => ApiCommentTarget.Field,
                _ => ApiCommentTarget.None,
            };

        static bool parse(string src, out ApiCommentTarget kind, out string name)
        {
            kind = default;
            name = EmptyString;
            var i = text.index(src,Chars.Colon);
            var result = false;
            if(i > 0)
            {
                var k = text.trim(text.left(src,i));
                if(k.Length == 1)
                {
                    result = true;
                    kind = target(k[0]);
                }

                name = text.right(src,i);
            }
            return result;
        }
        void Parse()
        {            
            iter(Assemblies().Distinct(), Parse, true);
            Lookup = Buffer;
            CommentLookup = CommentBuffer;
        }

        public ReadOnlySpan<VersionedName> Commented 
            => Lookup.Keys;

        public ConstLookup<string,MemberComments> Comments(VersionedName src)
            => CommentLookup[src];

        static Dictionary<string,string> elements(AssemblyFile src)
            => xmldata(src.CommentsFile.ReadText());

        static Dictionary<string,string> xmldata(string src)
        {
            var index = new Dictionary<string, string>();
            using var reader = XmlReader.Create(new StringReader(src));
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "member")
                {
                    string raw_name = reader["name"];
                    index[raw_name] = text.despace(reader.ReadInnerXml().ReplaceAny(sys.array(Chars.NL, Chars.CR), Chars.Space));
                }
            }
            return index;
        }
    }
}