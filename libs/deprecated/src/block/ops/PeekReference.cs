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
            // When reference has at most 24 bits.
            [MethodImpl(Inline), Op]
            public uint PeekReference(int offset, bool smallRefSize)
                => smallRefSize ? PeekUInt16(offset) : PeekUInt32(offset);

            // Use when searching for a tagged or non-tagged reference.
            // The result may be an invalid reference and shall only be used to compare with a valid reference.
            [MethodImpl(Inline), Op]
            public uint PeekReferenceUnchecked(int offset, bool smallRefSize)
                => smallRefSize ? PeekUInt16(offset) : PeekUInt32(offset);
        }
    }
}