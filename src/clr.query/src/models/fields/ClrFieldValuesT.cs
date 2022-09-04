//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrFieldValues<T> : IIndex<ClrFieldValue<T>>, ITextual
    {
        readonly Index<ClrFieldValue<T>> Data;

        [MethodImpl(Inline)]
        public ClrFieldValues(ClrFieldValue<T>[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ClrFieldValue<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReadOnlySpan<ClrFieldValue<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ref ClrFieldValue<T> First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref ClrFieldValue<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public string Format()
            => Delimiting.delimit(Chars.Pipe, 0, View).Format();

        [MethodImpl(Inline)]
        public static implicit operator ClrFieldValues<T>(ClrFieldValue<T>[] src)
            => new ClrFieldValues<T>(src);

        public static ClrFieldValues<T> Empty
            => new ClrFieldValues<T>(sys.empty<ClrFieldValue<T>>());
    }
}