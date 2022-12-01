//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using BG = Z0.BitGrid;
    using BS = Z0.BitBlocks;
    using BM = Z0.BitMatrix;

    partial class XTend
    {
        /// <summary>
        /// Represents the source matrix as a generic bitgrid of dimension 32x32 over cells of width 32
        /// </summary>
        /// <param name="src">The source matrix</param>
        [MethodImpl(Inline)]
        public static BitSpanBlocks256<uint> ToBitSpanBlocks256(this BitMatrix32 src)
            => BitGrid.load(SpanBlocks.load(n256,src.Content),32,32);

        [MethodImpl(Inline)]
        public static BitGrid<N64,N64,ulong> ToBitGrid(this BitMatrix64 src, N64 n)
            => BitGrid.load(SpanBlocks.load(n256,src.Content),n,n);

        /// <summary>
        /// Represents the source matrix as a generic bitgrid of dimension 64x64 over cells of width 64
        /// </summary>
        /// <param name="src">The source matrix</param>
        [MethodImpl(Inline)]
        public static BitSpanBlocks256<ulong> ToBitGrid(this BitMatrix64 src)
            => BitGrid.load(SpanBlocks.load(n256,src.Content),64,64);
    }

    public static class BitGridRng
    {
        /// <summary>
        /// Creates a 16-bit generic bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="w">The grid bit width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid16<T> BitGrid<T>(this ISource random, N16 w)
            where T : unmanaged
                => BG.define<T>(w, random.Next<ushort>());

        /// <summary>
        /// Creates a 32-bit generic bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="w">The grid bit width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid32<T> BitGrid<T>(this ISource random, N32 w)
            where T : unmanaged
                => BG.define<T>(w ,random.Next<uint>());

        /// <summary>
        /// Creates a 64-bit generic bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="w">The grid bit width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid64<T> BitGrid<T>(this ISource random, N64 w)
            where T : unmanaged
                => BG.define<T>(w,random.Next<ulong>());

        /// <summary>
        /// Allocates and populates a naturally-sized bitgrid from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> BitGrid<M,N,T>(this ISource random, M m = default, N n = default, T t = default)
            where M : unmanaged,ITypeNat
            where N : unmanaged,ITypeNat
            where T : unmanaged
        {
            var grid = BG.alloc(m,n,t);
            var segments = grids.gridcells(m,n,t);
            random.Fill((int)segments, ref grid.Head);
            return grid;
        }

        /// <summary>
        /// Fills a caller-supplied naturally-sized bitgrid from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="dst">The target grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitGrid<M,N,T> Fill<M,N,T>(this ISource random, in BitGrid<M,N,T> dst)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            random.Fill(dst.CellCount, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Creates a 1x16 16-bit natural bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid16<N1,N16,T> BitGrid<T>(this ISource random, N1 m, N16 n)
            where T : unmanaged
                => random.Next<ushort>();

        /// <summary>
        /// Creates a 16x1 6-bit natural bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid16<N16,N1,T> BitGrid<T>(this ISource random, N16 m, N1 n)
            where T : unmanaged
                => random.Next<ushort>();

        /// <summary>
        /// Creates a 2x8 16-bit natural bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid16<N2,N8,T> BitGrid<T>(this ISource random, N2 m, N8 n)
            where T : unmanaged
                => random.Next<ushort>();

        /// <summary>
        /// Creates an 8x2 16-bit natural bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid16<N8,N12,T> BitGrid<T>(this ISource random, N8 m, N2 n)
            where T : unmanaged
                => random.Next<ushort>();

        /// <summary>
        /// Creates a 4x4 16-bit natural bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid16<N4,N4,T> BitGrid<T>(this ISource random, N4 m, N4 n)
            where T : unmanaged
                => random.Next<ushort>();

        /// <summary>
        /// Creates a 1x32 32-bit natural bitgrid
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid32<N1,N32,T> BitGrid<T>(this ISource random, N1 m, N32 n)
            where T : unmanaged
                => random.Next<uint>();

        /// <summary>
        /// Creates a 32-bit natural bitgrid of dimension 32x1
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid32<N32,N1,T> BitGrid<T>(this ISource random, N32 m, N1 n, T t = default)
            where T : unmanaged
                => random.Next<uint>();

        /// <summary>
        /// Creates a 32-bit natural bitgrid of dimension 2x16
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid32<N2,N16,T> BitGrid<T>(this ISource random, N2 m, N16 n, T t = default)
            where T : unmanaged
                => random.Next<uint>();

        /// <summary>
        /// Creates a 32-bit natural bitgrid of dimension 16x2
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid32<N16,N2,T> BitGrid<T>(this ISource random, N16 m, N2 n, T t = default)
            where T : unmanaged
                => random.Next<uint>();

        /// <summary>
        /// Creates a natural 32-bit grid of dimension 8x4
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid32<N8,N4,T> BitGrid<T>(this ISource random, N8 m, N4 n, T t = default)
            where T : unmanaged
                => random.Next<uint>();

        /// <summary>
        /// Creates a natural 32-bit grid of dimension 4x8
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid32<N4,N8,T> BitGrid<T>(this ISource random, N4 m, N8 n, T t = default)
            where T : unmanaged
                => random.Next<uint>();

        /// <summary>
        /// Creates a natural 64-bit grid of dimension 1x64
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid64<N1,N64,T> BitGrid<T>(this ISource random, N1 m, N64 n, T t = default)
            where T : unmanaged
                => random.Next<ulong>();

        /// <summary>
        /// Creates a natural 64-bit grid of dimension 64x1
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid64<N64,N1,T> BitGrid<T>(this ISource random, N64 m, N1 n, T t = default)
            where T : unmanaged
                => random.Next<ulong>();

        /// <summary>
        /// Creates a natural 64-bit grid of dimension 32x2
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid64<N32,N2,T> BitGrid<T>(this ISource random, N32 m, N2 n, T t = default)
            where T : unmanaged
                => random.Next<ulong>();

        /// <summary>
        /// Creates a natural 64-bit grid of dimension 2x32
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid64<N2,N32,T> BitGrid<T>(this ISource random, N2 m, N32 n, T t = default)
            where T : unmanaged
                => random.Next<ulong>();

        /// <summary>
        /// Creates a natural 64-bit grid of dimension 16x4
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid64<N16,N4,T> BitGrid<T>(this ISource random, N16 m, N4 n, T t = default)
            where T : unmanaged
                => random.Next<ulong>();

        /// <summary>
        /// Creates a natural 64-bit grid of dimension 4x16
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid64<N4,N16,T> BitGrid<T>(this ISource random, N4 m, N16 n, T t = default)
            where T : unmanaged
                => random.Next<ulong>();

        /// <summary>
        /// Creates a 64-bit natural bitgrid of dimension 8x8 over generic cells
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid64<N8,N8,T> BitGrid<T>(this ISource random, N8 m, N8 n, T t = default)
            where T : unmanaged
                => random.Next<ulong>();

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 1x128
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N1,N128,T> BitGrid<T>(this ISource random, N1 m, N128 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 128x1
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N128,N1,T> BitGrid<T>(this ISource random, N128 m, N1 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 2x64
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N2,N64,T> BitGrid<T>(this ISource random, N2 m, N64 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 64x2
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N64,N2,T> BitGrid<T>(this ISource random, N64 m, N2 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 4x32
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N4,N32,T> BitGrid<T>(this ISource random, N4 m, N32 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 32x4
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N32,N4,T> BitGrid<T>(this ISource random, N32 m, N4 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 8x16
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N8,N16,T> BitGrid<T>(this ISource random, N8 m, N16 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 128-bit natural bitgrid of dimension 16x8
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid128<N16,N8,T> BitGrid<T>(this ISource random, N16 m, N8 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n128);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 1x256
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N1,N256,T> BitGrid<T>(this ISource random, N1 m, N256 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 256x1
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N256,N1,T> BitGrid<T>(this ISource random, N256 m, N1 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 2x128
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N2,N128,T> BitGrid<T>(this ISource random, N2 m, N128 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 128x2
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N128,N2,T> BitGrid<T>(this ISource random, N128 m, N2 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 4x64
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N4,N64,T> BitGrid<T>(this ISource random, N4 m, N64 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 64x4
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N64,N4,T> BitGrid<T>(this ISource random, N64 m, N4 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 8x32
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N8,N32,T> BitGrid<T>(this ISource random, N8 m, N32 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 32x8
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N32,N8,T> BitGrid<T>(this ISource random, N32 m, N8 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Creates a 256-bit natural bitgrid of dimension 16x16
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        [MethodImpl(Inline)]
        public static BitGrid256<N16,N16,T> BitGrid<T>(this ISource random, N16 m, N16 n, T t = default)
            where T : unmanaged
                => random.CpuVector<T>(n256);

        /// <summary>
        /// Allocates and fills a generic bitgrid from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The grid row count</param>
        /// <param name="n">The grid col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitSpanBlocks256<T> BitGrid<T>(this ISource random, uint m, uint n, T t = default)
            where T : unmanaged
                => random.Fill(Z0.BitGrid.alloc<T>((int)m,(int)n));

        /// <summary>
        /// Fills a caller-supplied generic bitgrid from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The grid row count</param>
        /// <param name="n">The grid col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitSpanBlocks256<T> Fill<T>(this ISource random, in BitSpanBlocks256<T> dst)
            where T : unmanaged
        {
            random.Fill(dst.CellCount, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Produces a stream of bit positions
        /// </summary>
        /// <param name="mincells">The minimum number of cells</param>
        /// <param name="maxcells">The maximum number of cells</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static IEnumerable<BitPos<T>> BitPositions<T>(this IBoundSource random, ushort mincells, ushort maxcells)
            where T : unmanaged
        {
            var s2 = random.Stream(Intervals.closed(mincells, maxcells)).GetEnumerator();
            var s3 = random.Stream<byte>(Intervals.closed((byte)0, (byte)width<T>())).GetEnumerator();
            while(true && s2.MoveNext() && s3.MoveNext())
                yield return BitPos.bitpos<T>(s2.Current, s3.Current);
        }

        /// <summary>
        /// Produces a stream of bit positions
        /// </summary>
        /// <param name="capacity">The cell bit width</param>
        /// <param name="mincells">The minimum number of cells</param>
        /// <param name="maxcells">The maximum number of cells</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static IEnumerable<BitPos> BitPositions(this IBoundSource random, byte capacity, ushort mincells, ushort maxcells)
        {
            var s2 = random.Stream(Intervals.closed(mincells,maxcells)).GetEnumerator();
            var s3 = random.Stream<byte>(Intervals.closed((byte)0, capacity)).GetEnumerator();
            while(true && s2.MoveNext() && s3.MoveNext())
                yield return BitPos.bitpos(capacity, s2.Current, s3.Current);
        }

        /// <summary>
        /// Produces a natural bitblock
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The number of bits to cover</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<N,T> BitBlock<N,T>(this ISource random)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BS.load<N,T>(random.Stream<T>().ToSpan((int)grids.gridcells<N,N1,T>()));

        /// <summary>
        /// Produces a bitblock over a specified number of bits
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="bitcount">The number of bits to cover</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<T> BitBlock<T>(this ISource random, int bitcount)
            where T : unmanaged
                => BS.load<T>(random.Stream<T>().ToSpan(BS.cells<T>(bitcount)), bitcount);

        /// <summary>
        /// Produces a bitblock over a specified number of bits
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="bitcount">The number of bits to cover</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<T> BitBlock<T>(this ISource random, uint bitcount)
            where T : unmanaged
                => BS.load<T>(random.Stream<T>().ToSpan(BS.cells<T>((int)bitcount)), (int)bitcount);

        /// <summary>
        /// Produces a generic bitmatrix predicated on a primal type
        /// </summary>
        /// <param name="random">The random source</param>
        /// <typeparam name="T">The defining primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<T> BitMatrix<T>(this ISource random)
            where T : unmanaged
        {
            var bytes = math.square(Z0.BitMatrix<T>.N) >> 3;
            var data = random.Span<byte>((int)bytes);
            return BM.load(data.Recover<byte,T>());
        }

        [MethodImpl(Inline)]
        public static ref BitMatrix<T> BitMatrix<T>(this ISource random, ref BitMatrix<T> dst)
            where T : unmanaged
        {
            random.Fill((int)Z0.BitMatrix<T>.N, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Produces a 4x4 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix4 BitMatrix4(this ISource random)
            => BM.primal(n4,random.Next<ushort>());

        /// <summary>
        /// Produces a 4x4 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix4 BitMatrix(this ISource random, N4 n)
            => BM.primal(n,random.Next<ushort>());

        /// <summary>
        /// Produces a 8x8 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix8 BitMatrix8(this ISource random)
            => BM.primal(n8,random.Next<ulong>());

        /// <summary>
        /// Produces a 8x8 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix8 BitMatrix(this ISource random, N8 n)
            => BM.primal(n, random.Next<ulong>());

        /// <summary>
        /// Produces a 16x16 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix16 BitMatrix16(this ISource random)
            => BM.primal(n16,random.Array<ushort>(16));

        /// <summary>
        /// Produces a 16x16 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix16 BitMatrix(this ISource random, N16 n)
            => BM.primal(n,random.Array<ushort>(16));

        /// <summary>
        /// Produces a 32x32 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix32 BitMatrix32(this ISource random)
            => BM.primal(n32, random.Array<uint>(32));

        /// <summary>
        /// Produces a 32x32 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix32 BitMatrix(this ISource random, N32 n)
            => BM.primal(n,random.Array<uint>(32));

        /// <summary>
        /// Produces a 64x64 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix64 BitMatrix64(this ISource random)
            => BM.primal(n64,random.Array<ulong>(64));

        /// <summary>
        /// Produces a 64x64 bitmatrix from a random source
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        public static BitMatrix64 BitMatrix(this ISource random, N64 n)
            => BM.primal(n, random.Array<ulong>(64));

        /// <summary>
        /// Produces a generic bitmatrix of natural dimensions
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The matrix order</param>
        /// <param name="rep">A scalar representative</param>
        /// <typeparam name="N">The order type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<M,N,T> BitMatrix<M,N,T>(this ISource random, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BM.load(m,n, random.Span<T>(BM.cellcount(m,n,t)));

        /// <summary>
        /// Produces an generic bitmatrix of natural order
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The matrix order</param>
        /// <typeparam name="N">The order type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<N,T> BitMatrix<N,T>(this ISource random, N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BM.load(n,random.Span<T>(BM.cellcount(n,n,t)));
   }
}