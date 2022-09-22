//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class OptionRule : Optional<IRuleExpr>
    {
        public OptionRule(IRuleExpr src)
            : base(src)
        {

        }
    }    
}