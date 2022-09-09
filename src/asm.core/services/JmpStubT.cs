//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct JmpStub<T>
        where T : unmanaged
    {
        public MemoryRange Location;

        [MethodImpl(NotInline)]
        ulong Jump(T a0)
            => timestamp();

        public MemoryRange Init()
        {
            Jump(default);
            var @base = ClrJit.jit(GetType().Method(nameof(Jump)));
            var size = 16ul;
            var liberated = memory.liberate(@base, size);
            if(liberated.IsNonZero)
                Location = (@base, @base + size);
            return Location;
        }
    }
}