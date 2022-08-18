//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct OpExprSpec
    {
        public ExprScope Scope {get;}

        public string OpName {get;}

        public Index<IExprDeprecated> Operands {get;}

        [MethodImpl(Inline)]
        public OpExprSpec(ExprScope scope, string opname, IExprDeprecated[] operands)
        {
            Scope = scope;
            OpName = opname;
            Operands = operands;
        }
    }
}