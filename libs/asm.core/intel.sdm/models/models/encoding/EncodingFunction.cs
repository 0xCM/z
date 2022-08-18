//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct EncodingFunction
        {
            public EncodingOperand Op0 {get;}

            public EncodingOperand Op1 {get;}

            public EncodingOperand Op2 {get;}

            public EncodingOperand Op3 {get;}

            [MethodImpl(Inline)]
            public EncodingFunction(EncodingOperand op0)
            {
                Op0 = op0;
                Op1 = EncodingOperand.Empty;
                Op2 = EncodingOperand.Empty;
                Op3 = EncodingOperand.Empty;
            }

            [MethodImpl(Inline)]
            public EncodingFunction(EncodingOperand op0, EncodingOperand op1)
            {
                Op0 = op0;
                Op1 = op1;
                Op2 = EncodingOperand.Empty;
                Op3 = EncodingOperand.Empty;
            }

            [MethodImpl(Inline)]
            public EncodingFunction(EncodingOperand op0, EncodingOperand op1, EncodingOperand op2)
            {
                Op0 = op0;
                Op1 = op1;
                Op2 = op2;
                Op3 = EncodingOperand.Empty;
            }

            [MethodImpl(Inline)]
            public EncodingFunction(EncodingOperand op0, EncodingOperand op1, EncodingOperand op2, EncodingOperand op3)
            {
                Op0 = op0;
                Op1 = op1;
                Op2 = op2;
                Op3 = op3;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Op0.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Op0.IsEmpty;
            }

            public static EncodingFunction Emtpy
            {
                [MethodImpl(Inline)]
                get => new EncodingFunction(EncodingOperand.Empty);
            }
        }
    }
}