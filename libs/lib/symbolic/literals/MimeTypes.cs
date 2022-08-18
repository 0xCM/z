//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MimeTypeNames;

    using N = MimeTypeNames;

    [ApiComplete]
    public readonly struct MimeTypes
    {
        const string sep = "-";

        public static MimeType AppOctetStream => new MimeType(application, octet + sep + N.stream);

        public static MimeType AppJson => new MimeType(application, json);
    }
}