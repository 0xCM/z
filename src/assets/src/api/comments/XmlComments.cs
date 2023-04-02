//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;
    using System.Linq;

    using static sys;

    public sealed partial class XmlComments : AppService<XmlComments>
    {    
        public static ConstLookup<FilePath, Dictionary<string,string>> elements(IDbArchive src)
        {
            var paths = src.Files(FileKind.Xml);
            var lookup = cdict<FilePath, Dictionary<string,string>>();
            iter(paths, path => {
                var data = xmldata(path.ReadText());
                if(data.Count != 0)
                {
                    lookup.TryAdd(path,data);
                }
                }, true);
            return lookup;
        }

        public static XmlCommentData dataset(IWfChannel channel, IDbArchive src)
        {
            var dllPaths = list<FilePath>();
            var xmlData = new Dictionary<FilePath, Dictionary<string,string>>();
            var dllFiles = src.Files(FileKind.Dll);
            var xmlFiles = src.Files(FileKind.Xml);
            foreach(var xmlfile in xmlFiles)
            {
                var elements = xmldata(xmlfile.ReadText());
                if(elements.Count != 0)
                {
                    xmlData[xmlfile] = elements;
                    var dllfile = dllFiles.Where(f => f.FileName == xmlfile.FileName.ChangeExtension(FS.Dll)).FirstOrDefault();
                    if(dllfile.IsNonEmpty)
                        dllPaths.Add(dllfile);
                }
            }

            var lookup = new Dictionary<FilePath, Dictionary<string,ApiComment>>();
            var csvRowFormat = dict<FilePath,List<string>>();
            var csvRows = dict<FilePath,List<ApiComment>>();
            var formatter = CsvTables.formatter<ApiComment>();
            foreach(var path in xmlData.Keys)
            {
                var running = channel.Running($"Processing {path}");
                var docs = dict<string,ApiComment>();
                lookup[path] = docs;
                csvRowFormat[path] = new();
                csvRows[path] = new();

                var kvp = xmlData[path];
                foreach(var key in kvp.Keys)
                {
                    var result = ParseComent(key, kvp[key]);
                    result.OnSuccess(comment => {
                        docs[key] = comment;
                        csvRows[path].Add(comment);
                        csvRowFormat[path].Add(formatter.Format(comment));
                    }).OnFailure(() => {
                        channel.Warn($"'{key}:{kvp[key]}' parse failure");
                    });
                }

                channel.Ran(running, $"Processed {path}");
            }

            return new(xmlData, lookup, csvRows, dllFiles.Array());
        }

        public ConstLookup<FilePath, Dictionary<string,ApiComment>> Collect(IDbArchive archive, IDbArchive dst)
        {
            var targets = dst;
            var src = XmlComments.elements(archive);
            var lookup = new Dictionary<FilePath, Dictionary<string,ApiComment>>();
            var formatter = CsvTables.formatter<ApiComment>();
            foreach(var part in src.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var file = FS.file($"{part.FileName.WithoutExtension}.{ApiAtomic.comments}", FileKind.Csv);
                var path = targets.Path(file);
                var flow = Channel.EmittingTable<ApiComment>(path);
                var docs = new Dictionary<string, ApiComment>();
                lookup[part] = docs;
                using var writer = path.Writer();
                writer.AppendLine(formatter.FormatHeader());
                var kvp = src[part];
                foreach(var key in kvp.Keys)
                {
                    var value = kvp[key];
                    var comment = ParseComent(key, value).Value;
                    docs[comment.TargetName] = comment;
                    writer.WriteLine(formatter.Format(comment));
                }
                Channel.EmittedTable(flow, kvp.Count);
            }
            return lookup;
        }

        static ApiCommentTarget target(char src)
            => src switch {
                'T' => ApiCommentTarget.Type,
                'M' => ApiCommentTarget.Method,
                'P' => ApiCommentTarget.Property,
                'F' => ApiCommentTarget.Field,
                _ => ApiCommentTarget.None,
            };
        
        static Dictionary<string,string> xmldata(string src)
        {
            var index = new Dictionary<string, string>();
            using var reader = XmlReader.Create(new StringReader(src));
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "member")
                {
                    string raw_name = reader["name"];
                    index[raw_name] = reader.ReadInnerXml();
                }
            }
            return index;
        }

        static Dictionary<string,string> Replacements = new (new KeyValuePair<string,string>[]{
                    kvp("&gt;",">"),
                }
            );

        static ApiComment comment(ApiCommentTarget target, string name, string summary)
        {
            var content = summary;
            sys.iter(Replacements,kvp => content = text.replace(content, kvp.Key,kvp.Value));
            return new ApiComment(target, name, content);
        }

        static ParseResult<ApiComment> ParseComent(string key, string value)
        {
            var components = key.SplitClean(Chars.Colon);
            if(components.Length == 2 && components[0].Length == 1)
            {
                var content = text.remove(text.remove(value, "<para>"), "</para>");
                var summary = text.despace(text.replace(Fenced.unfence(content, Fenced.define("<summary>", "</summary>")).RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret));
                return ParseResult.win(key, comment(target(components[0][0]), components[1], summary));
            }
            else
                return ParseResult.fail<ApiComment>(key);
        }
    }
}