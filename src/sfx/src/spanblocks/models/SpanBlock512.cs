//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// Defines a span of contiguous memory that can be evenly partitioned into 8, 16, 32, 64, 128, 256 and 512-bit segments
/// </summary>
[SpanBlock(NativeTypeWidth.W512, SpanBlockKind.Sb512)]
public readonly ref struct SpanBlock512<T>
    where T : unmanaged
{
    readonly Span<T> Data;

    [MethodImpl(Inline)]
    public SpanBlock512(Span<T> src)
        => Data = src;

    [MethodImpl(Inline)]
    public SpanBlock512(params T[] src)
        => Data = src;

    [MethodImpl(Inline)]
    public SpanBlock512<T> Slice(uint block)
        => new SpanBlock512<T>(slice(Data, block * (uint)BlockLength));

    [MethodImpl(Inline)]
    public SpanBlock512<T> Slice(uint start, uint blocks)
        => new SpanBlock512<T>(slice(Data, start * (uint)BlockLength,  blocks*(uint)BlockLength));

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

    /// <summary>
    /// True if no capacity exists, false otherwise
    /// </summary>
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
        get => (int)(64/size<T>());
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
    /// Mediates access to the underlying storage cells via linear index
    /// </summary>
    public ref T this[uint index]
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
    /// Presents the source data as bytespan
    /// </summary>
    public Span<byte> Bytes
    {
        [MethodImpl(Inline)]
        get => bytes(Data);
    }

    /// <summary>
    /// Mediates access to the the underlying storage cells via block index and block-relative cell index
    /// </summary>
    /// <param name="block">The block index</param>
    /// <param name="segment">The cell relative block index</param>
    [MethodImpl(Inline)]
    public ref T Cell(int block, int segment)
        => ref add(First, BlockLength*block + segment);

    [MethodImpl(Inline)]
    public Span<T> CellBlock(int block)
        => Block(block);

    /// <summary>
    /// Retrieves an index-identified data block
    /// </summary>
    /// <param name="block">The block index</param>
    [MethodImpl(Inline)]
    public Span<T> Block(int block)
        => slice(Data, block * BlockLength, BlockLength);

    /// <summary>
    /// Retrieves an index-identified data block
    /// </summary>
    /// <param name="block">The block index</param>
    [MethodImpl(Inline)]
    public Span<T> Block(uint block)
        => slice(Data, block * BlockLength, BlockLength);

    [MethodImpl(Inline)]
    public ref T BlockLead(int index)
        => ref add(First, index*BlockLength);

    [MethodImpl(Inline)]
    public ref T BlockLead(uint index)
        => ref add(First, index*BlockLength);

    /// <summary>
    /// Retrieves the lower 256 bits of an index-identified block
    /// </summary>
    /// <param name="block">The block-relative index</param>
    [MethodImpl(Inline)]
    public Span<T> LoBlock(int block)
    {
        var count = BlockLength / 2;
        return slice(Data, block*BlockLength, count);
    }

    /// <summary>
    /// Retrieves the upper 256 bits of an index-identified block
    /// </summary>
    /// <param name="block">The block-relative index</param>
    [MethodImpl(Inline)]
    public Span<T> HiBlock(int block)
    {
        var count = BlockLength / 2;
        return slice(Data, block * BlockLength + count, count);
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
        => Storage.Clear();

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
    public SpanBlock512<S> Cover<S>()
        where S : unmanaged
            => As<S>();

    /// <summary>
    /// Presents 512-bit blocks as 16-bit <typeparamref name='S'/> blocks
    /// </summary>
    /// <param name="w">The target width</param>
    /// <typeparam name="S">The target cell type</typeparam>
    [MethodImpl(Inline)]
    public SpanBlock8<S> Recover<S>(W8 w)
        where S : unmanaged
            => Cover<S>().Reblock(w);

    /// <summary>
    /// Presents 512-bit blocks as 16-bit <typeparamref name='S'/> blocks
    /// </summary>
    /// <param name="w">The target width</param>
    /// <typeparam name="S">The target cell type</typeparam>
    [MethodImpl(Inline)]
    public SpanBlock16<S> Recover<S>(W16 w)
        where S : unmanaged
            => Cover<S>().Reblock(w);

    /// <summary>
    /// Presents 512-bit blocks as 32-bit <typeparamref name='S'/> blocks
    /// </summary>
    /// <param name="w">The target width</param>
    /// <typeparam name="S">The target cell type</typeparam>
    [MethodImpl(Inline)]
    public SpanBlock32<S> Recover<S>(W32 w)
        where S : unmanaged
            => Cover<S>().Reblock(w);

    /// <summary>
    /// Presents 512-bit blocks as 64-bit <typeparamref name='S'/> blocks
    /// </summary>
    /// <param name="w">The target width</param>
    /// <typeparam name="S">The target cell type</typeparam>
    [MethodImpl(Inline)]
    public SpanBlock64<S> Recover<S>(W64 w)
        where S : unmanaged
            => Cover<S>().Reblock(w);

    /// <summary>
    /// Presents 512-bit blocks as 128-bit <typeparamref name='S'/> blocks
    /// </summary>
    /// <param name="w">The target width</param>
    /// <typeparam name="S">The target cell type</typeparam>
    [MethodImpl(Inline)]
    public SpanBlock128<S> Recover<S>(W128 w)
        where S : unmanaged
            => Cover<S>().Reblock(w);

    /// <summary>
    /// Presents 512-bit blocks as 8-bit <typeparamref name='S'/> blocks
    /// </summary>
    /// <param name="w">The target width</param>
    /// <typeparam name="S">The target cell type</typeparam>
    [MethodImpl(Inline)]
    public SpanBlock256<S> Recover<S>(W256 w)
        where S : unmanaged
            => Cover<S>().Reblock(w);

    /// <summary>
    /// Reinterprets the storage cell type
    /// </summary>
    /// <typeparam name="S">The target cell type</typeparam>
    [MethodImpl(Inline)]
    public SpanBlock512<S> As<S>()
        where S : unmanaged
            => new SpanBlock512<S>(recover<T,S>(Data));

    [MethodImpl(Inline)]
    public Span<T>.Enumerator GetEnumerator()
        => Data.GetEnumerator();

    [MethodImpl(Inline)]
    public ref T GetPinnableReference()
        => ref Data.GetPinnableReference();

    [MethodImpl(Inline)]
    public static explicit operator Span<T>(in SpanBlock512<T> src)
        => src.Data;

    [MethodImpl(Inline)]
    public static explicit operator ReadOnlySpan<T>(in SpanBlock512<T> src)
        => src.Data;
}
