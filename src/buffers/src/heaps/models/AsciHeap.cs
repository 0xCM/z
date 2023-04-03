//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe readonly struct AsciHeap
    {
        public readonly MemoryAddress BaseAddress;
        
        public readonly ByteSize Size;
        
        [MethodImpl(Inline)]
        public AsciHeap(MemoryAddress @base, ByteSize size)
        {
            BaseAddress = @base;
            Size = size;
        }

        [MethodImpl(Inline)]
        public HeapReader Reader()
            => new HeapReader(this);

        public struct HeapReader 
        {
            readonly AsciHeap Heap;

            Address32 Rva;

            [MethodImpl(Inline)]
            public HeapReader(AsciHeap src)            
            {
                Heap = src;
                Rva = 0;
            }

            readonly MemoryAddress BaseAddress
            {
                [MethodImpl(Inline)]                
                get => Heap.BaseAddress;
            }

            readonly ByteSize Size
            {
                [MethodImpl(Inline)]                
                get => Heap.Size;
            }

            public bool ReadEntry(out asci dst)
            {
                var last = BaseAddress + Size;
                var address = BaseAddress + Rva;
                var pSymbol = address.Pointer<AsciSymbol>();
                var count = 0u;
                var result = address <= last;
                if(!result)
                    dst = asci.Empty;
                else
                {
                    while(address <= last)
                    {
                        var symbol = *pSymbol;
                        if(symbol.IsNonEmpty)
                            count++;
                        else
                            break;
                    }
                    dst = new (cover(pSymbol,count));
                }
                Rva += (count + 1);
                return result;
            }
        }

    }
}