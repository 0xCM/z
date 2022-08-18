//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        [MethodImpl(Inline)]
        public static T bfly<N,T>(T a)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            if(typeof(N) == typeof(N1))
                return bfly(n1, a);
            else if(typeof(N) == typeof(N2))
                return bfly(n2, a);
            else if(typeof(N) == typeof(N4))
                return bfly(n4, a);
            else if(typeof(N) == typeof(N8))
                return bfly(n8, a);
            else if(typeof(N) == typeof(N16))
                return bfly(n16, a);
            else
                throw no<N>();
        }

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior two bits of each 4-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bfly<T>(N1 n, T x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.bfly(n, uint8(x)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.bfly(n, uint16(x)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.bfly(n, uint32(x)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.bfly(n, uint64(x)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior 2-bit segments of each 8-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bfly<T>(N2 n, T x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.bfly(n, uint8(x)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.bfly(n, uint16(x)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.bfly(n, uint32(x)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.bfly(n, uint64(x)));
            else
                throw no<T>();
        }

        /// <summary>
        /// [0 1 2 3 | 4 5 6 7 ] -> [0 2 1 3 | 4 6 5 7 ]
        /// Swaps the interior 4-bit segments of each 16-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bfly<T>(N4 n, T x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return x;
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.bfly(n,uint16(x)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.bfly(n,uint32(x)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.bfly(n,uint64(x)));
            else
                throw no<T>();
        }

        /// <summary>
        /// [0 1 2 3 | 4 5 6 7] -> [0 2 1 3 | 4 6 5 7]
        /// Swaps the interior 8-bit segments of each 32-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bfly<T>(N8 n, T x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte) || typeof(T) == typeof(ushort))
                return x;
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.bfly(n,uint32(x)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.bfly(n, uint64(x)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior 16-bit segments
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T bfly<T>(N16 n, T x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte) || typeof(T) == typeof(ushort) || typeof(T) == typeof(uint))
                return x;
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.bfly(n,uint64(x)));
            else
                throw no<T>();
        }
    }
}