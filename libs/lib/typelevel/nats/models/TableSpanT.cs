//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct TableSpan<T> : IIndex<T>
        where T : struct
    {
        public static TableSpan<T> Empty
            => new TableSpan<T>(new T[0]{});

        readonly T[] Data;

        [MethodImpl(Inline)]
        public static implicit operator TableSpan<T>(T[] src)
            => new TableSpan<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](TableSpan<T> src)
            => src.Storage;

        [MethodImpl(Inline)]
        public TableSpan(T[] src)
            => Data = src;

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

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

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data[0];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public ref T this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref T this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public void Iter(Action<T> f)
        {
            var count = Count;
            ref readonly var src = ref first(View);
            for(var i=0; i<count; i++)
                f(skip(src,i));
        }

        // public string Format()
        //     => Seq.delimit(Chars.Comma, 0, View).Format();

        // public override string ToString()
        //     => Format();
    }
}