//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SyntaxModels;

    public interface ISyntaxNode
    {
        NodeName Name {get;}
    }
    
    public interface ISyntaxNode<S> : ISyntaxNode
        where S : ISyntaxNode<S>, new()
    {


    }

    public class UriSynax
    {
        public class Scheme
        {

        }

        public class Authority
        {


        }

        public class Query
        {


        }

        public class Fragment 
        {


        }
    }

    // URI = scheme ":" ["//" authority] path ["?" query] ["#" fragment]

}