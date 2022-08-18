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
            public int IndexOf(byte b, int start)
                => IndexOfUnchecked(b, start);

            [MethodImpl(Inline), Op]
            public int IndexOfUnchecked(byte b, int start)
            {
                byte* p = Pointer + start;
                byte* end = Pointer + Length;
                while (p < end)
                {
                    if (*p == b)
                        return (int)(p - Pointer);

                    p++;
                }

                return -1;
            }
        }
    }
}