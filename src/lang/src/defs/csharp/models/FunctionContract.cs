//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CsModels
    {
        public struct FunctionContract
        {
            public Identifier FunctionName;

            public ClrAccessKind Access;

            public ClrModifierKind Modifier;

            public Index<FunctionOperand> Operands;

            public Identifier ReturnType;

            public bool HasBody;
        }
    }
}
