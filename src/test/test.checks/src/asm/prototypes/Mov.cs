//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.Intrinsics;

    using static core;
    using static Root;

    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + "mov")]
        public readonly struct Mov
        {
            [Op]
            public static unsafe void mov2x8u(byte* a, byte* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }


            [Op]
            public static unsafe void mov2x16u(ushort* a, ushort* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x32u(uint* a, uint* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x64u(ulong* a, ulong* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x128u(ByteBlock16* a, ByteBlock16* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x256u(ByteBlock32* a, ByteBlock32* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

            [Op]
            public static unsafe void mov2x512u(ByteBlock512* a, ByteBlock512* b)
            {
                a[0] = b[0];
                a[1] = b[1];
                a[2] = b[2];
                a[3] = b[3];
                a[4] = b[4];
                a[5] = b[5];
                a[6] = b[6];
                a[7] = b[7];
            }

        }
    }
}