//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMemDb
    {
        MemoryFileInfo Description {get;}

        ReadOnlySpan<byte> Load(AllocToken token);

        AllocToken Store(ReadOnlySpan<byte> src);

        Span<byte> Edit(AllocToken token);

        ulong Capacity
            => Description.Size;
    }
}