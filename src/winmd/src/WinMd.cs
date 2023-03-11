//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;

    public partial class WinMd : WfSvc<WinMd>
    {
        public static void parse(FilePath src, out ResponseFile dst)
        {
            var parser = new ResponseFileParser(src);
            dst = parser.Parse();            
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

            public const string FileDirectory = "file-directory";

            public const string WithType = "with-type";

        }

        public enum OptionKind : byte
        {
            [Symbol(EmptyString)]
            None,

            [Symbol(OptionNames.Traverse)]
            Traverse,

            [Symbol(OptionNames.Namespace)]
            Namespace,

            [Symbol(OptionNames.File)]
            File,

            [Symbol(OptionNames.FileDirectory)]
            FileDirectory,

            [Symbol(OptionNames.Output)]
            Output,

            [Symbol(OptionNames.HeaderFile)]
            HeaderFile,

            [Symbol(OptionNames.IncludeDirectory)]
            IncludeDirectory,

            [Symbol(OptionNames.Exclude)]
            Exclude,

            [Symbol(OptionNames.WithType)]
            WithType,
        }

        public interface IOption
        {
            OptionKind Kind {get;}

            IOptionValue Value {get;}            
        }

        public interface IOptionValue
        {
            object Data {get;}

            string Format();

            T As<T>()
                => (T)Data;
        }

        public abstract record class OptionValue<R,V> : IOptionValue
            where R : OptionValue<R,V>,new()
        {
            public readonly V Data;

            public static R Empty => new();

            protected OptionValue(V value)
            {
                Data = value;
            }

            object IOptionValue.Data    
                => Data;

            public string Format()
                => Data?.ToString() ?? "<null>";

            public override string ToString()
                => Format();

        }

        public abstract record class Option<R,V> : IOption
            where R : Option<R,V>,new()
            where V : IOptionValue
        {
            public readonly OptionKind Kind;

            public readonly V Value;

            protected Option(OptionKind kind, V value)
            {
                Kind = kind;
                Value = value;
            }

            IOptionValue IOption.Value
                => Value;

            OptionKind IOption.Kind
                => Kind;
        }

        public sealed record class Option : Option<Option,IOptionValue>
        {
            public Option()
                : base(0,null)
            {

            }

            public Option(OptionKind kind, IOptionValue value)
                : base(kind, value)
            {

            }
        }

        public sealed record class OptionValue<V> : OptionValue<OptionValue<V>, V>
            where V : new()
        {
            public OptionValue()
                : base(new V())
            {}

            public OptionValue(V value)
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

            [MethodImpl(Inline)]
            public static implicit operator PathValue(FilePath src)
                => new(src);
        }

        public record class ResponseFile
        {
            public readonly FilePath Path;
            
            public readonly ICollection<IOption> Options;

            public ResponseFile(FilePath path, ICollection<IOption> options)
            {
                Path = path;
                Options = options;
            }    
        }

        public class ResponseFileParser
        {
            readonly FilePath Source;

            readonly List<IOption> Options = new();

            public ResponseFileParser(FilePath src)
            {
                Source = src;
                OptionName = EmptyString;
            }

            string OptionName;

            static Option option<T>(OptionKind kind, T value) 
                where T : new()
                    => new Option(kind, new OptionValue<T>(value));

            
            bool Parse(@string src, out IOption value)
            {
                value = option(0,src);
                switch(OptionName)
                {
                    case OptionNames.Exclude:
                        value = option(OptionKind.Exclude, src);
                    break;
                    case OptionNames.File:
                        value = option(OptionKind.File, FS.path(src));
                    break;
                    case OptionNames.HeaderFile:
                        value = option(OptionKind.HeaderFile, FS.path(src));
                    break;
                    case OptionNames.FileDirectory:
                        value = option(OptionKind.FileDirectory, FS.dir(src));
                    break;
                    case OptionNames.IncludeDirectory:
                        value = option(OptionKind.IncludeDirectory, FS.dir(src));
                    break;
                    case OptionNames.Namespace:
                        value = option(OptionKind.Namespace, src);
                    break;
                    case OptionNames.Output:
                        value = option(OptionKind.Output, FS.dir(src));
                    break;
                    case OptionNames.Traverse:                        
                       value = option(OptionKind.Traverse, FS.path(src));
                    break;
                   case OptionNames.WithType:
                        value = option(OptionKind.WithType, FS.dir(src));
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
                    OptionName = text.right(content,i + "--".Length - 1);
                }
                else
                {
                    if(Parse(content, out IOption option))
                        Options.Add(option);
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
                
                return new ResponseFile(Source, Options);
            }
        }
    }
}