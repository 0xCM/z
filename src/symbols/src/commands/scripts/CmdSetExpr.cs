//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdSetExpr : CmdExpr<@string>
    {
        public CmdSetExpr(string name, @string value)
            : base(name,value)
        {

        }        
   }
}