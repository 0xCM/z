//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Correlates a value with a key that uniquely identifies the value within some context
    /// </summary>
    public readonly struct CorrelationToken : IComparable<CorrelationToken>, IEquatable<CorrelationToken>
    {
        [MethodImpl(Inline)]
        public static CorrelationToken create(ulong src)
            => new CorrelationToken(src);

        ulong Value {get;}

        [MethodImpl(Inline)]
        public CorrelationToken(ulong value)
            => Value = value;

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

        [MethodImpl(Inline)]
        public bool Equals(CorrelationToken src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(CorrelationToken other)
            => Value.CompareTo(other.Value);

        public string Format()
            => Value.FormatHex(zpad:false,uppercase:true);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        public override bool Equals(object src)
            => src is CorrelationToken t && Equals(t);

        [MethodImpl(Inline)]
        public static implicit operator ulong(CorrelationToken src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator CorrelationToken(ulong src)
            => new CorrelationToken(src);

        [MethodImpl(Inline)]
        public static bool operator==(CorrelationToken a, CorrelationToken b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(CorrelationToken a, CorrelationToken b)
            => !a.Equals(b);

        public static CorrelationToken Empty
            => default;
    }
}