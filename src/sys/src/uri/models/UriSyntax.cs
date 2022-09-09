//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // URI = scheme ":" ["//" authority] path ["?" query] ["#" fragment]
    public class UriSynax
    {
        public class Scheme : ISyntaxNode<Scheme>
        {

        }

        public class Authority : ISyntaxNode<Authority>
        {


        }

        public class Query : ISyntaxNode<Query>
        {


        }

        public class Fragment  : ISyntaxNode<Fragment>
        {


        }
    }
}