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
        public readonly struct ImmRule : IEncodingRule<ImmRule>
        {
            readonly byte Data;

            public byte RuleId {get;}

            [MethodImpl(Inline)]
            public ImmRule(byte id, byte data)
            {
                RuleId = id;
                Data = data;
            }

            public EncodingClass Class
                => EncodingClass.Imm;

            public bit Imm8()
                => (Data & 1) != 0;

            public bit Imm16()
                => (Data & 2) != 0;

            public bit Imm32()
                => (Data & 4) != 0;

            public static ImmRule Empty => default;
        }
    }
}