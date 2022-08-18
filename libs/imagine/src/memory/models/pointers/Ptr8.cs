//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using api = memory;

    /// <summary>
    /// Captures a <see cref='byte'/> pointer
    /// </summary>
    [ApiComplete]
    public unsafe struct Ptr8 : IPtr<byte>
    {
        public byte* P;

        [MethodImpl(Inline)]
        public Ptr8(byte* src)
            => P = src;

        public readonly MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P;
        }

        public ref byte this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(P,index);
        }

        public ref byte this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(P,index);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)P;
        }

        [MethodImpl(Inline)]
        public bool Equals(Ptr8 src)
            => P == src.P;

        public override bool Equals(object src)
            => src is Ptr8 p && Equals(p);

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static byte operator !(Ptr8 x)
            => *x.P;

        [MethodImpl(Inline)]
        public static Ptr8 operator ++(Ptr8 x)
            => api.next(x);

        [MethodImpl(Inline)]
        public static Ptr8 operator --(Ptr8 x)
            => api.prior(x);

        [MethodImpl(Inline)]
        public static bool operator <(Ptr8 x, Ptr8 y)
            => x.P < y.P;

        [MethodImpl(Inline)]
        public static bool operator <=(Ptr8 x, Ptr8 y)
            => x.P <= y.P;

        [MethodImpl(Inline)]
        public static bool operator >(Ptr8 x, Ptr8 y)
            => x.P > y.P;

        [MethodImpl(Inline)]
        public static bool operator >=(Ptr8 x, Ptr8 y)
            => x.P >= y.P;

        [MethodImpl(Inline)]
        public static bool operator ==(Ptr8 x, Ptr8 y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(Ptr8 x, Ptr8 y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static implicit operator Ptr<byte>(Ptr8 src)
            => new Ptr<byte>(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Ptr8 src)
            => src.Address;

        [MethodImpl(Inline)]
        public static implicit operator Ptr8(byte* src)
            => new Ptr8(src);

        [MethodImpl(Inline)]
        public static explicit operator Ptr16(Ptr8 src)
            => new Ptr16((ushort*)src.P);

        [MethodImpl(Inline)]
        public static explicit operator Ptr32(Ptr8 src)
            => new Ptr32((uint*)src.P);

        [MethodImpl(Inline)]
        public static explicit operator Ptr64(Ptr8 src)
            => new Ptr64((ulong*)src.P);

        [MethodImpl(Inline)]
        public static implicit operator byte*(Ptr8 src)
            => src.P;

        public byte* Target
        {
            [MethodImpl(Inline)]
            get => P;
        }
    }
}