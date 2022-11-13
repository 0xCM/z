//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ReflectedFields : IIndex<ReflectedField>
    {
        readonly Index<ReflectedField> Data;

        [MethodImpl(Inline)]
        public ReflectedFields(ReflectedField[] src)
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

        public ref ReflectedField this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ReflectedField this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ReadOnlySpan<ReflectedField> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ReflectedField> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReflectedField[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public string FormatFieldValue<T>(int index, T value)
            => Data[index].Format(value);

        [MethodImpl(Inline)]
        public static implicit operator ReflectedFields(ReflectedField[] src)
            => new ReflectedFields(src);

        public static ReflectedFields Empty
            => new ReflectedFields(sys.empty<ReflectedField>());
    }
}