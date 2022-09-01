//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public readonly struct EvexRule : IEncodingRule<EvexRule>
        {
            public byte RuleId {get;}

            [MethodImpl(Inline)]
            public EvexRule(byte id)
            {
                RuleId = id;
            }

            public EncodingClass Class
                => EncodingClass.Evex;
        }
    }
}