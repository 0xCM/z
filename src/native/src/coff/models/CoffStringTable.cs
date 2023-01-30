//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = CoffObjects;

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

        // [MethodImpl(Inline)]
        // public ReadOnlySpan<AsciCode> Entry(Address32 offset)
        //     => api.entry(this, offset);

        public string Text(in CoffSymbol sym)
            => api.format(this, sym);

        [MethodImpl(Inline)]
        public uint EntrySize(Address32 offset)
            => api.length(this, offset);
    }
}