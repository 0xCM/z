//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static BitSpans32;

    public static partial class XBitSpans
    {
        const NumericKind Closure = UnsignedInts;
    }

    partial class XBitSpans
    {
        /// <summary>
        /// Loads a natspan from a bitspan (nonallocating)
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="n">The length representative</param>
        /// <typeparam name="N">The length type</typeparam>
        [MethodImpl(Inline)]
        public static NatSpan<N,Bit32> ToNatSpan<N>(this in BitSpan32 src, N n = default)
            where N : unmanaged, ITypeNat
                => NatSpans.load(src.Edit,n);

        /// <summary>
        /// Obliterates all bitspan content
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 Clear(this in BitSpan32 src)
        {
            clear(src);
            return ref src;
        }

        /// <summary>
        /// Clears a contiguous sequence of bits between two indices
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="i0">The index of the first bit to clear</param>
        /// <param name="i1">The index of the last bit to clear</param>
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 Clear(this in BitSpan32 src, int i0, int i1)
        {
            clear(src, i0, i1);
            return ref src;
        }

        /// <summary>
        /// Replicates the source content into a new bitspan
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="count">The number of source copies to produce</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 Replicate(this in BitSpan32 src, int copies = 1)
            => replicate(src,copies);

        /// <summary>
        /// Extracts and packs bitsize[T] source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="t">A target scalar type representative</param>
        /// <typeparam name="T">The target scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T Extract<T>(this in BitSpan32 src, T t = default)
            where T : unmanaged
                => BitSpans32.extract<T>(src);

        /// <summary>
        /// Extracts a T-valued scalar (or portion thereof) from the source
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T Convert<T>(this in BitSpan32 src)
            where T : unmanaged
                => BitSpans32.bitslice<T>(src);

        /// <summary>
        /// Extracts a T-valued scalar (or portion thereof) from the source segment [offset,..,offset - (bitsize[T] - 1)]
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The index of the first bit</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T BitSlice<T>(this in BitSpan32 src, int offset)
            where T : unmanaged
                => BitSpans32.bitslice<T>(src, offset);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T BitSlice<T>(this in BitSpan32 src, int offset, int count)
            where T : unmanaged
                => BitSpans32.bitslice<T>(src, offset, count);

        /// <summary>
        /// Eliminates leading zeroes, if any, from the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 Trim(this in BitSpan32 src)
            => BitSpans32.trim(src);

        /// <summary>
        /// Clamps the source bitstring to one of a specified maximum length, discarding any excess
        /// </summary>
        /// <param name="src">The source bitstring</param>
        /// <param name="maxbits">The maximum length of the target bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 Truncate(this in BitSpan32 src, int maxbits)
            => BitSpans32.truncate(src,maxbits);

        /// <summary>
        /// Concatenates two bitspans
        /// </summary>
        /// <param name="head">The leading bits</param>
        /// <param name="tail">The trailing bits</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 Concat(this in BitSpan32 head, in BitSpan32 tail)
            => BitSpans32.concat(head,tail);
    }
}