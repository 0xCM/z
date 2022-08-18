//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrFieldValues
    {
        readonly ClrFieldValue[] Data;

        [MethodImpl(Inline)]
        public ClrFieldValues(params ClrFieldValue[] src)
            => Data = src;

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public ReadOnlySpan<ClrFieldValue> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref ClrFieldValue this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ClrFieldValue this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrFieldValues(ClrFieldValue[] src)
            => new ClrFieldValues(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrFieldValue[](ClrFieldValues src)
            => src.Data;
    }
}