//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct EncodingOperand
        {
            public OperandIndex OpNumber {get;}

            public EncodingSig Sig {get;}

            [MethodImpl(Inline)]
            public EncodingOperand(OperandIndex n, EncodingSig sig)
            {
                OpNumber = n;
                Sig = sig;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Sig.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Sig.IsEmpty;
            }

            public static EncodingOperand Empty => default;
        }
    }
}