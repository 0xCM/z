//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            [Op]
            public static byte[] ReadBytes(byte* pSrc, int byteCount)
            {
                if (byteCount == 0)
                    return array<byte>();

                var dst = new byte[byteCount];
                Marshal.Copy((IntPtr)pSrc, dst, 0, byteCount);
                return dst;
            }
        }
    }
}