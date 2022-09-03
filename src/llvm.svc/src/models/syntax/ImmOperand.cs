//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    partial struct AsmSyntaxModel
    {
        public struct ImmOperand : IOperand<AsmOpClass,Imm>
        {
            public readonly Imm Value;

            [MethodImpl(Inline)]
            public ImmOperand(Imm value)
            {
                Value = value;
            }

            public AsmOpClass Kind => AsmOpClass.Imm;

            Imm IOperand<Imm>.Value
                => Value;
        }
    }
}