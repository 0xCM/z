//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NuGetFeed
    {
        public readonly Uri Uri;

        public NuGetFeed(string uri)
        {
            Uri = new(uri);
        }

        public string Format()
            => Uri.ToString();

        public override string ToString()
            => Format();

        public static implicit operator NuGetFeed(string src)
            => new (src);
    }
}