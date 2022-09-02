//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    using static UriSchemes;

    public sealed record class LocalUri : Uri<LocalUri,Local>
    {
        public LocalUri()
        {

        }

        public LocalUri(string src)
            : base(src)
        {

        }
    }
}