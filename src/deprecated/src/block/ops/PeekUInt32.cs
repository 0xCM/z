//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            [MethodImpl(Inline), Op]
            public bool PeekUInt32(int offset, out uint dst)
            {
                if(Available(offset, sizeof(uint)))
                {
                    dst = PeekUInt32(offset);
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            [MethodImpl(Inline), Op]
            public uint PeekUInt32(int offset)
            {
                unchecked
                {
                    byte* ptr = Pointer + offset;
                    return (uint)(ptr[0] | (ptr[1] << 8) | (ptr[2] << 16) | (ptr[3] << 24));
                }
            }
        }
    }
}