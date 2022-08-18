//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            [MethodImpl(Inline), Op]
            public static ReadOnlySpan<byte> ViewBytes(byte* pSrc, int count)
                => core.cover(pSrc,count);
        }
    }
}