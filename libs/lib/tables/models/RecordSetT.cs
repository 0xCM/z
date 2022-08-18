//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RecordSet<T>
        where T : struct
    {
        readonly T[] Data;

        [MethodImpl(Inline)]
        public RecordSet(T[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint RecordCount
        {
            [MethodImpl(Inline)]
            get => Data == null ? 0 : (uint)Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => RecordCount == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => RecordCount != 0;
        }

        public static implicit operator RecordSet<T>(T[] src)
            => new RecordSet<T>(src);

        public static implicit operator T[](RecordSet<T> src)
            => src.Storage;

        public static implicit operator Span<T>(RecordSet<T> src)
            => src.Edit;

        public static implicit operator ReadOnlySpan<T>(RecordSet<T> src)
            => src.View;

        public static implicit operator Index<T>(RecordSet<T> src)
            => src.Storage;

        public static RecordSet<T> Empty
            => new RecordSet<T>(sys.empty<T>());
    }
}