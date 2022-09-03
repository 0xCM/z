//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    partial struct AsmSyntaxModel
    {
        public struct RegOperand : IOperand<AsmOpClass,RegIdentifier>
        {
            public readonly RegIdentifier Value;

            [MethodImpl(Inline)]
            public RegOperand(RegIdentifier value)
            {
                Value = value;
            }

            public AsmOpClass Kind
                => AsmOpClass.Reg;

            RegIdentifier IOperand<RegIdentifier>.Value
                => Value;
        }
    }
}