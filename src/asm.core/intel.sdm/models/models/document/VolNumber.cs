//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct SdmModels
    {
        public struct VolNumber
        {
            public byte Value;

            [MethodImpl(Inline)]
            public VolNumber(byte value)
            {
                Value = value;
            }

            public string Format()
                => Value.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator VolNumber(byte src)
                => new VolNumber(src);

            public static VolNumber Empty => default;
        }
    }
}