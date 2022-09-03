//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public readonly struct OpCodeArithmetic : IEncodingRule<OpCodeArithmetic>
        {
            public byte RuleId {get;}

            [MethodImpl(Inline)]
            public OpCodeArithmetic(byte id)
            {
                RuleId = id;
            }

            public EncodingClass Class
                => EncodingClass.Arithmetic;
        }
    }
}