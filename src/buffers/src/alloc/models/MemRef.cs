//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public readonly record struct MemRef : IComparable<MemRef>
{
    readonly MemorySegment Seg;

    [MethodImpl(Inline)]
    public MemRef(MemorySegment seg)
    {
        Seg = seg;
    }

    [MethodImpl(Inline)]
    public MemRef(MemoryAddress @base, ByteSize size)
        : this(new (@base,size))
    {

    }

    public MemoryAddress BaseAddress
    {
        [MethodImpl(Inline)]
        get => Seg.BaseAddress;
    }

    public ReadOnlySpan<byte> View
    {
        [MethodImpl(Inline)]
        get => Seg.View;
    }

    public Span<byte> Edit
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
        => View.FormatHex();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public bool Equals(MemRef src)
    {
        var size = src.Size;
        if(size != Size)
            return false;
        var lhs = View;
        var rhs = src.View;
        var result = true;
        for(var i=0; i<size; i++)
            result &= skip(lhs,i) == skip(rhs,i);
        return result;
    }

    [MethodImpl(Inline)]
    public unsafe void* Pointer()
        => BaseAddress.Pointer();

    [MethodImpl(Inline)]
    public unsafe P* Pointer<P>()
        where P : unmanaged
            => BaseAddress.Pointer<P>();

    [MethodImpl(Inline)]
    public unsafe P* Pointer<P>(uint offset)
        where P : unmanaged
            => (BaseAddress + offset).Pointer<P>();

    [MethodImpl(Inline)]
    public unsafe ref R Ref<R>()
        where R : unmanaged
            => ref BaseAddress.Ref<R>();

    [MethodImpl(Inline)]
    public unsafe ref R Ref<R>(uint offset)
        where R : unmanaged
            => ref (BaseAddress + offset).Ref<R>();
    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public int CompareTo(MemRef src)
        => BaseAddress.CompareTo(src.BaseAddress);

    [MethodImpl(Inline)]
    public static implicit operator MemRef(MemorySegment src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator MemRef(MemoryRange src)
        => new (src.Min, src.ByteCount);

    [MethodImpl(Inline)]
    public static implicit operator MemorySegment(MemRef src)
        => src.Seg;

    public static MemRef Empty => default;
}
