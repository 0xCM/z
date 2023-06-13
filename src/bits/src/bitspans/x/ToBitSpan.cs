//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Wraps a bitspan over a span of extant bits
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<bit> src)
            => BitSpans.load(src);

        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<bit> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<byte> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<ushort> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<uint> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<ulong> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<byte> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<ushort> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<uint> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<ulong> src)
            => BitSpans.create(src);

        // /// <summary>
        // /// Converts an 128-bit intrinsic vector representation to a bitspan
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // /// <typeparam name="T">The underlying primal type</typeparam>
        // public static BitSpan ToBitSpan<T>(this Vector128<T> src, uint? maxbits = null)
        //     where T : unmanaged
        //         => BitSpans.load(src, maxbits);

        // /// <summary>
        // /// Converts an 128-bit intrinsic vector representation to a bitspan
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // /// <typeparam name="T">The underlying primal type</typeparam>
        // public static BitSpan ToBitSpan<T>(this Vector256<T> src, uint? maxbits = null)
        //     where T : unmanaged
        //         => BitSpans.load(src, maxbits);

        // /// <summary>
        // /// Converts an enumeration value to a bitspan
        // /// </summary>
        // /// <param name="src">The source value</param>
        // /// <typeparam name="T">The enumeration type</typeparam>
        // public static BitSpan ToBitSpan<T>(this T src, uint? maxbits = null)
        //     where T : unmanaged, Enum
        //         => BitSpans.load(src, maxbits);

        [MethodImpl(Inline)]
        public static BitSpan32 ToBitSpan32<N,T>(this ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitVectorsK.bitspan32(x);

        [MethodImpl(Inline)]
        public static ScalarBits<T> ToBitVector<T>(this BitSpan32 src)
            where T : unmanaged
                => src.Extract<T>();

        [MethodImpl(Inline)]
        public static ScalarBits<N,T> ToBitVector<N,T>(this BitSpan32 src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
               => src.Extract<T>();

        [MethodImpl(Inline)]
        public static BitVector8 ToBitVector(this BitSpan32 src, N8 n)
            => src.Extract<byte>();

        [MethodImpl(Inline)]
        public static BitVector16 ToBitVector(this BitSpan32 src, N16 n)
            => src.Extract<ushort>();

        [MethodImpl(Inline)]
        public static BitVector32 ToBitVector(this BitSpan32 src, N32 n)
            => src.Extract<uint>();

        [MethodImpl(Inline)]
        public static BitVector64 ToBitVector(this BitSpan32 src, N64 n)
            => src.Extract<ulong>();
    }
}