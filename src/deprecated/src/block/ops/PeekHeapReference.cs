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
            // #String, #Blob heaps
            [MethodImpl(Inline), Op]
            public uint PeekHeapReference(int offset, bool smallRefSize)
                => smallRefSize ? PeekUInt16(offset) : PeekUInt32(offset);
        }
    }
}