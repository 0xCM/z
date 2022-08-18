//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SdmModels
    {
        public readonly struct VexRule : IEncodingRule<VexRule>
        {
            public byte RuleId {get;}

            [MethodImpl(Inline)]
            public VexRule(byte id)
            {
                RuleId = id;
            }

            public EncodingClass Class
                => EncodingClass.Vex;
        }
    }
}