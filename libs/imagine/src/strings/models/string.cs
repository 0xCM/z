//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using T = @string;

    public readonly struct @string : IString<@string,char>, IDataType<@string>
    {
        readonly string Data;

        public @string()
        {
            Data = EmptyString;
        }

        [MethodImpl(Inline)]
        public @string(string src)
        {
            Data = src ?? EmptyString;
        }

        public string Value
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public BitWidth BitWidth
        {
            [MethodImpl(Inline)]
            get => Length*2*8;
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Length*2;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Data);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Data);
        }

        public ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Cells);
        }

        public string Format()
            => Value;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(T src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is T x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator T(string src)
            => new T(src);

        [MethodImpl(Inline)]
        public static implicit operator string(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(T src)
            => src.Cells;

        public static bool operator ==(T a, T b)
            => a.Equals(b);

        public static bool operator !=(T a, T b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator <(T a, T b)
            => a.CompareTo(b) < 0;

        [MethodImpl(Inline)]
        public static bool operator >(T a, T b)
            => a.CompareTo(b) > 0;

        [MethodImpl(Inline)]
        public static bool operator <=(T a, T b)
            => a.CompareTo(b) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >=(T a, T b)
            => a.CompareTo(b) >= 0;

        [MethodImpl(Inline)]
        public static T operator +(T a, T b)
            => new T(a.Value + b.Value);

        public static T Empty => new();
    }
}