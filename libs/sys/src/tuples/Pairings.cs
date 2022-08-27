//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct Pairings
    {
        const NumericKind Closure = UnsignedInts;

        public static Pairings<S,T> empty<S,T>()
            => Pairings<S,T>.Empty;

        [MethodImpl(Inline)]
        public static Pairings<A,B> define<A,B>(Paired<A,B>[] src)
            => src;

        public static Pairings<A,B> define<A,B>(ReadOnlySpan<A> left, ReadOnlySpan<B> right)
        {
            var count = min(left.Length, right.Length);
            var dst = sys.alloc<Paired<A,B>>(count);
            define(left,right,dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static void define<A,B>(ReadOnlySpan<A> left, ReadOnlySpan<B> right, Pairings<A,B> dst)
        {
            var count = min(left.Length, right.Length);
            for(var i=0u; i<count; i++)
                dst[i] = Tuples.paired(skip(left,i), skip(right,i));
        }

        /// <summary>
        /// Creates a 0-based classifier map with at most <see cref='Pow2.T08'/> entries with indices of type <see cref='byte'/>
        /// </summary>
        /// <param name="w">The map width selector</param>
        /// <param name="src">The source classifiers</param>
        /// <typeparam name="K">The classifier type</typeparam>
        [Op, Closures(UInt8k)]
        public static PairMap<byte,K> map<K>(W8 w, K[] src)
        {
            var source = @readonly(src);
            var count = min((byte)src.Length, byte.MaxValue);
            var iK = sys.alloc<Paired<byte,K>>(count);
            var Ki = sys.alloc<Paired<K,byte>>(count);
            var indexed = span(iK);
            var kinds = span(Ki);
            project<K>(src, iK, Ki);
            return new PairMap<byte,K>(count, iK, Ki);
        }

        /// <summary>
        /// Creates a 0-based classifier map with at most <see cref='Pow2.T16'/> entries with indices of type <see cref='ushort'/>
        /// </summary>
        /// <param name="w">The map width selector</param>
        /// <param name="src">The source classifiers</param>
        /// <typeparam name="K">The classifier type</typeparam>
        [Op, Closures(UInt16k)]
        public static PairMap<ushort,K> map<K>(W16 w, K[] src)
        {
            var source = @readonly(src);
            var count = min((ushort)src.Length, ushort.MaxValue);
            var iK = sys.alloc<Paired<ushort,K>>(count);
            var Ki = sys.alloc<Paired<K,ushort>>(count);
            var indexed = span(iK);
            var kinds = span(Ki);
            project<K>(src, iK, Ki);
            return new PairMap<ushort,K>(count, iK, Ki);
        }

        /// <summary>
        /// Creates a 0-based classifier map with at most <see cref='Pow2.T32'/> entries with indices of type <see cref='uint'/>
        /// </summary>
        /// <param name="w">The map width selector</param>
        /// <param name="src">The source classifiers</param>
        /// <typeparam name="K">The classifier type</typeparam>
        [Op, Closures(UInt32k)]
        public static PairMap<uint,K> map<K>(W32 w, K[] src)
        {
            var source = @readonly(src);
            var count = min((uint)src.Length, uint.MaxValue);
            var iK = sys.alloc<Paired<uint,K>>(count);
            var Ki = sys.alloc<Paired<K,uint>>(count);
            var indexed = span(iK);
            var kinds = span(Ki);
            project<K>(src, iK, Ki);
            return new PairMap<uint,K>(count, iK, Ki);
        }

        /// <summary>
        /// Creates a 0-based classifier map with at most <see cref='Pow2.T32'/> entries with indices of type <see cref='ulong'/>
        /// </summary>
        /// <param name="w">The map width selector</param>
        /// <param name="src">The source classifiers</param>
        /// <typeparam name="K">The classifier type</typeparam>
        [Op, Closures(UInt64k)]
        public static PairMap<ulong,K> map<K>(W64 w, K[] src)
        {
            var source = @readonly(src);
            var count = min((ulong)src.Length, ulong.MaxValue);
            var iK = sys.alloc<Paired<ulong,K>>(count);
            var Ki = sys.alloc<Paired<K,ulong>>(count);
            var indexed = span(iK);
            var kinds = span(Ki);
            project<K>(src, iK, Ki);
            return new PairMap<ulong,K>((uint)count, iK, Ki);
        }

        public static PairMap<I,K> map<I,K>(Paired<I,K>[] src)
        {
            var source = @readonly(src);
            var count = (uint)src.Length;
            var iK = sys.alloc<Paired<I,K>>(count);
            var Ki = sys.alloc<Paired<K,I>>(count);
            project(source,iK,Ki);
            return new PairMap<I,K>(count, iK, Ki);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void project<K>(ReadOnlySpan<K> src, Span<Paired<byte,K>> indexed, Span<Paired<K,byte>> kinds)
        {
            var count = src.Length;
            for(byte i=0; i<count; i++)
            {
                ref readonly var k = ref skip(src,i);
                seek(indexed,i) = (i,k);
                seek(kinds, i) = (k,i);
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static void project<K>(ReadOnlySpan<K> src, Span<Paired<ushort,K>> indexed, Span<Paired<K,ushort>> kinds)
        {
            var count = src.Length;
            for(var i=z16; i<count; i++)
            {
                ref readonly var k = ref skip(src,i);
                seek(indexed,i) = (i,k);
                seek(kinds, i) = (k,i);
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static void project<K>(ReadOnlySpan<K> src, Span<Paired<uint,K>> indexed, Span<Paired<K,uint>> kinds)
        {
            var count = src.Length;
            for(ushort i=0; i<count; i++)
            {
                ref readonly var k = ref skip(src,i);
                seek(indexed,i) = (i,k);
                seek(kinds, i) = (k,i);
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static void project<K>(ReadOnlySpan<K> src, Span<Paired<ulong,K>> indexed, Span<Paired<K,ulong>> kinds)
        {
            var count = src.Length;
            for(ushort i=0; i<count; i++)
            {
                ref readonly var k = ref skip(src,i);
                seek(indexed, i) = (i,k);
                seek(kinds, i) = (k,i);
            }
        }

        [MethodImpl(Inline)]
        static void project<I,K>(ReadOnlySpan<Paired<I,K>> src, Span<Paired<I,K>> indexed, Span<Paired<K,I>> kinds)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var pair = ref skip(src,i);
                seek(indexed, i) = pair;
                seek(kinds, i) = (pair.Right, pair.Left);
            }
        }
    }
}