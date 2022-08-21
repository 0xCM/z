//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(text)]
    public readonly struct MimeTypeNames
    {
        public const string application = nameof(application);

        public const string text = nameof(text);

        public const string css = nameof(css);

        public const string stream = nameof(stream);

        public const string octet = nameof(octet);

        public const string json = nameof(json);
    }
}