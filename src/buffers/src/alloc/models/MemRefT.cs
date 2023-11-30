//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public readonly record struct MemRef<T> : IComparable<MemRef<T>>
    where T : unmanaged, IEquatable<T>
{
    readonly MemorySegment<T> Seg;

    [MethodImpl(Inline)]
    public MemRef(MemorySegment<T> seg)
    {
        Seg = seg;
    }

    [MethodImpl(Inline)]
    public MemRef(MemorySegment seg)
    {
        Seg = new (seg.BaseAddress, seg.Size);
    }

    [MethodImpl(Inline)]
    public MemRef(MemoryAddress @base, ByteSize size)
    {
        Seg = new (@base, size);
    }

    public MemoryAddress BaseAddress
    {
        [MethodImpl(Inline)]
        get => Seg.BaseAddress;
    }

    public ReadOnlySpan<T> View
    {
        [MethodImpl(Inline)]
        get => Seg.View;
    }

    public Span<T> Edit
    {
        [MethodImpl(Inline)]
        get => Seg.Edit;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => sys.hash(View);
    }

    public byte Size
    {
        [MethodImpl(Inline)]
        get => (byte)Seg.Size;
    }

    public string Format()
        => sys.recover<T,byte>(View).FormatHex();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public bool Equals(MemRef<T> src)
    {
        var size = src.Size;
        if(size != Size)
            return false;

        var lhs = View;
        var rhs = src.View;
        var result = true;
        for(var i=0; i<size; i++)
            result &= skip(lhs,i).Equals(skip(rhs,i));
        return result;
    }

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public int CompareTo(MemRef<T> src)
        => BaseAddress.CompareTo(src.BaseAddress);

    [MethodImpl(Inline)]
    public static implicit operator MemRef<T>(MemRef src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator MemRef(MemRef<T> src)
        => new (src.BaseAddress, src.Size);

    [MethodImpl(Inline)]
    public static implicit operator MemRef<T>(MemorySegment src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator MemRef<T>(MemoryRange src)
        => new (src.Min, src.Size);

    [MethodImpl(Inline)]
    public static implicit operator MemorySegment<T>(MemRef<T> src)
        => src.Seg;

    public static MemRef Empty => default;
}
