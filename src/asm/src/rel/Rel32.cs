//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = W32;
    using I = Rel32;

    public readonly record struct Rel32 : IRelOp<uint>, IDataString<Rel32>, IDataType<Rel32>
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public Rel32(uint src)
            => Value = src;

        public NativeSize Size
            => NativeSizeCode.W32;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public string Format()
            => HexFormatter.format(w, Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;
         uint IValued<uint>.Value
            => Value;

        [MethodImpl(Inline)]
        public Address32 ToAddress()
            => Value;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator I(uint src)
            => new I(src);

        public static W w => default;
    }
}