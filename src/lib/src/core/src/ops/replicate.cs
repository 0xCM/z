//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op]
        public static Span<byte> replicate(MemoryRange src)
        {
            Span<byte> dst = alloc<byte>(src.ByteCount);
            memory.copy(src, dst);
            return dst;
        }
    }
}