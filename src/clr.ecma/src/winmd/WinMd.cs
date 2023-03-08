//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class WinMd : WfSvc<WinMd>
    {
        public static void parse(FilePath src, out ResponseFile dst)
        {
            var parser = new ResponseFileParser(src);
            dst = parser.Parse();            
        }

        public class SymbolicPath
        {
            public readonly string Expression;

            public FilePath Resolve(params Var[] vars)
            {
                var dst = Expression;
                iter(vars, v => {
                    
                });
                return FS.path(dst);
            }
        }

        public class OptionNames
        {
            public const string Traverse = "traverse";

            public const string Namespace = "namespace";

            public const string File = "file";

            public const string Output = "output";

            public const string HeaderFile = "headerFile";

            public const string IncludeDirectory = "include-directory";

            public const string Exclude = "exclude";

        }
        public enum OptionKind : byte
        {
            None,

            Traverse,

            Namespace,

            File,

            Output,

            HeaderFile,

            IncludeDirectory,

            Exclude,
        }

        public interface IOption
        {
            @string Name {get;}

            IOptionValue Value {get;}            
        }

        public interface IOptionValue
        {
            object Data {get;}
        }

        public abstract record class OptionValue<R,V> : IOptionValue
            where R : OptionValue<R,V>,new()
        {
            public readonly V Data;

            protected OptionValue(V value)
            {
                Data = value;
            }

            object IOptionValue.Data    
                => Data;
        }

        public abstract record class Option<R,V> : IOption
            where R : Option<R,V>,new()
            where V : IOptionValue
        {
            public readonly @string Name;

            public readonly V Value;

            protected Option(string name, V value)
            {
                Name = name;
                Value = value;
            }

            IOptionValue IOption.Value
                => Value;

            @string IOption.Name    
                => Name;
        }

        public sealed record class Option : Option<Option,IOptionValue>
        {
            public Option()
                : base(EmptyString,null)
            {

            }

            public Option(string name, IOptionValue value)
                : base(name,value)
            {

            }
        }
        public sealed record class OptionValue : OptionValue<OptionValue,object>
        {
            public OptionValue()
                : base(@string.Empty)
            {}

            public OptionValue(object value)
                : base(value)
            {

            }
        }        

        public sealed record class PathValue : OptionValue<PathValue,FilePath>
        {
            public PathValue()
                : base(FilePath.Empty)
            {}

            public PathValue(FilePath value)
                : base(value)
            {

            }
        }

        public record class ResponseFile
        {
            public readonly FilePath Path;
            
            public readonly ConstLookup<string, ReadOnlySeq<IOptionValue>> Options;

            public ResponseFile(FilePath path, ConstLookup<string, ReadOnlySeq<IOptionValue>> options)
            {
                Path = path;
                Options = options;
            }    
        }

        public record class FileTraversal
        {
            public readonly FilePath Path;
        }

        public class ResponseFileParser
        {
            readonly FilePath Source;

            readonly List<IOptionValue> OptionValues = new();

            readonly Dictionary<string,ReadOnlySeq<IOptionValue>> OptionLookup = new();

            public ResponseFileParser(FilePath src)
            {
                Source = src;
                OptionName = EmptyString;
            }

            string OptionName;

            bool Parse(string src, out IOptionValue value)
            {
                value = new OptionValue(src);
                switch(OptionName)
                {
                    case OptionNames.Exclude:
                        value = new OptionValue(src);
                    break;
                    case OptionNames.File:
                        value = new OptionValue(FS.path(src));
                    break;
                    case OptionNames.HeaderFile:
                        value = new OptionValue(FS.path(src));
                    break;
                    case OptionNames.IncludeDirectory:
                        value = new OptionValue(FS.dir(src));
                    break;
                    case OptionNames.Namespace:
                        value = new OptionValue(src);
                    break;
                    case OptionNames.Output:
                        value = new OptionValue(FS.path(src));
                    break;
                    case OptionNames.Traverse:
                        value = new OptionValue(FS.path(src));
                    break;

                }
                return value != null;
            }
            void Parse(TextLine src)
            {
                var content = text.trim(src.Content);
                var i = text.index(content, "--");
                if(i >=0)
                {
                    if(text.nonempty(OptionName) && OptionValues.Count != 0)
                    {
                        OptionLookup[OptionName] = OptionValues.ToSeq();
                    }
                    OptionValues.Clear();
                    OptionName = text.right(content,i);
                }
                else
                {
                    if(Parse(content, out IOptionValue value))
                        OptionValues.Add(value);
                }
            }

            public ResponseFile Parse()
            {
                using var reader = Source.LineReader(UTF8);
                var line = TextLine.Empty;
                while(reader.Next(out line))
                {
                    Parse(line);
                }
                
                return new ResponseFile(Source,OptionLookup);
            }
        }
    }
}