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
        public readonly struct VsibRule : IEncodingRule<VsibRule>
        {
            public byte RuleId {get;}

            [MethodImpl(Inline)]
            public VsibRule(byte id)
            {
                RuleId = id;
            }

            public EncodingClass Class
                => EncodingClass.Vsib;
        }
    }
}