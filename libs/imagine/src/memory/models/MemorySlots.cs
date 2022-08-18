//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    public readonly struct MemorySlots
    {
        readonly Seq<MemorySeg> Data;

        public static void update<T>(ReadOnlySpan<BinaryCode> src, MemorySlots<T> slots)
            where T : unmanaged
        {
            var count = slots.Length;
            ref readonly var lead = ref slots.First;
            for(var i=0u; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                ref readonly var source = ref code[0];
                ref readonly var slot = ref skip(lead, i);
                ref var target = ref slot.BaseAddress.Ref<byte>();
                for(var j=0u; j<slot.Length; j++)
                    seek(target,j) = skip(source,j);
            }
        }

        public static string[] format<E>(MemorySlots<E> src)
            where E : unmanaged
        {
            var dst = sys.alloc<string>(src.Length);
            format(src,dst);
            return dst;
        }

        public static void format<E>(MemorySlots<E> src, Span<string> dst)
            where E : unmanaged
        {
            var count = src.Length;
            ref readonly var lead = ref src.Lookup(default(E));
            for(var i=0u; i<count; i++)
                seek(dst,i) = skip(lead,i).Format();
        }

        [MethodImpl(Inline)]
        public MemorySlots(MemorySeg[] src)
            => Data = src;

        [MethodImpl(Inline)]
        public ref readonly MemorySeg Lookup(byte index)
            => ref Data[index];

        public ref readonly MemorySeg this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref Lookup(index);
        }

        public byte Length
        {
            [MethodImpl(Inline)]
            get => (byte)Data.Length;
        }

        [MethodImpl(Inline)]
        public static implicit operator MemorySlots(MemorySeg[] src)
            => new MemorySlots(src);

        [MethodImpl(Inline)]
        public static implicit operator MemorySlots(Index<MemorySeg> src)
            => new MemorySlots(src);

        [MethodImpl(Inline)]
        public static implicit operator MemorySeg[](MemorySlots src)
            => src.Data;
    }
}