//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AlgDynamic
    {
        internal readonly struct CalcBytes
        {
            /// <summary>
            /// X86-executable code obtained by disassembling <see cref="eval(Add, byte, byte)"/>
            /// </summary>
            public static ReadOnlySpan<byte> add_ᐤ8iㆍ8iᐤ
                => new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbe,0xc1,0x48,0x0f,0xbe,0xd2,0x03,0xc2,0x48,0x0f,0xbe,0xc0,0xc3};

            /// <summary>
            /// X86-executable code obtained by disassembling <see cref="eval(Sub, byte, byte)"/>
            /// </summary>
            public static ReadOnlySpan<byte> sub_ᐤ8uㆍ8uᐤ
                => new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x2b,0xc2,0x0f,0xb6,0xc0,0xc3};

            /// <summary>
            /// X86-executable code obtained by disassembling <see cref="eval(Mul, byte, byte)"/>
            /// </summary>
            public static ReadOnlySpan<byte> mul_ᐤ8uㆍ8uᐤ
                => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x0f,0xaf,0xc2,0x0f,0xb6,0xc0,0xc3};

            /// <summary>
            /// X86-executable code obtained by disassembling <see cref="eval(Div, byte, byte)"/>
            /// </summary>
            public static ReadOnlySpan<byte> div_ᐤ8uㆍ8uᐤ
                => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xca,0x99,0xf7,0xf9,0x0f,0xb6,0xc0,0xc3};

            /// <summary>
            /// X86-executable code obtained by disassembling <see cref="eval(BLK.And, byte, byte)"/>
            /// </summary>
            public static ReadOnlySpan<byte> and_ᐤ8uㆍ8uᐤ
                => new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x23,0xc2,0x0f,0xb6,0xc0,0xc3};
        }
    }
}