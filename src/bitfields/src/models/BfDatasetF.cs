//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = PolyBits;

    public class BfDataset<F> : IBfDataset<F>
        where F : unmanaged, Enum
    {
        public readonly asci64 Name;

        public readonly DataSize Size;

        public readonly uint FieldCount;

        readonly Index<F> _Fields;

        readonly Index<uint> _Offsets;

        readonly Index<byte> _Widths;

        readonly Dictionary<F,uint> _Indices;

        readonly BfIntervals<F> _Int;

        public readonly string BitstringPattern;

        readonly Index<BitMask> _Masks;

        readonly BfIntervals _UTInt;

        public BfDataset(asci64 name, NativeSize size, F[] fields, Dictionary<F,uint> indices, byte[] widths)
        {
            FieldCount = (uint)Require.equal(fields.Length, widths.Length);
            Name = name;
            _Fields = fields;
            _Indices = indices;
            _Widths = widths;
            _Offsets = api.offsets(widths);
            _Int = api.intervals(this);
            Size = new (_Int.Width, size.Width);
            _Masks = api.masks(this);
            BitstringPattern = BfDataset.pattern(widths, Chars.Space);
            _UTInt = _Int.Untype();
        }

        public ref readonly BfIntervals<F> Intervals
        {
            [MethodImpl(Inline)]
            get => ref _Int;
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

        public ref readonly Index<BitMask> Masks
        {
            [MethodImpl(Inline)]
            get => ref _Masks;
        }

        [MethodImpl(Inline)]
        public uint Index(F field)
            => _Indices[field];

        [MethodImpl(Inline)]
        public ref readonly F Field(byte index)
            => ref Fields[index];

        [MethodImpl(Inline)]
        public ref readonly byte Width(F field)
            => ref _Widths[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly uint Offset(F field)
            => ref _Offsets[Index(field)];

        [MethodImpl(Inline)]
        public ref readonly BfInterval<F> Interval(F field)
            => ref Intervals[Index(field)];

        [MethodImpl(Inline)]
        public T Extract<T>(F field, T src)
            where T : unmanaged
                => api.extract(Offset(field), Width(field), src);

        [MethodImpl(Inline)]
        public T Extract<S,T>(F field, S src)
            where T : unmanaged
            where S : unmanaged
                => api.extract<F,S,T>(this, field, src);
    }
}