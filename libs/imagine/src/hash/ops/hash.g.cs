//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Scalars;

    using H = HashCodes;
    using G = HashCodes.Generic;

    partial class HashCodes
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(T src)
            => Generic.hash(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(T x, T y)
            => Generic.combine(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(T x, T y, T z)
            => Generic.hash(x,y,z,z);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(T a, T b, T c, T d)
            => Generic.hash(a,b,c,d);

        [MethodImpl(Inline)]
        public static ulong hash64<X,Y>(X x, Y y)
            => Generic.hash(x) | (Generic.hash(y) << 32);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 native<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var dst = Hash32.Zero;
            var count = src.Length;
            if(count > 0)
            {
                dst = G.native(Spans.first(src));
                for(var i=1; i<src.Length; i++)
                    dst |= G.native(Spans.skip(src,i));
            }
            return dst;
        }

        partial class Generic
        {
            /// <summary>
            /// Computes calc codes for unmanaged system primitives
            /// </summary>
            /// <param name="src">The primal value</param>
            /// <typeparam name="T">The primitive type</typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint hash<T>(T src)
                => hash_u(src);

            /// <summary>
            /// Calculates a hash code for structured content and returns the content along with the calculated hash
            /// </summary>
            /// <param name="src">The source content</param>
            /// <typeparam name="C">The content type</typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint bytehash<C>(C src)
                where C : struct
                    => hash<byte>(sys.bytes(src));

            /// <summary>
            /// Creates a 32-bit calc code predicated on a type parameter
            /// </summary>
            /// <typeparam name="T">The source type</typeparam>
            [MethodImpl(Inline)]
            public static uint hash<T>()
                => H.hash(typeof(T));

            [MethodImpl(Inline)]
            public static Hash32 native<T>(T src)
                where T : unmanaged
                    => hash(src);

            /// <summary>
            /// Creates a 64-bit calc code 7predicated on two type parameters
            /// </summary>
            /// <typeparam name="S">The first type</typeparam>
            /// <typeparam name="T">The second type</typeparam>
            [MethodImpl(Inline)]
            public static ulong hash<S,T>()
                => (ulong)hash<S>() | (ulong)hash<T>() << 32;

            [MethodImpl(Inline), Op, Closures(Closure)]
            public static uint hash<T>(T a, T b, T c, T d)
                => combine(H.combine(hash(a), hash(b)), H.combine(hash(c), hash(d)));

            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint hash<T>(ReadOnlySpan<T> src)
            {
                var length = src.Length;
                if(length == 0)
                    return 0;

                var rolling = FnvOffsetBias;
                for(var i=0u; i<length-1; i++)
                {
                    ref readonly var x = ref Spans.skip(src,i);
                    ref readonly var y = ref Spans.skip(src,i + 1);
                    rolling = H.combine(rolling, combine(x,y))*H.FnvPrime;
                }
                return rolling;
            }

            [MethodImpl(Inline)]
            public static uint hash<T>(Span<T> src)
                => hash(Algs.@readonly(src));

            [MethodImpl(Inline)]
            public static uint hash<T>(T[] src)
                => hash(Spans.span(src));

            public static uint hash<S,T>(ReadOnlySpan<S> src, Func<S,T> fx, Span<T> dst)
            {
                var accumulator = new HashSet<T>();
                var count = src.Length;
                dst = sys.alloc<T>(count);
                for(var i=0; i<count; i++)
                {
                    dst[i] = fx(Spans.skip(src,i));
                    accumulator.Add(Spans.skip(dst,i));
                }
                return (uint)(count - accumulator.Count);
            }

            [MethodImpl(Inline)]
            static uint hash_u<T>(T src)
            {
                if(typeof(T) == typeof(byte))
                    return H.hash(uint8(src));
                else if(typeof(T) == typeof(ushort))
                    return H.hash(uint16(src));
                else if(typeof(T) == typeof(uint))
                    return H.hash(uint32(src));
                else if(typeof(T) == typeof(ulong))
                    return H.hash(uint64(src));
                else
                    return hash_i(src);
            }

            [MethodImpl(Inline)]
            static uint hash_i<T>(T src)
            {
                if(typeof(T) == typeof(sbyte))
                    return H.hash(int8(src));
                else if(typeof(T) == typeof(short))
                    return H.hash(int16(src));
                else if(typeof(T) == typeof(int))
                    return H.hash(int32(src));
                else if(typeof(T) == typeof(long))
                    return H.hash(int64(src));
                else
                    return hash_f(src);
            }

            [MethodImpl(Inline)]
            static uint hash_f<T>(T src)
            {
                if(typeof(T) == typeof(float))
                    return H.hash(float32(src));
                else if(typeof(T) == typeof(double))
                    return H.hash(float64(src));
                else if(typeof(T) == typeof(decimal))
                    return H.hash(float128(src));
                else
                    return hash_x(src);
            }

            [MethodImpl(Inline)]
            static uint hash_x<T>(T src)
            {
                if(typeof(T) == typeof(char))
                    return H.hash(c16(src));
                else if(typeof(T) == typeof(bool))
                    return H.hash(@bool(src));
                else
                    return fallback(src);
            }

            [MethodImpl(Inline)]
            static uint hash_u<T>(T x, T y)
            {
                if(typeof(T) == typeof(byte))
                    return H.combine(uint8(x), uint8(y));
                else if(typeof(T) == typeof(ushort))
                    return H.combine(uint16(x), uint16(y));
                else if(typeof(T) == typeof(uint))
                    return H.combine(uint32(x), uint32(y));
                else if(typeof(T) == typeof(ulong))
                    return H.combine(uint64(x), uint64(y));
                else
                    return hash_i(x,y);
            }

            [MethodImpl(Inline)]
            static uint hash_i<T>(T x, T y)
            {
                if(typeof(T) == typeof(sbyte))
                    return H.combine(int8(x), int8(y));
                else if(typeof(T) == typeof(short))
                    return H.combine(int16(x), int16(y));
                else if(typeof(T) == typeof(int))
                    return H.combine(int32(x), int32(y));
                else if(typeof(T) == typeof(long))
                    return H.combine(int64(x), int64(y));
                else
                    return hash_f(x,y);
            }

            [MethodImpl(Inline)]
            static uint hash_f<T>(T x, T y)
            {
                if(typeof(T) == typeof(float))
                    return H.combine(float32(x), float32(y));
                else if(typeof(T) == typeof(double))
                    return H.combine(float64(x), float64(y));
                else if(typeof(T) == typeof(decimal))
                    return H.combine(float128(x), float128(y));
                else
                    return fallback(x,y);
            }

            [MethodImpl(Inline)]
            static uint fallback<T>(T src)
                => (uint)(src?.GetHashCode() ?? 0);

            [MethodImpl(Inline)]
            static uint fallback<S,T>(S x, T y)
                => H.combine(
                    (uint)(x?.GetHashCode() ?? 0),
                    (uint)(y?.GetHashCode() ?? 0)
                    );
        }
    }
}