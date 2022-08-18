//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrTableFields : IIndex<ClrTableField>
    {
        readonly Index<ClrTableField> Data;

        [MethodImpl(Inline)]
        public ClrTableFields(ClrTableField[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref ClrTableField this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ClrTableField this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ReadOnlySpan<ClrTableField> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ClrTableField> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ClrTableField[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public string FormatFieldValue<T>(int index, T value)
            => Data[index].Format(value);

        [MethodImpl(Inline)]
        public static implicit operator ClrTableFields(ClrTableField[] src)
            => new ClrTableFields(src);

        public static ClrTableFields Empty
            => new ClrTableFields(sys.empty<ClrTableField>());
    }
}