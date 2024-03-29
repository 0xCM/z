//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

/// <summary>
/// A grid of natural dimensions M and N such that M*N = W := 16
/// </summary>
/// <remarks>Conforming dimensions include 1x16, 16x1, 2x8, 8x2, and 4x4</remarks>
[StructLayout(LayoutKind.Sequential, Size=ByteCount)]
public struct BitGrid16<M,N,T>
    where M : unmanaged, ITypeNat
    where N : unmanaged, ITypeNat
    where T : unmanaged
{
    /// <summary>
    /// The grid state
    /// </summary>
    internal ushort Data;

    /// <summary>
    /// The number of bytes covered by the grid
    /// </summary>
    public const int ByteCount = 2;

    [MethodImpl(Inline)]
    internal BitGrid16(ushort src)
        => this.Data = src;

    [MethodImpl(Inline)]
    internal BitGrid16(SpanBlock16<T> src)
        => Data = src.As<ushort>().First;

    /// <summary>
    /// The exposed grid state
    /// </summary>
    public ushort Content
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    /// <summary>
    /// The number of allocated cells
    /// </summary>
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
        get => (int)NatCalc.mul<M,N>();
    }

    public Span<T> Cells
    {
        [MethodImpl(Inline), UnscopedRef]
        get => Data.Bytes().Recover<T>();
    }

    /// <summary>
    /// The leading storage cell
    /// </summary>
    public ref T Head
    {
        [MethodImpl(Inline), UnscopedRef]
        get => ref first(Cells);
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
    /// Extracts row contant as a bitvector
    /// </summary>
    public ScalarBits<N,T> this[int index]
    {
        [MethodImpl(Inline)]
        get => BitGrid.row(this,index);
    }

    [MethodImpl(Inline)]
    public BitGrid16<M,N,U> As<U>()
        where U : unmanaged
            => new BitGrid16<M,N,U>(Data);

    [MethodImpl(Inline)]
    public bool Equals(BitGrid16<M,N,T> rhs)
        => Data.Equals(rhs.Data);

    public override bool Equals(object obj)
        => throw new NotSupportedException();

    public override int GetHashCode()
        => throw new NotSupportedException();

    [MethodImpl(Inline)]
    public static implicit operator BitGrid16<M,N,T>(ushort src)
        => new BitGrid16<M,N,T>(src);

    [MethodImpl(Inline)]
    public static implicit operator ushort(BitGrid16<M,N,T> src)
        => src.Data;

    [MethodImpl(Inline)]
    public static implicit operator BitGrid16<M,N,T>(in SpanBlock16<T> src)
        => new BitGrid16<M,N,T>(src);

    [MethodImpl(Inline)]
    public static bool operator ==(BitGrid16<M,N,T> g1, BitGrid16<M,N,T> g2)
        => g1.Equals(g2);

    [MethodImpl(Inline)]
    public static bool operator !=(BitGrid16<M,N,T> g1, BitGrid16<M,N,T> g2)
        => !g1.Equals(g2);
}
