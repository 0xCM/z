//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    public class SeqProduction : Production<IRuleExpr, SeqExpr>, ISeqProduction<IRuleExpr>
    {
        public SeqProduction(IRuleExpr src, SeqExpr dst)
            : base(src, dst)
        {

        }
    }

}