//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    [ApiHost]
    public class UriSchemes
    {        
        [Op]
        public static File file()
            => new();

        [Op]
        public static Data data()
            => new();

        [Op]
        public static Cmd cmd()
            => new();

        [Op]
        public static Tool tool()
            => new();

        [Op]
        public static Machine machine()
            => new();

        [Op]
        public static Tool git()
            => new();

        [Op]
        public static Tool http()
            => new();

        public record struct Git : IUriScheme<Git>
        {
            public const string Name = "git";

            public UriPartKind Kind => UriPartKind.Scheme;

            string IUriScheme.Name 
                => Name;
        }

        public record struct Http : IUriScheme<Http>
        {
            public const string Name = "http";

            public UriPartKind Kind => UriPartKind.Scheme;

            string IUriScheme.Name 
                => Name;
        }

        public record struct Https : IUriScheme<Https>
        {
            public const string Name = "https";

            public UriPartKind Kind => UriPartKind.Scheme;

            string IUriScheme.Name 
                => Name;
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/File_URI_scheme
        /// </summary>
        public readonly struct File : IUriScheme<File>
        {
            public string Name => "file";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Data_URI_scheme
        /// </summary>
        public readonly struct Data : IUriScheme<Data>
        {
            public string Name => "data";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Doc : IUriScheme<Doc>
        {
            public string Name => "doc";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Cmd : IUriScheme<Cmd>
        {
            public string Name => "cmd";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Tool : IUriScheme<Tool>
        {
            public string Name => "tool";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Machine : IUriScheme<Machine>
        {
            public string Name => "machine";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }
    }
}