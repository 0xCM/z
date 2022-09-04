//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static UriSchemes;

    public sealed record class FileUri : Uri<FileUri,Local>
    {
        public FileUri()
        {

        }

        public FileUri(string src)
            : base(src)
        {

        }
    }
}