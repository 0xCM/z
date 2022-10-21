//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines primary api surface for rowbit manipulation
    /// </summary>
    [ApiHost]
    public readonly struct RowBits
    {
        public const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Allocates a specified number of rows
        /// </summary>
        /// <param name="rows">The row count</param>
        /// <typeparam name="T">The primal type that implicitly defines the number of columns in each row</typeparam>
        public static RowBits<T> alloc<T>(int rows)
            where T : unmanaged
                => new RowBits<T>(new T[rows]);

        /// <summary>
        /// Loads loads rows from a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The primal type that implicitly defines the number of matrix columns</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> load<T>(Span<byte> src)
            where T : unmanaged
                => new RowBits<T>(recover<T>(src));

        /// <summary>
        /// Loads loads rows from a span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The primal type that implicitly defines the number of matrix columns</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> load<T>(Span<T> src)
            where T : unmanaged
                => new RowBits<T>(src);

        /// <summary>
        /// Loads rows from an array
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The primal type that implicitly defines the number of matrix columns</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> load<T>(params T[] src)
            where T : unmanaged
               => new RowBits<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> block<T>(in RowBits<T> src, uint firstRow)
            where T : unmanaged
                => load(slice(src.Storage, firstRow));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> block<T>(in RowBits<T> src, uint firstRow, uint lastRow)
            where T : unmanaged
                => load(slice(src.Storage,firstRow, lastRow - firstRow));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> not<T>(in RowBits<T> src, in RowBits<T> dst)
            where T : unmanaged
        {
            for(var i=0; i<src.RowCount; i++)
                dst[i] = BitVectors.not(src[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> and<T>(in RowBits<T> a, in RowBits<T> b, in RowBits<T> dst)
            where T : unmanaged
        {
            var count = a.RowCount;
            for(var i=0; i<count; i++)
                dst[i] = BitVectors.and(a[i],b[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> cnonimpl<T>(in RowBits<T> a, in RowBits<T> b, in RowBits<T> dst)
            where T : unmanaged
        {
            var count = a.RowCount;
            for(var i=0; i<count; i++)
                dst[i] = BitVectors.cnonimpl(a[i],b[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> or<T>(in RowBits<T> x, in RowBits<T> y, in RowBits<T> dst)
            where T : unmanaged
        {
            var rc = x.RowCount;
            for(var i=0; i<rc; i++)
                dst[i] = BitVectors.or(x[i],y[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> xor<T>(in RowBits<T> x, in RowBits<T> y, in RowBits<T> dst)
            where T : unmanaged
        {
            var rc = x.RowCount;
            for(var i=0; i<rc; i++)
                dst[i] = BitVectors.xor(x[i],y[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> nand<T>(in RowBits<T> x, in RowBits<T> y, in RowBits<T> dst)
            where T : unmanaged
        {
            var rc = x.RowCount;
            for(var i=0; i<rc; i++)
                dst[i] = BitVectors.nand(x[i],y[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> nor<T>(in RowBits<T> a, in RowBits<T> b, in RowBits<T> dst)
            where T : unmanaged
        {
            var count = a.RowCount;
            for(var i=0; i<count; i++)
                dst[i] = BitVectors.nor(a[i],b[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> xnor<T>(in RowBits<T> a, in RowBits<T> b, in RowBits<T> dst)
            where T : unmanaged
        {
            var count = a.RowCount;
            for(var i=0; i<count; i++)
                dst[i] = BitVectors.xnor(a[i],b[i]);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> not<T>(in RowBits<T> x)
            where T : unmanaged
                => not(x, alloc<T>(x.RowCount));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> and<T>(in RowBits<T> x, in RowBits<T> y)
            where T : unmanaged
                => and(x,y, alloc<T>(x.RowCount));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> cnonimpl<T>(in RowBits<T> x, in RowBits<T> y)
            where T : unmanaged
                => cnonimpl(x,y, alloc<T>(x.RowCount));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> or<T>(in RowBits<T> x, in RowBits<T> y)
            where T : unmanaged
                => or(x,y, alloc<T>(x.RowCount));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> xor<T>(in RowBits<T> x, in RowBits<T> y)
            where T : unmanaged
                => xor(x,y, alloc<T>(x.RowCount));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> nand<T>(in RowBits<T> x, in RowBits<T> y)
            where T : unmanaged
                => nand(x,y, alloc<T>(x.RowCount));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> nor<T>(in RowBits<T> x, in RowBits<T> y)
            where T : unmanaged
                => nor(x,y, alloc<T>(x.RowCount));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RowBits<T> xnor<T>(in RowBits<T> x, in RowBits<T> y)
            where T : unmanaged
                => xnor(x,y, alloc<T>(x.RowCount));
    }
}