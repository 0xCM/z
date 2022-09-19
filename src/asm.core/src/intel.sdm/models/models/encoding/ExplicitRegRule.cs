//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public readonly struct ExplicitRegRule : IEncodingRule<ExplicitRegRule>
        {
            public byte RuleId {get;}

            [MethodImpl(Inline)]
            public ExplicitRegRule(byte id)
            {
                RuleId = id;
            }

            public EncodingClass Class
                => EncodingClass.ExplicitRegs;
        }
    }
}