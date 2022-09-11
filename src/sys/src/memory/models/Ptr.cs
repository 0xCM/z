//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a <see cref='void'/> pointer
    /// </summary>
    public unsafe struct Ptr : IPtr
    {
        public void* P;

        [MethodImpl(Inline)]
        public Ptr(void* src)
            => P = src;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)P;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P;
        }

        [MethodImpl(Inline)]
        public bool Equals(Ptr src)
            => P == src.P;

        [MethodImpl(Inline)]
        public Ptr<T> Cast<T>()
            where T : unmanaged
                => (T*)P;

        [MethodImpl(Inline)]
        public string Format()
            => Address.Format();

        public override int GetHashCode()
            => (int)Hash;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Ptr(void* src)
            => new Ptr(src);

        [MethodImpl(Inline)]
        public static implicit operator Ptr(IntPtr src)
            => new Ptr(src.ToPointer());

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(Ptr src)
            => (IntPtr)src.P;

        [MethodImpl(Inline)]
        public static implicit operator void*(Ptr src)
            => src.P;

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Ptr src)
            => src.Address;

        [MethodImpl(Inline)]
        public static implicit operator Ptr(MemoryAddress src)
            => new Ptr(src.Pointer());

        public void* Target
        {
            [MethodImpl(Inline)]
            get => P;
        }
    }
}