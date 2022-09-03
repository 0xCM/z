//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            [MethodImpl(Inline), Op]
            public byte PeekByte(int offset)
                => Pointer[offset];

            [MethodImpl(Inline), Op]
            public bool PeekByte(int offset, out byte dst)
            {
                if(Available(offset, sizeof(byte)))
                {
                    dst = Pointer[offset];
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }
        }
    }
}