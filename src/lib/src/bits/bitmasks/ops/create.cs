//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMasks
    {
        /// <summary>
        /// [01010101]
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(in ParityMask<N2,N1,T> spec, N0 e)
            where T : unmanaged
                => even(spec.f, spec.d, spec.t);

        /// <summary>
        /// [10101010]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(in ParityMask<N2,N1,T> spec, N1 o)
            where T : unmanaged
                => odd<T>(spec. f,spec.d);

        /// <summary>
        /// [00110011]
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(in ParityMask<N2,N2,T> spec, N0 e)
            where T : unmanaged
                => even(spec.f, spec.d, spec.t);

        /// <summary>
        /// [11001100]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(in ParityMask<N2,N2,T> spec, N1 o)
            where T : unmanaged
                => odd<T>(spec.f, spec.d);

        /// <summary>
        /// [00000001]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N1,N1,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [01]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N2,N1,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [0001]
        /// The least bit of each 4-bit segment is enabled
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N4,N1,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [00000001]
        /// The least bit of each 8-bit segment is enabled
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N8,N1,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [00000000 00000001]
        /// The least bit of each 16-bit segment is enabled
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N16,N1,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [00000011]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N8,N2,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [000000111]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N8,N3,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [00000111]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N8,N4,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [00011111]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N8,N5,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [00111111]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N8,N6,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [01111111]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(LsbMask<N8,N7,T> spec)
            where T : unmanaged
                => lsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [10000001]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(JsbMask<N8,N1,T> spec)
            where T : unmanaged
                => jsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11000011]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(JsbMask<N8,N2,T> spec)
            where T : unmanaged
                => jsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11100111]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(JsbMask<N8,N3,T> spec)
            where T : unmanaged
                => jsb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [00011000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline)]
        public static T create<D,T>(CentralMask<N8,D,T> spec)
            where T : unmanaged
            where D : unmanaged, ITypeNat
                => central(spec.f, spec.d, spec.t);

        [MethodImpl(Inline)]
        public static T create<N,T>(IndexMask<N,T> spec)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => index<N,T>();

        /// <summary>
        /// [10]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N2,N1,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [10001000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N4,N1,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [10000000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N8,N1,T> spec)
            where T : unmanaged
                => msb(spec.f, spec.d, spec.t);

        /// <summary>
        /// [10000000 00000000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N16,N1,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11000000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N8,N2,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11100000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N8,N3,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11110000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N8,N4,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11111000]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N8,N5,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11111100]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N8,N6,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);

        /// <summary>
        /// [11111110]
        /// </summary>
        /// <param name="spec">The mask spec</param>
        /// <typeparam name="T">The mask data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T create<T>(MsbMask<N8,N7,T> spec)
            where T : unmanaged
                => msb(spec.f,spec.d,spec.t);
    }
}