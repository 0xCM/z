//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public class UriSchemes
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/File_URI_scheme
        /// </summary>
        public readonly struct File : IUriScheme
        {
            public string Name => nameof(File);

            public UriPartKind Kind => UriPartKind.Scheme;
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Data_URI_scheme
        /// </summary>
        public readonly struct Data : IUriScheme
        {
            public string Name => nameof(Data);

            public UriPartKind Kind => UriPartKind.Scheme;
        }

        public readonly struct Doc : IUriScheme
        {
            public string Name => nameof(Doc);

            public UriPartKind Kind => UriPartKind.Scheme;
        }

        public readonly struct Cmd : IUriScheme
        {
            public string Name => nameof(Cmd);

            public UriPartKind Kind => UriPartKind.Scheme;
        }

        public readonly struct Tool : IUriScheme
        {
            public string Name => nameof(Tool);

            public UriPartKind Kind => UriPartKind.Scheme;
        }

        public readonly struct Machine : IUriScheme
        {
            public string Name => nameof(Machine);

            public UriPartKind Kind => UriPartKind.Scheme;
        }

        public readonly struct Local : IUriScheme
        {
            public string Name => nameof(Local);

            public UriPartKind Kind => UriPartKind.Scheme;
        }       
    }
}