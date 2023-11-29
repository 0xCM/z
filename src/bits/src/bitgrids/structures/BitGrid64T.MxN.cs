//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// A grid of natural dimensions M and N such that M*N = W := 64
/// </summary>
[StructLayout(LayoutKind.Sequential, Size=ByteCount)]
public record struct BitGrid64<M,N,T>
    where M : unmanaged, ITypeNat
    where N : unmanaged, ITypeNat
    where T : unmanaged
{
    /// <summary>
    /// The grid state
    /// </summary>
    internal ulong Data;

    /// <summary>
    /// The number of bytes covered by the grid
    /// </summary>
    public const int ByteCount = 8;

    [MethodImpl(Inline)]
    internal BitGrid64(ulong src)
        => Data = src;

    public ulong Content
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    public Span<T> Cells
    {
        [MethodImpl(Inline), UnscopedRef]
        get => sys.bytes(Data).Recover<T>();
    }

    public ref T Head
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref first(Cells);
    }

    public uint CellCount
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ByteCount/size<T>();
    }

    /// <summary>
    /// The number of covered bits
    /// </summary>
    public Count BitCount
    {
        [MethodImpl(Inline)]
        get => (uint)NatCalc.mul<M,N>();
    }

    /// <summary>
    /// The number of rows in the grid
    /// </summary>
    public int RowCount => nat32i<M>();

    /// <summary>
    /// The number of columns in the grid
    /// </summary>
    public int ColCount => nat32i<N>();

    /// <summary>
    /// Reads/writes an index-identified cell
    /// </summary>
    [MethodImpl(Inline), UnscopedRef]
    public ref T Cell(int index)
        => ref Unsafe.Add(ref Head, index);

    /// <summary>
    /// Extracts row content as a bitvector
    /// </summary>
    public ScalarBits<N,T> this[int index]
    {
        [MethodImpl(Inline)]
        get => BitGrid.row(this,index);
    }

    /// <summary>
    /// Converts the current grid defined over T-cells to a target grid defined over U-cells
    /// </summary>
    /// <typeparam name="U">The target type</typeparam>
    [MethodImpl(Inline)]
    public BitGrid64<M,N,U> As<U>()
        where U : unmanaged
            => new BitGrid64<M,N,U>(Data);

    [MethodImpl(Inline)]
    public bool Equals(BitGrid64<M,N,T> rhs)
        => Data.Equals(rhs.Data);

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => sys.hash(Data);
    }
    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public static implicit operator BitGrid64<M,N,T>(ulong src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator ulong(BitGrid64<M,N,T> src)
        => src.Data;

    [MethodImpl(Inline)]
    public static implicit operator BitGrid64<T>(BitGrid64<M,N,T> src)
        => new (src.Data);

    [MethodImpl(Inline)]
    public static implicit operator BitGrid64<M,N,T>(BitGrid64<T> src)
        => new (src);
}
