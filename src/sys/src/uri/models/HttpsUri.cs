//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class HttpsUri : Uri<HttpsUri,UriSchemes.Https>
    {
        public HttpsUri()
        {

        }
        public HttpsUri(string src)
            : base(src)
        {

        }

        public override string ToString()
            => $"{Scheme}://{Data.PathAndQuery}";
    }
}