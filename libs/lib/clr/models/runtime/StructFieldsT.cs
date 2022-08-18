//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Covers a sequence of T-valued fields
    /// </summary>
    /// <typeparam name="T">The field value type</param>
    public readonly struct StructFields<T> : IIndex<StructField<T>>
        where T : struct
    {
        readonly StructField<T>[] Data;

        [MethodImpl(Inline)]
        public StructFields(StructField<T>[] src)
            => Data = src;

        public StructField<T>[] Storage
        {
            get => Data;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref readonly StructField<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly StructField<T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public Span<StructField<T>> ToSpan()
            => Data;

        [MethodImpl(Inline)]
        public static implicit operator StructFields<T>(StructField<T>[] src)
            => new StructFields<T>(src);


        [MethodImpl(Inline)]
        public static implicit operator StructField<T>[](StructFields<T> src)
            => src.Data;
    }
}