//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TS
    {
        public partial class Ast
        {
            public interface Node
            {
                Seq<Node> Nodes {get;}
            }

            public interface Node<T> : Node
                where T : Node<T>
            {
                new Seq<T> Nodes {get;}

                Seq<Node> Node.Nodes
                    => Nodes.Cast<Node>();
            }
        }
    }
}