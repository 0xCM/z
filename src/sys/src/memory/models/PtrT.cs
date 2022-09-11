//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = memory;

    /// <summary>
    /// Captures a <typeparamref name='T'/>-parametric  <see cref='unmanaged'/> generic pointer
    /// </summary>
    public unsafe struct Ptr<T> : IPtr<T>
        where T : unmanaged
    {
        public T* P;

        [MethodImpl(Inline)]
        public Ptr(T* src)
            => P = src;

        public readonly MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P;
        }

        public ref T this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(P,index);
        }

        public ref T this[long index]
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
        public bool Equals(Ptr<T> src)
            => P == src.P;

        public override bool Equals(object src)
            => src is Ptr<T> p && Equals(p);

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static T operator !(Ptr<T> x)
            => *x.P;

        [MethodImpl(Inline)]
        public static T* operator ~(Ptr<T> x)
            =>x.P;

        [MethodImpl(Inline)]
        public static Ptr<T> operator ++(Ptr<T> x)
            => api.next(x);

        [MethodImpl(Inline)]
        public static Ptr<T> operator --(Ptr<T> x)
            => api.prior(x);

        [MethodImpl(Inline)]
        public static bool operator ==(Ptr<T> a, Ptr<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Ptr<T> a, Ptr<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Ptr<T> src)
            => src.Address;

        [MethodImpl(Inline)]
        public static implicit operator Ptr<T>(T* src)
            => new Ptr<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T*(Ptr<T> src)
            => src.P;

        public T* Target
        {
            [MethodImpl(Inline)]
            get => P;
        }
    }
}