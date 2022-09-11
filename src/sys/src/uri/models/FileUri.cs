//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static UriSchemes;

    // URI = scheme ":" ["//" authority] path ["?" query] ["#" fragment]
    public sealed record class FileUri : Uri<FileUri,File>
    {

        public FileUri()
        {

        }

        public FileUri(string src)
            : base(src)
        {

        }

        public override string ToString()
            => $"{Scheme}://{Data.PathAndQuery}";

        public string LocalPath
            => Data.LocalPath;
    }
}