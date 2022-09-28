//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class GitUri : Uri<GitUri,UriSchemes.Git>
    {
        public GitUri()
        {

        }
        public GitUri(string src)
            : base(src)
        {

        }

        public override string ToString()
            => $"{Scheme}://{Data.PathAndQuery}";
    }
}