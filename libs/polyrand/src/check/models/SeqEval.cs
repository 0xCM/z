//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   using static core;

    public readonly struct SeqEval
    {
        public static SeqEval<T> alloc<T>(uint count, bit result)
            => new SeqEval<T>(new BinaryEval<T>[count], result);
    }

    public struct SeqEval<T> : ISeqEval<SeqEval<T>,BinaryEval<T>>
    {
        readonly BinaryEval<T>[] Data;

        public bit Result;

        [MethodImpl(Inline)]
        internal SeqEval(BinaryEval<T>[] src, bit result)
        {
            Result = result;
            Data = src;
        }

        public ref BinaryEval<T> First
        {
            [MethodImpl(Inline)]
            get => ref first(span(Data));
        }

        public ref BinaryEval<T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First, index);
        }

        public ref BinaryEval<T> this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First, (ulong)index);
        }

        public ReadOnlySpan<BinaryEval<T>> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<BinaryEval<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public BinaryEval<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        bit IEval.Result
            => Result;

        [MethodImpl(Inline)]
        public static bool operator true(SeqEval<T> src)
            => src.Result;

        [MethodImpl(Inline)]
        public static bool operator false(SeqEval<T> src)
            => !src.Result;
    }
}