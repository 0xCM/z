//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using static Rules;

    public interface ISeqProduction<S> : IProduction<S,SeqExpr>
        where S : IRuleExpr
    {

    }
}