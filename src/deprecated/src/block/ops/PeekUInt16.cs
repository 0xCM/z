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
            public bool PeekUInt16(int offset, out ushort dst)
            {
                if(Available(offset, sizeof(ushort)))
                {
                    dst = PeekUInt16(offset);
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            [MethodImpl(Inline), Op]
            public ushort PeekUInt16(int offset)
            {
                unchecked
                {
                    byte* ptr = Pointer + offset;
                    return (ushort)(ptr[0] | (ptr[1] << 8));
                }
            }
        }
    }
}