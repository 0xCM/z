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
            public interface SourceFile
            {
                Seq<Statement> Nodes {get;}

            }
        }
    }
}