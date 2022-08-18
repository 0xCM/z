//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct expr
    {
        [MethodImpl(Inline), Op]
        public static OpExprSpec spec(ExprScope scope, string opname, IExprDeprecated[] operands)
            => new OpExprSpec(scope,opname,operands);

        [MethodImpl(Inline), Op]
        public static ExprSpec spec(ExprScope scope, IExprDeprecated[] operands, IExprComposer composer)
            => new ExprSpec(scope,operands,composer);
    }
}