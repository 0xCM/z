//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public class Optional : Optional<IRuleExpr>
        {
            public Optional(IRuleExpr src)
                : base(src)
            {

            }
        }
    }
}