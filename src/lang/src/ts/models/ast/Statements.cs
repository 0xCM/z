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
            public interface Statements
            {
                Seq<Statement> Nodes {get;}
            }
        }
    }
}