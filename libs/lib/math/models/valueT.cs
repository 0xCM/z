//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Scalars;
    using static value;

    public struct value<T> : IDataType<value<T>>
        where T : unmanaged
    {
        public T Data;

        [MethodImpl(Inline)]
        public value(T src)
        {
            Data = src;
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => eq(this,Zero);
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => !eq(this,Zero);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => IsZero;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => IsNonZero;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Data);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => sys.bytes(Data);
        }

        [MethodImpl(Inline)]
        public ref S As<S>()
            where S : unmanaged
                => ref @as<S>(Bytes);

        [MethodImpl(Inline)]
        public int CompareTo(value<T> src)
            => cmp(this,src);

        [MethodImpl(Inline)]
        public bool Equals(value<T> src)
            => eq(this,src);

        public override bool Equals(object src)
            => src is value<T> x && Equals(x);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static explicit operator value<T>(ReadOnlySpan<byte> src)
            => from<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Span<byte>(value<T> src)
            => src.Bytes;

        [MethodImpl(Inline)]
        public static explicit operator value<T>(Span<byte> src)
            => from<T>(src);

        [MethodImpl(Inline)]
        public static explicit operator value<T>(byte[] src)
            => from<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator value<T>(T src)
            => new value<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(value<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator byte(value<T> src)
            => uint8(src.Data);

        [MethodImpl(Inline)]
        public static explicit operator ushort(value<T> src)
            => uint16(src.Data);

        [MethodImpl(Inline)]
        public static explicit operator uint(value<T> src)
            => uint32(src.Data);

        [MethodImpl(Inline)]
        public static explicit operator ulong(value<T> src)
            => uint64(src.Data);

        [MethodImpl(Inline)]
        public static explicit operator Vector128<byte>(value<T> src)
            => vector(w128, src);

        [MethodImpl(Inline)]
        public static explicit operator Vector256<byte>(value<T> src)
            => vector(w256, src);

        [MethodImpl(Inline)]
        public static bool operator ==(value<T> a, value<T> b)
            => eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator !=(value<T> a, value<T> b)
            => !eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator >(value<T> a, value<T> b)
            => gt(a,b);

        [MethodImpl(Inline)]
        public static bool operator <(value<T> a, value<T> b)
            => lt(a,b);

        [MethodImpl(Inline)]
        public static bool operator >=(value<T> a, value<T> b)
            => gteq(a,b);

        [MethodImpl(Inline)]
        public static bool operator <=(value<T> a, value<T> b)
            => lteq(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator --(value<T> src)
            => dec(src);

        [MethodImpl(Inline)]
        public static value<T> operator ++(value<T> src)
            => inc(src);

        [MethodImpl(Inline)]
        public static value<T> operator +(value<T> a, value<T> b)
            => add(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator -(value<T> a, value<T> b)
            => add(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator /(value<T> a, value<T> b)
            => div(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator %(value<T> a, value<T> b)
            => mod(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator ~(value<T> src)
            => invert(src);

        [MethodImpl(Inline)]
        public static value<T> operator -(value<T> src)
            => negate(src);

        [MethodImpl(Inline)]
        public static value<T> operator &(value<T> a, value<T> b)
            => and(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator |(value<T> a, value<T> b)
            => or(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator ^(value<T> a, value<T> b)
            => xor(a,b);

        [MethodImpl(Inline)]
        public static value<T> operator >>(value<T> a, int count)
            => srl(a,(byte)count);

        [MethodImpl(Inline)]
        public static value<T> operator <<(value<T> a, int count)
            => sll(a,(byte)count);

        public static value<T> Zero => default;
    }
}