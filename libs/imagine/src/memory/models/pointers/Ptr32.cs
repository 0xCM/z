//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using api = memory;

    /// <summary>
    /// Captures a <see cref='uint'/> pointer
    /// </summary>
    [ApiComplete]
    public unsafe struct Ptr32 : IPtr<uint>
    {
        public uint* P;

        [MethodImpl(Inline)]
        public Ptr32(uint* src)
            => P = src;

        public ref uint this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(P,index);
        }

        public ref uint this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(P,index);
        }

        public readonly MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)P;
        }

        [MethodImpl(Inline)]
        public bool Equals(Ptr32 src)
            => P == src.P;

        public override bool Equals(object src)
            => src is Ptr32 p && Equals(p);

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static uint operator !(Ptr32 x)
            => *x.P;

        [MethodImpl(Inline)]
        public static Ptr32 operator ++(Ptr32 x)
            => api.next(x);

        [MethodImpl(Inline)]
        public static Ptr32 operator --(Ptr32 x)
            => api.prior(x);

        [MethodImpl(Inline)]
        public static implicit operator Ptr<uint>(Ptr32 src)
            => new Ptr<uint>(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Ptr32 src)
            => src.Address;

        [MethodImpl(Inline)]
        public static explicit operator Ptr8(Ptr32 src)
            => new Ptr8((byte*)src.P);

        [MethodImpl(Inline)]
        public static explicit operator Ptr16(Ptr32 src)
            => new Ptr16((ushort*)src.P);

        [MethodImpl(Inline)]
        public static explicit operator Ptr64(Ptr32 src)
            => new Ptr64((ulong*)src.P);

        [MethodImpl(Inline)]
        public static implicit operator Ptr32(uint* src)
            => new Ptr32(src);

        [MethodImpl(Inline)]
        public static implicit operator uint*(Ptr32 src)
            => src.P;

        public uint* Target
        {
            [MethodImpl(Inline)]
            get => P;
        }
    }
}