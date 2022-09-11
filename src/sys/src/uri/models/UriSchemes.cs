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

        /// <summary>
        /// https://en.wikipedia.org/wiki/File_URI_scheme
        /// </summary>
        public readonly struct File : IUriScheme
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
        public readonly struct Data : IUriScheme
        {
            public string Name => "data";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Doc : IUriScheme
        {
            public string Name => "doc";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Cmd : IUriScheme
        {
            public string Name => "cmd";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Tool : IUriScheme
        {
            public string Name => "tool";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        public readonly struct Machine : IUriScheme
        {
            public string Name => "machine";

            public UriPartKind Kind => UriPartKind.Scheme;

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }

        // public readonly struct Local : IUriScheme
        // {
        //     public string Name => nameof(Local);

        //     public UriPartKind Kind => UriPartKind.Scheme;

        //     public string Format()
        //         => Name;

        //     public override string ToString()
        //         => Format();
        // }       
    }
}