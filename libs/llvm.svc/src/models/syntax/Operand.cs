//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    partial struct AsmSyntaxModel
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Operand : IOperand<AsmOpClass,Cell256>
        {
            public readonly AsmOpClass Kind;

            public readonly Cell256 Value;

            [MethodImpl(Inline)]
            public Operand(AsmOpClass kind, Cell256 value)
            {
                Kind = kind;
                Value = value;
            }

            AsmOpClass IOperand<AsmOpClass, Cell256>.Kind
                => Kind;

            Cell256 IOperand<Cell256>.Value
                => Value;
        }
    }
}