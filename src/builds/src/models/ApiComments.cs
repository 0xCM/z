//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;
    using System.Linq;

    using static ApiAtomic;
    using static sys;

    using CT = ApiCommentTarget;

    public sealed partial class ApiComments : AppService<ApiComments>
    {
        public CommentDataset Calc()
        {
            var targets = AppDb.Service.ApiTargets(comments);
            var dllPaths = list<FilePath>();
            var xmlData = new Dictionary<FilePath, Dictionary<string,string>>();
            var archive = sys.controller().RuntimeArchive();
            var dllFiles = archive.DllFiles();
            var xmlFiles = archive.XmlFiles;
            foreach(var xmlfile in xmlFiles())
            {
                var elements = ParseXmlData(xmlfile.ReadText());
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
            var formatter = Tables.formatter<ApiComment>();
            foreach(var part in xmlData.Keys)
            {
                var file = FS.file(string.Format("{0}.{1}", "api.comments", part.FileName.WithoutExtension.Name), FS.Csv);
                var path = targets.Path(file);
                var docs = dict<string,ApiComment>();
                lookup[part] = docs;
                csvRowFormat[path] = new();
                csvRows[path] = new();

                var kvp = xmlData[part];
                foreach(var key in kvp.Keys)
                {
                    var result = parse(key, kvp[key], out ApiComment comment);
                    if(result)
                    {
                        docs[key] = comment;
                        csvRows[path].Add(comment);
                        csvRowFormat[path].Add(formatter.Format(comment));
                    }
                }
            }

            return new(xmlData, lookup, csvRows, dllFiles);
        }

        public static FileName CsvFile(PartId part)
            => FS.file(string.Format("api.comments.z0", part.Format()), FS.Csv);

        public static FileName XmlFile(PartId part)
            => FS.file(string.Format("api.comments.z0", part.Format()), FS.Xml);

        public void Collect(IDbArchive dst)
        {
            var targets = dst;
            var src = Pull(dst);
            var lookup = new Dictionary<FilePath, Dictionary<string,ApiComment>>();
            var formatter = Tables.formatter<ApiComment>();
            foreach(var part in src.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var file = FS.file($"{part.FileName.WithoutExtension}.{comments}", FileKind.Csv);
                var path = targets.Path(file);
                var flow = EmittingTable<ApiComment>(path);
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
                EmittedTable(flow, kvp.Count);
            }
        }

        public void Collect(IApiPack dst)
            => Collect(dst.Targets(comments));
        static bool parse(string key, string value, out ApiComment dst)
        {
            var parts = key.SplitClean(Chars.Colon);
            var result = parts.Length >= 2 && parts[0].Length == 1;
            for(var i=0; i<parts.Length; i++)
            {
                ref readonly var part = ref skip(parts,i);
                if(nonempty(part))
                {
                    ref readonly var c = ref first(part);
                    switch(target(c))
                    {
                        case CT.Type:
                        break;
                        case CT.Method:
                        break;
                        case CT.Field:
                        break;
                        case CT.Property:
                        break;
                        case CT.Operand:
                        break;
                        case CT.Param:
                        break;
                        default:
                            break;
                    }
                }
            }

            if(result)

                result = parse(target(parts[0][0]), parts[1], value, out dst);
            else
                dst = ApiComment.Empty;
            return result;
        }

        static bool parse(ApiCommentTarget target, string name, string data, out ApiComment comment)
        {
            var result = false;
            comment = ApiComment.Empty;
            if(Summary.parse(data, out var summary))
            {
                comment = new ApiComment(target, name, summary.Format());
                result = true;
            }
            return result;
        }

        static ApiCommentTarget target(char src)
            => src switch {
                'T' => ApiCommentTarget.Type,
                'M' => ApiCommentTarget.Method,
                'P' => ApiCommentTarget.Property,
                'F' => ApiCommentTarget.Field,
                _ => ApiCommentTarget.None,
            };

        ConstLookup<FilePath, Dictionary<string,string>> Pull(IDbArchive dst)
        {
            var archive = sys.controller().RuntimeArchive();
            var paths = archive.XmlFiles();
            var lookup = cdict<FilePath, Dictionary<string,string>>();
            var t = default(ApiComment);
            iter(paths, path => {
                var data = ParseXmlFile(path, dst, out var packpath);
                if(data.Count != 0)
                {
                    lookup.TryAdd(path,data);
                }
                }, true);
            return lookup;
        }

        Dictionary<string,string> ParseXmlFile(FilePath src, IDbArchive dst, out FilePath target)
        {
            var data = src.ReadText();
            var parsed = ParseXmlData(data);
            target = FilePath.Empty;
            if(parsed.Count != 0)
            {
                target = dst.Targets().Path(FS.file($"{src.FileName.WithoutExtension}.{comments}", FileKind.Xml));
                src.CopyTo(target);
            }
            return parsed;
        }

        static Dictionary<string,string> ParseXmlData(string src)
        {
            var index = new Dictionary<string, string>();
            using var xmlReader = XmlReader.Create(new StringReader(src));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member")
                {
                    string raw_name = xmlReader["name"];
                    index[raw_name] = xmlReader.ReadInnerXml();
                }
            }
            return index;
        }

        [MethodImpl(Inline)]
        static KeyValuePair<K,V> kvp<K,V>(K key, V value)
            => new KeyValuePair<K,V>(key,value);

        static Dictionary<string,string> Replacements = new (new KeyValuePair<string,string>[]{
                    kvp("&gt;",">"),
                }
            );

        static ApiComment comment(ApiCommentTarget target, string name, string summary)
        {
            var content = summary;
            core.iter(Replacements,kvp => content = text.replace(content, kvp.Key,kvp.Value));
            return new ApiComment(target,name, content);
        }

        static bool parse2(string key, string value, out ApiComment dst)
        {
            var components = key.SplitClean(Chars.Colon);
            var result = false;
            dst = ApiComment.Empty;
            if(components.Length == 2 && components[0].Length == 1)
            {
                var summary = text.replace(
                              Fenced.unfence(value, Fenced.define("<summary>", "</summary>"))
                                 .RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret);
                result = parse(target(components[0][0]), components[1], summary, out dst);
            }
            return result;
        }

        static ParseResult<ApiComment> ParseComent(string key, string value)
        {
            var components = key.SplitClean(Chars.Colon);
            if(components.Length == 2 && components[0].Length == 1)
            {
                var summary = text.replace(
                              Fenced.unfence(value, Fenced.define("<summary>", "</summary>"))
                                 .RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret);

                return ParseResult.win(key, comment(target(components[0][0]), components[1], summary));
            }
            else
                return ParseResult.fail<ApiComment>(key);
        }
    }
}