//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct MemoryStore
    {
        readonly Index<MemorySymbol> _Symbols;

        readonly Index<uint> _Keys;

        public uint Capacity {get;}

        [MethodImpl(Inline)]
        internal MemoryStore(Index<MemorySymbol> symbols, Index<uint> keys, uint capacity)
        {
            Capacity = capacity;
            _Symbols = symbols;
            _Keys =  keys;
        }

        public ReadOnlySpan<MemorySymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => _Symbols;
        }

        [MethodImpl(Inline)]
        public uint? FindIndex(MemoryAddress address)
        {
            if(FindIndex(address, out var index))
                return index;
            else
                return null;
        }

        [MethodImpl(Inline)]
        public bool FindIndex(MemoryAddress address, out uint index)
        {
            var key = _Keys[MemoryStores.bucket(address,Capacity)];
            if(_Symbols[key].Address == address)
            {
                index = key;
                return true;
            }
            else
            {
                var search = Symbols;
                var count = search.Length;
                for(var i=0u; i< count; i++)
                {
                    if(skip(search,i).Address == address)
                    {
                        index = i;
                        return true;
                    }
                }
                index = uint.MaxValue;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint index)
            => _Symbols[index].Address;

        [MethodImpl(Inline)]
        public ref readonly MemorySymbol Symbol(uint index)
            => ref _Symbols[index];

        [MethodImpl(Inline)]
        public ByteSize RegionSize(uint index)
            => Symbol(index).Size;

        [MethodImpl(Inline)]
        public bool HasEntry(MemoryAddress address)
            => FindIndex(address, out var _);
    }
}