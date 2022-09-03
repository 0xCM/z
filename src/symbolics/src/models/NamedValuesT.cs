//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NamedValues<T>
    {
        public readonly NamedValue<T>[] Data;

        [MethodImpl(Inline)]
        public NamedValues(params NamedValue<T>[] src)
            => Data = src;

        public Count Count
        {
            [MethodImpl(Inline)]
            get => Data?.Length ?? 0;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data?.Length ?? 0;
        }

        public NamedValue<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<NamedValue<T>> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<NamedValue<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator NamedValues<T>(NamedValue<T>[] src)
            => new NamedValues<T>(src);
    }
}