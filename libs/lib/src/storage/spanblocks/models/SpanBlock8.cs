//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a span of contiguous memory that can be evenly partitioned into 8-bit segments
    /// </summary>
    [SpanBlock(NativeTypeWidth.W8, SpanBlockKind.Sb8), DataTypeAttributeD("spanblock<w:8,t:{0}>")]
    public readonly ref struct SpanBlock8<T>
        where T : unmanaged
    {
        readonly Span<T> Data;

        [MethodImpl(Inline)]
        public SpanBlock8(Span<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        public SpanBlock8(params T[] src)
            => Data = src;

        /// <summary>
        /// The backing storage
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
            get => (int)size<T>();
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
        public ref T this[int block, int segment]
        {
            [MethodImpl(Inline)]
            get => ref Cell(block, segment);
        }

        /// <summary>
        /// Mediates access to the the underlying storage cells via block index and block-relative cell index
        /// </summary>
        /// <param name="block">The block index</param>
        /// <param name="segment">The cell relative block index</param>
        [MethodImpl(Inline)]
        public ref T Cell(int block, int segment)
            => ref add(First, BlockLength*block + segment);

        /// <summary>
        /// Retrieves an index-identified data block
        /// </summary>
        /// <param name="block">The block index</param>
        [MethodImpl(Inline)]
        public Span<T> CellBlock(int block)
            => slice(Data,block * BlockLength, BlockLength);

        /// <summary>
        /// Mediates access to the underlying storage cells via linear index
        /// </summary>
        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        /// <summary>
        /// Mediates access to the the underlying storage cells via block index and block-relative cell index
        /// </summary>
        public ref T this[uint block, uint cell]
        {
            [MethodImpl(Inline)]
            get => ref Cell(block, cell);
        }

        /// <summary>
        /// Mediates access to the the underlying storage cells via block index and block-relative cell index
        /// </summary>
        /// <param name="block">The block index</param>
        /// <param name="index">The cell relative block index</param>
        [MethodImpl(Inline)]
        public ref T Cell(uint block, uint index)
            => ref add(First, BlockLength*block + index);

        /// <summary>
        /// Presents the source data as bytespan
        /// </summary>
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

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
            => Data.Clear();

        /// <summary>
        /// Copies blocked content to a target span
        /// </summary>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline)]
        public void CopyTo(Span<T> dst)
            => Data.CopyTo(dst);

        /// <summary>
        /// Reinterprets the storage cell type
        /// </summary>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock8<S> Cover<S>()
            where S : unmanaged
                => As<S>();

        /// <summary>
        /// Presents 8-bit blocks as 16-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock16<S> Recover<S>(W16 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 8-bit blocks as 32-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock32<S> Recover<S>(W32 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 8-bit blocks as 64-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock64<S> Recover<S>(W64 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 8-bit blocks as 128-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock128<S> Recover<S>(W128 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 8-bit blocks as 8-bit <typeparamref name='S'/> blocks
        /// </summary>
        /// <param name="w">The target width</param>
        /// <typeparam name="S">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public SpanBlock256<S> Recover<S>(W256 w)
            where S : unmanaged
                => Cover<S>().Reblock(w);

        /// <summary>
        /// Presents 8-bit blocks as 512-bit <typeparamref name='S'/> blocks
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
        public SpanBlock8<S> As<S>()
            where S : unmanaged
                => new SpanBlock8<S>(recover<T,S>(Data));

        [MethodImpl(Inline)]
        public Span<T>.Enumerator GetEnumerator()
            => Data.GetEnumerator();

        [MethodImpl(Inline)]
        public ref T GetPinnableReference()
            => ref Data.GetPinnableReference();

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(in SpanBlock8<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(in SpanBlock8<T> src)
            => src.Data;
   }
}