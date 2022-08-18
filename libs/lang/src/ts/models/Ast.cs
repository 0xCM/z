//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class XTend
    {

    }
    partial class TS
    {
        public class Ast
        {
            public interface TypeAliasDeclaration
            {

                
            }

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

            public interface SourceFile
            {
                Seq<Statement> Nodes {get;}

            }
            
            public interface Statement
            {


            }

            public interface Statements
            {
                Seq<Statement> Nodes {get;}
            }
        }
    }
}