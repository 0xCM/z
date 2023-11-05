//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = PolyBits;

public class BfDataset<F,T> : IBfDataset<F>
    where F : unmanaged, Enum
    where T : unmanaged
{
    public readonly uint FieldCount;

    public readonly asci64 Name;

    public readonly DataSize Size;

    readonly Index<F> _Fields;

    readonly Dictionary<F,uint> _Indices;

    readonly Index<uint> _Offsets;

    readonly Index<byte> _Widths;

    readonly BfIntervals<F> _Int;

    readonly Index<BitMask> _Masks;

    public readonly string BitstringPattern;

    readonly BfIntervals _UTInt;

    public BfDataset(asci64 name, NativeSize size, F[] fields, Dictionary<F,uint> indices, byte[] widths)
    {
        Name = name;
        _Fields = fields;
        _Indices = indices;
        _Widths = widths;
        FieldCount = (uint)Require.equal(fields.Length, widths.Length);
        _Offsets = Bitfields.offsets(this);
        _Int = Bitfields.intervals(this);
        Size = new (_Int.Width, size.Width);
        _Masks = Bitfields.masks(this);
        BitstringPattern = BfDataset.pattern(this);
        _UTInt = _Int.Untype();
    }

    public ref readonly Index<F> Fields
    {
        [MethodImpl(Inline)]
        get => ref _Fields;
    }

    public ref readonly Index<uint> Offsets
    {
        [MethodImpl(Inline)]
        get => ref _Offsets;
    }

    public ref readonly Index<byte> Widths
    {
        [MethodImpl(Inline)]
        get => ref _Widths;
    }

    public ref readonly BfIntervals<F> Intervals
    {
        [MethodImpl(Inline)]
        get => ref _Int;
    }

    public ref readonly Index<BitMask> Masks
    {
        [MethodImpl(Inline)]
        get => ref _Masks;
    }

    asci64 IBfDataset.Name
        => Name;

    DataSize IBfDataset.Size
        => Size;

    uint IBfDataset.FieldCount
        => FieldCount;

    string IBfDataset.BitstringPattern
        => BitstringPattern;

    ref readonly BfIntervals IBfDataset.Intervals
        => ref _UTInt;

    [MethodImpl(Inline)]
    public uint Index(F field)
        => _Indices[field];

    [MethodImpl(Inline)]
    public ref readonly F Field(int index)
        => ref Fields[index];

    [MethodImpl(Inline)]
    public ref readonly F Field(uint index)
        => ref Fields[index];

    [MethodImpl(Inline)]
    public ref readonly byte Width(F field)
        => ref Widths[Index(field)];

    [MethodImpl(Inline)]
    public ref readonly uint Offset(F field)
        => ref Offsets[Index(field)];

    [MethodImpl(Inline)]
    public ref readonly BitMask Mask(F field)
        => ref Masks[Index(field)];

    [MethodImpl(Inline)]
    public ref readonly BfInterval<F> Interval(F field)
        => ref Intervals[Index(field)];

    [MethodImpl(Inline)]
    public T Extract(F field, T src)
        => Bitfields.extract(this, field, src);

    [MethodImpl(Inline)]
    public K Extract<K>(F field, T src)
        where K : unmanaged
            => sys.@as<T,K>(Bitfields.extract(this, field, src));
}
