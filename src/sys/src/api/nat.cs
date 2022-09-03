// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static sbyte nat8i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (sbyte)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static byte nat8u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (byte)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static short nat16i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (short)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static ushort nat16u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (ushort)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static int nat32i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (int)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static uint nat32u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (uint)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static ulong nat64u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static long nat64i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (long)value(n);
    }
}