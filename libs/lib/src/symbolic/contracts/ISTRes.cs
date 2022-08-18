//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public unsafe interface ISTRes
    {
        uint EntryCount {get;}

        uint CharCount {get;}

        MemoryAddress CharBase {get;}

        MemoryAddress OffsetBase {get;}

        MemoryStrings Strings {get;}

        ReadOnlySpan<char> this[int i]
            => cover(CharBase.Pointer<char>(), EntryCount);

        ReadOnlySpan<char> this[uint i]
            => cover(CharBase.Pointer<char>(), EntryCount);
    }

    [Free]
    public interface ISTRes<K> : ISTRes
        where K : unmanaged
    {
        ReadOnlySpan<char> this[K k]
        {
            [MethodImpl(Inline)]
            get => this[core.bw32(k)];
        }
    }

    [Free]
    public interface ISTRes<H,K> : ISTRes<K>
        where K : unmanaged
        where H : unmanaged, ISTRes<H,K>
    {

    }
}
