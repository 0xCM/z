//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class HttpUri : Uri<HttpUri,UriSchemes.Http>
    {
        public HttpUri()
        {

        }
        public HttpUri(string src)
            : base(src)
        {

        }

        public override string ToString()
            => $"{Scheme}://{Data.PathAndQuery}";
    }
}