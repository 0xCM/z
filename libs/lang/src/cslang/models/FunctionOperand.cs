//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CsModels
    {
        public struct FunctionOperand
        {
            public Identifier OperandName;

            public Identifier OperandType;

            public ClrParamModifierKind Modifier;
        }
    }
}