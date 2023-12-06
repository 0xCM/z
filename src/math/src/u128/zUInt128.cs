//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using U = zUInt128;
    using api = zUInt128;

    [ApiHost]
    public partial struct zUInt128 : IEquatable<zUInt128>, IComparable<zUInt128>
    {
        public ulong Lo;

        public ulong Hi;

        [MethodImpl(Inline)]
        public zUInt128(ulong lo, ulong hi)
        {
            Lo = lo;
            Hi = hi;
        }

        [MethodImpl(Inline)]
        public bool Equals(zUInt128 src)
            => api.eq(this,src);

        public int CompareTo(zUInt128 src)
            => api.lt(this,src) ? -1 :(api.eq(this, src) ? 0 : 1);

        public override bool Equals(object src)
            => src is zUInt128 x && Equals(x);

        public override int GetHashCode()
            => sys.hash(Lo,Hi);

        public string Format()
        {
            if(Hi == 0)
            {
                return Lo.FormatHex(zpad:false);
            }
            else
            {
                var a = Lo.FormatHex(zpad:true, specifier:false);
                var b = Hi.FormatHex(zpad:false);
                return b + a;
            }
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static U operator +(U a, U b)
            => api.add(ref a,b);

        [MethodImpl(Inline)]
        public static U operator *(U a, U b)
            => api.mul(ref a,b);

        [MethodImpl(Inline)]
        public static U operator -(U a, U b)
            => api.sub(ref a, b);

        [MethodImpl(Inline)]
        public static bool operator ==(U a, U b)
            => api.eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator !=(U a, U b)
            => !api.eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator >(U a, U b)
            => api.gt(a,b);

        [MethodImpl(Inline)]
        public static bool operator <(U a, U b)
            => api.lt(a,b);

        [MethodImpl(Inline)]
        public static bool operator >=(U a, U b)
            => api.gteq(a,b);

        [MethodImpl(Inline)]
        public static bool operator <=(U a, U b)
            => api.lteq(a,b);

        [MethodImpl(Inline)]
        public static U operator -(U a)
            => api.negate(ref a);

        [MethodImpl(Inline)]
        public static U operator --(U a)
            => api.dec(ref a);

        [MethodImpl(Inline)]
        public static U operator ++(U a)
            => api.inc(ref a);

        [MethodImpl(Inline)]
        public static U operator ~(U a)
            => api.not(a);

        [MethodImpl(Inline)]
        public static U operator &(U a, U b)
            => api.and(a,b);

        [MethodImpl(Inline)]
        public static U operator |(U a, U b)
            => api.or(a,b);

        [MethodImpl(Inline)]
        public static U operator ^(U a, U b)
            => api.xor(a,b);

        [MethodImpl(Inline)]
        public static U operator <<(U a, int shift)
            => api.sll(a,(byte)shift);

        [MethodImpl(Inline)]
        public static U operator >>(U a, int shift)
            => api.srl(a,(byte)shift);

        [MethodImpl(Inline)]
        public static implicit operator U((ulong lo, ulong hi) src)
            => new U(src.lo, src.hi);

        [MethodImpl(Inline)]
        public static implicit operator U(byte src)
            => new U(src, 0);

        [MethodImpl(Inline)]
        public static implicit operator U(ushort src)
            => new U(src, 0);

        [MethodImpl(Inline)]
        public static implicit operator U(uint src)
            => new U(src, 0);

        [MethodImpl(Inline)]
        public static implicit operator U(ulong src)
            => new U(src, 0);

        public static zUInt128 Zero => default;

        public static zUInt128 MaxValue
        {
            [MethodImpl(Inline)]
            get => (ulong.MaxValue,ulong.MaxValue);
        }
    }
}