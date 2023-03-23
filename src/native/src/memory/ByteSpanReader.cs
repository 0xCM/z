//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe readonly struct ByteSpanReader
    {
        [MethodImpl(Inline), Op]
        public static ByteSpanReader create()
            => new ByteSpanReader(new ByteSpanProvider());

        readonly ByteSpanProvider Data;

        [MethodImpl(Inline), Op]
        public static MemorySeg segment(ByteSpanProvider src, byte n)
        {
            if(n == 0)
                return segment(src, n0);
            else if(n == 1)
                return segment(src, n1);
            else if(n == 2)
                return segment(src, n2);
            else if(n == 3)
                return segment(src, n3);
            else if(n == 4)
                return segment(src, n4);
            else if(n == 5)
                return segment(src, n5);
            else if(n == 6)
                return segment(src, n6);
            else if(n == 7)
                return segment(src, n7);
            else
                return segment(src, n256);
        }

        [MethodImpl(Inline)]
        public static unsafe MemorySeg segment<N>(ByteSpanProvider src, N n = default)
            where N : unmanaged, ITypeNat
        {
            var buffer = span<N>(src, n);
            var pSrc = gptr(sys.first(buffer));
            return new MemorySeg(pSrc, buffer.Length);
         }

        [MethodImpl(Inline), Op]
        public static Index<MemorySeg> segments(ByteSpanProvider src)
            => src.SegRefs();

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> span(ByteSpanProvider src, byte n)
        {
            if(n == 0)
                return span(src, n0);
            else if(n == 1)
                return span(src, n1);
            else if(n == 2)
                return span(src, n2);
            else if(n == 3)
                return span(src, n3);
            else if(n == 4)
                return span(src, n4);
            else if(n == 5)
                return span(src, n5);
            else if(n == 6)
                return span(src, n6);
            else if(n == 7)
                return span(src, n7);
            else
                return span(src, n256);
        }

        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> span<N>(ByteSpanProvider src, N n)
            where N : unmanaged, ITypeNat
        {
            if(typeof(N) == typeof(N0))
                return src.Seg(n6, n0);
            else if(typeof(N) == typeof(N1))
                return src.Seg(n6, n1);
            else if(typeof(N) == typeof(N2))
                return src.Seg(n6, n2);
            else if(typeof(N) == typeof(N3))
                return src.Seg(n6, n3);
            else if(typeof(N) == typeof(N4))
                return src.Seg(n7, n0);
            else if(typeof(N) == typeof(N5))
                return src.Seg(n7, n1);
            else if(typeof(N) == typeof(N6))
                return src.Seg(n8, n0);
            else if(typeof(N) == typeof(N7))
                return src.Seg(n8, n0);
            else
                return src.SegZ;
        }

        [MethodImpl(Inline), Op]
        public static MemorySeg[] refs(ByteSpanProvider src)
             => src.SegRefs();

        [MethodImpl(Inline), Op]
        public static ref readonly byte cell(ByteSpanProvider src, byte n, int i)
        {
            if(n == 0)
                return ref cell(src, n0, i);
            else if(n == 1)
                return ref cell(src, n1, i);
            else if(n == 2)
                return ref cell(src, n2, i);
            else if(n == 3)
                return ref cell(src, n3, i);
            else if(n == 4)
                return ref cell(src, n4, i);
            else if(n == 5)
                return ref cell(src, n5, i);
            else if(n == 6)
                return ref cell(src, n6, i);
            else if(n == 7)
                return ref cell(src, n7, i);
            else
                return ref core.first(src.SegZ);
        }

        [MethodImpl(Inline)]
        public static ref readonly byte cell<N>(ByteSpanProvider src, N n, int i)
            where N : unmanaged, ITypeNat
                => ref skip(span(src, n),(uint)i);

        [MethodImpl(Inline)]
        public static ref readonly byte first<N>(ByteSpanProvider src, N n)
            where N : unmanaged, ITypeNat
                => ref core.first(span(src, n));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> leads(ByteSpanProvider src)
            => src.SegLeads();

        [Op]
        public static void addresses(ReadOnlySpan<MemorySeg> src, Span<MemoryAddress> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var segment = ref skip(src,i);
                var length = segment.Length;
                var data = segment.Load();
                if(data.Length == length)
                {
                    for(var j = 0u; j<length; j++)
                    {
                        ref readonly var cell = ref skip(data,j);
                        if(j == 0)
                        {
                            var a = sys.address(cell);
                            if(segment.BaseAddress == a)
                                seek(dst,i) = a;
                        }
                    }
                }
            }
        }

        [Op]
        public static ReadOnlySpan<MemoryAddress> addresses(ByteSpanProvider src, Index<MemorySeg> store)
        {
            var sources = store.View;
            var results = sys.alloc<MemoryAddress>(sources.Length);
            addresses(store, results);
            return results;
        }

        public static ReadOnlySpan<Utf8Point> Utf8Points
        {
            [MethodImpl(Inline)]
            get => core.recover<byte,Utf8Point>(ByteSpanProvider.Storage.Seg(n7, n0));
        }

        [MethodImpl(Inline)]
        internal ByteSpanReader(ByteSpanProvider data)
            => Data = data;

        public MemorySeg[] Refs
        {
            [MethodImpl(Inline)]
            get => Data.SegRefs();
        }

        [MethodImpl(Inline), Op]
        public Index<MemorySeg> Segments()
            => segments(Data);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Leads()
            => leads(Data);

        [Op]
        public ReadOnlySpan<MemoryAddress> Locations(Index<MemorySeg> store)
            => addresses(Data, store);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Span(byte n)
            => span(Data, n);

        [MethodImpl(Inline)]
        public MemorySeg Segment(byte n)
            => segment(Data, n);

        [MethodImpl(Inline)]
        public ref readonly byte Cell(byte n, int i)
            => ref cell(Data, n, i);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Span<N>(N n)
            where N : unmanaged, ITypeNat
                => span(Data, n);

        [MethodImpl(Inline)]
        public ref readonly byte First<N>(N n)
            where N : unmanaged, ITypeNat
                => ref first(Data, n);

        [MethodImpl(Inline)]
        public ref readonly byte Cell<N>(N n, int i)
            where N : unmanaged, ITypeNat
                => ref cell(Data, n, i);

        [MethodImpl(Inline)]
        public unsafe MemorySeg Segment<N>(N n = default)
            where N : unmanaged, ITypeNat
                => segment(Data, n);
    }
}