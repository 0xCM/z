//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
        [MethodImpl(Inline), Op]
        public static unsafe MemoryBlock block(byte* pSrc, ByteSize size)
            => new MemoryBlock(pSrc,size);

        [MethodImpl(Inline), Op]
        public static unsafe MemoryBlock block(MemoryBlock src, uint offset, ByteSize size)
        {
            if(available(src, offset, size))
                return new MemoryBlock(src.Pointer + offset, size);
            else
                return MemoryBlock.Empty;
        }
    }
}