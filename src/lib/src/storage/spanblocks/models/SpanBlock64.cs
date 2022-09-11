//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a span of contiguous memory that can be evenly partitioned into 8, 16, 32 and 64-bit segments
    /// </summary>
    [SpanBlock(NativeTypeWidth.W64, SpanBlockKind.Sb64)]
    public readonly ref struct SpanBlock64<T>
        where T : unmanaged
    {
        static uint CellWidth => width<T>();

        readonly Span<T> Data;

        [MethodImpl(Inline)]
        public SpanBlock64(Span<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        public SpanBlock64(params T[] src)
            => Data = src;

        [MethodImpl(Inline)]
        public SpanBlock64<T> Slice(uint block)
            => new SpanBlock64<T>(slice(Data, block * (uint)BlockLength));

        [MethodImpl(Inline)]
        public SpanBlock64<T> Slice(uint start, uint blocks)
            => new SpanBlock64<T>(slice(Data, start * (uint)BlockLength,  blocks*(uint)BlockLength));

        [MethodImpl(Inline)]
        public T Bits(uint block, uint cell, byte offset, byte width)
            => gbits.slice(this[block, cell], offset, width);

        /// <summary>
        /// The unblocked storage cells
        /// </summary>
        public Span<T> Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// The leading storage cell
        /// </summary>
        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        /// <summary>
        /// The number of allocated cells
        /// </summary>
        public int CellCount
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        /// <summary>
        /// The number of cells in a block
        /// </summary>
        public int BlockLength
        {
            [MethodImpl(Inline)]
            get => 8/(int)size<T>();
        }

        /// <summary>
        /// The number of covered blocks
        /// </summary>
        public int BlockCount
        {
            [MethodImpl(Inline)]
            get => CellCount/BlockLength;
        }

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public BitWidth BitCount
        {
            [MethodImpl(Inline)]
            get => CellCount * width<T>();
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => CellCount * size<T>();
        }

        /// <summary>
        /// Mediates access to the underlying storage cells via linear index
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref add(First, index);
        }

        /// <summary>
        /// Mediates access to the the underlying storage cells via block index and block-relative cell index
        /// </summary>
        public ref T this[int block, int cell]
        {
            [MethodImpl(Inline)]
            get => ref Cell(block, cell);
        }

        /// <summary>
        /// Mediates access to the the underlying storage cells via block index and block-relative cell index
        /// </summary>
        /// <param name="block">The block index</param>
        /// <param name="cell">The block-relative cell index</param>
        [MethodImpl(Inline)]
        public ref T Cell(int block, int cell)
            => ref add(First, BlockLength*block + cell);

        /// <summary>
        /// Produces a span that covers the cells of an index-identified block
        /// </summary>
        /// <param name="block">The block index</param>
        [MethodImpl(Inline)]
        public Span<T> CellBlock(int block)
            => slice(Data, block * BlockLength, BlockLength);

        /// <summary>
        /// Specifies a linear index-identified cell
        /// </summary>
        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First, index);
        }

        /// <summary>
        /// Specifies a cell identified by a block index and a block-relative cell index
        /// </summary>
        public ref T this[uint block, uint cell]
        {
            [MethodImpl(Inline)]
            get => ref Cell(block, cell);
        }

        /// <summary>
        /// Specifies a linear index-identified cell
        /// </summary>
        /// <param name="block">The block index</param>
        /// <param name="cell">The block-relative cell index</param>
        [MethodImpl(Inline)]
        public ref T Cell(uint index)
            => ref seek(First, index);

        /// <summary>
        /// Specifies a cell identified by a block index and a block-relative cell index
        /// </summary>
        /// <param name="block">The block index</param>
        /// <param name="cell">The block-relative cell index</param>
        [MethodImpl(Inline)]
        public ref T Cell(uint block, uint cell)
            => ref seek(First, BlockLength*block + cell);

        /// <summary>
        /// Retrieves an index-identified block consisting of a single cell
        /// </summary>
        /// <param name="block">The block index</param>
        [MethodImpl(Inline)]
        public SpanBlock64<T> Block(uint block)
            => new SpanBlock64<T>(slice(Data, block*BlockLength,BlockLength));

        /// <summary>
        /// Specifies the first cell of an index-identified block
        /// </summary>
        /// <param name="block">The block index</param>
        [MethodImpl(Inline)]
        public ref T BlockCell(uint block)
            => ref seek(First, block*BlockLength);

        /// <summary>
        /// Presents the source data as bytespan
        /// </summary>
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

        [MethodImpl(Inline)]
        public ref T BlockLead(int block)
            => ref add(First, block*BlockLength);

        [MethodImpl(Inline)]
        public ref T BlockCell(int block)
            => ref seek(First, block*BlockLength);

        /// <summary>
        /// Broadcasts a value to all blocked cells
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public void Fill(T src)
            => Data.Fill(src);

        /// <summary>
        /// Zero-fills all blocked cells
        /// </summary>
        [MethodImpl(Inline)]
        public void Clear()
            => Storage.Clear();

        /// <summary>
        /// Copies blocked content to a target span
        /// </summary>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline)]
        public void CopyTo(Span<T> dst)
            => Data.CopyTo(dst);

        /// <summary>
        /// Presents the source blocks as <typeparamref name='S'/> blocks
        /// </summary>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock64<S> Cover<S>()
            where S : unmanaged
                => As<S>();

        /// <summary>
        /// Presents 64-bit blocks as 8-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock8<S> Recover<S>(W8 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 64-bit blocks as 32-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock16<S> Recover<S>(W16 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 64-bit blocks as 64-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock32<S> Recover<S>(W32 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 64-bit blocks as 128-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock128<S> Recover<S>(W128 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 64-bit blocks as 8-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock256<S> Recover<S>(W256 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 64-bit blocks as 512-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock512<S> Recover<S>(W512 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Reinterprets the storage cell type
        /// </summary>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock64<S> As<S>()
            where S : unmanaged
                => new SpanBlock64<S>(recover<T,S>(Data));

        [MethodImpl(Inline)]
        public Span<T>.Enumerator GetEnumerator()
            => Data.GetEnumerator();

        [MethodImpl(Inline)]
        public ref T GetPinnableReference()
            => ref Data.GetPinnableReference();

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(in SpanBlock64<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(in SpanBlock64<T> src)
            => src.Data;
   }
}