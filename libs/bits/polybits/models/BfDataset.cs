//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = PolyBits;

    public class BfDataset : IBfDataset
    {
        /// <summary>
        /// Creates a bitfield render pattern predicated on a sequence of segment widths
        /// </summary>
        /// <param name="widths"></param>
        [Op]
        public static string pattern(Index<byte> widths, char sep = Chars.Space)
        {
            var dst = text.buffer();
            var count = widths.Count;
            for(var i=0u; i<count; i++)
            {
                var slot = RpOps.slot(i, math.negate((sbyte)widths[i]));
                dst.Append(slot);
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        /// <summary>
        /// Creates a bitfield render pattern predicated a dataset definition
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="F"></typeparam>
        /// <typeparam name="T"></typeparam>
        public static string pattern<F,T>(BfDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var dst = text.buffer();
            var fields = src.Fields;
            for(var i=0u; i<src.FieldCount; i++)
            {
                ref readonly var field = ref src.Fields[i];
                ref readonly var w = ref src.Width(field);
                var slot = RpOps.slot(i, math.negate((sbyte)w));
                dst.Append(slot);
                if(i != src.FieldCount - 1)
                    dst.Append(Chars.Space);
            }
            return dst.Emit();
        }

        public readonly asci64 Name;

        public readonly DataSize Size;

        public readonly uint FieldCount;

        readonly Index<Char5Seq> _Fields;

        readonly Dictionary<Char5Seq,uint> _Indices;

        readonly Index<uint> _Offsets;

        readonly Index<byte> _Widths;

        readonly BfIntervals _Intervals;

        readonly Index<BitMask> _Masks;

        public readonly string BitstringPattern;

        public BfDataset(asci64 name, NativeSize size, Index<Char5Seq> fields, Dictionary<Char5Seq,uint> indices, Index<byte> widths)
        {
            Name = name;
            _Fields = fields;
            FieldCount = widths.Count;
            _Indices = indices;
            _Widths = widths;
            _Offsets = api.offsets(widths);
            _Intervals = PolyBits.intervals(_Offsets, widths);
            Size = new (_Intervals.Width, size.Width);
            _Masks = api.masks(this);
            BitstringPattern = pattern(widths, Chars.Space);
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

        public ref readonly BfIntervals Intervals
        {
            [MethodImpl(Inline)]
            get => ref _Intervals;
        }

        public ref readonly Index<Char5Seq> Fields
        {
            [MethodImpl(Inline)]
            get => ref _Fields;
        }

        public ref readonly Index<BitMask> Masks
        {
            [MethodImpl(Inline)]
            get => ref _Masks;
        }

        uint IBfDataset.FieldCount
            => FieldCount;

        string IBfDataset.BitstringPattern
            => BitstringPattern;

        asci64 IBfDataset.Name
            => Name;

        DataSize IBfDataset.Size
            => Size;

        [MethodImpl(Inline)]
        public uint Index(Char5Seq field)
            => _Indices[field];

        [MethodImpl(Inline)]
        public ref readonly byte Width(int index)
            => ref Widths[index];

        [MethodImpl(Inline)]
        public ref readonly byte Width(uint index)
            => ref Widths[index];

        [MethodImpl(Inline)]
        public ref readonly uint Offset(int index)
            => ref Offsets[index];

        [MethodImpl(Inline)]
        public ref readonly uint Offset(uint index)
            => ref Offsets[index];

        [MethodImpl(Inline)]
        public ref readonly BitMask Mask(int index)
            => ref Masks[index];

        [MethodImpl(Inline)]
        public ref readonly BitMask Mask(uint index)
            => ref Masks[index];

        [MethodImpl(Inline)]
        public ref readonly BfInterval Interval(int index)
            => ref Intervals[index];

        [MethodImpl(Inline)]
        public ref readonly BfInterval Interval(uint index)
            => ref Intervals[index];

        [MethodImpl(Inline)]
        public T Extract<T>(uint index, T src)
            where T : unmanaged
                => api.extract(Offset(index), Width(index), src);
    }
}