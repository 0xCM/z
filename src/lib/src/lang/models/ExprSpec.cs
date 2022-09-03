//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExprSpec
    {
        public ExprScope Scope {get;}

        public Index<IExprDeprecated> Operands {get;}

        public IExprComposer Composer {get;}

        [MethodImpl(Inline)]
        public ExprSpec(ExprScope scope, IExprDeprecated[] operands, IExprComposer composer)
        {
            Scope = scope;
            Operands = operands;
            Composer = composer;
        }
    }
}