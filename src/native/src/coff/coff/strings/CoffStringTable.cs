//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = CoffStrings;

    public ref struct CoffStringTable
    {
        public readonly ReadOnlySpan<byte> Data;

        [MethodImpl(Inline)]
        public CoffStringTable(ReadOnlySpan<byte> src)
        {
            Data = src;
        }

        public uint TableSize
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public string Text(in CoffSymbol sym)
            => api.format(this, sym);

        [MethodImpl(Inline)]
        public uint EntrySize(Address32 offset)
            => api.length(this, offset);
    }
}