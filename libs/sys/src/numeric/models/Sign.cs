//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Sign : IDataType<Sign>
    {
        public readonly SignKind Kind;

        [MethodImpl(Inline)]
        public Sign(SignKind kind)
            => Kind = kind;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (byte)Kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public override int GetHashCode()
            => Hash;
 
        public string Format()
            => Kind switch{
                SignKind.Negative => "-",
                SignKind.Positive => "+",
                _ => EmptyString
            };

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Sign src)
            => Kind == src.Kind;

        [MethodImpl(Inline)]
        public int CompareTo(Sign src)
            => ((byte)Kind).CompareTo((byte)src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Sign(SignKind src)
            => new Sign(src);

        [MethodImpl(Inline)]
        public static implicit operator Sign(sbyte src)
            => new Sign(src < 0 ? SignKind.Negative : (src == 0 ? 0 :SignKind.Positive));

        [MethodImpl(Inline)]
        public static implicit operator Sign(short src)
            => new Sign(src < 0 ? SignKind.Negative : (src == 0 ? 0 :SignKind.Positive));

        [MethodImpl(Inline)]
        public static implicit operator Sign(int src)
            => new Sign(src < 0 ? SignKind.Negative : (src == 0 ? 0 :SignKind.Positive));

        [MethodImpl(Inline)]
        public static implicit operator Sign(long src)
            => new Sign(src < 0 ? SignKind.Negative : (src == 0 ? 0 :SignKind.Positive));

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Sign src)
            => (sbyte)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator short(Sign src)
            => (short)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator int(Sign src)
            => (int)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator long(Sign src)
            => (long)src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator SignKind(Sign src)
            => src.Kind;
    }
}