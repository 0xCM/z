//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = memory;

    [StructLayout(LayoutKind.Sequential, Size=16, Pack=1)]
    public unsafe struct IndexPtr<T>
        where T : unmanaged
    {
        internal readonly Ptr<T> P;

        internal readonly uint Count;

        internal uint Position;

        [MethodImpl(Inline)]
        internal IndexPtr(Ptr<T> ptr, uint count, uint offset)
        {
            P = ptr;
            Count = count;
            Position = offset;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P;
        }

        public ref T Cell
        {
            [MethodImpl(Inline)]
            get => ref P[Position];
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => P.Hash;
        }

        [MethodImpl(Inline)]
        public bool Next()
            => api.next(ref this);

        [MethodImpl(Inline)]
        public bool Next(out T dst)
            => api.next(ref this, out dst);

        [MethodImpl(Inline)]
        public bool Equals(IndexPtr<T> src)
            => P.Equals(src.P);

        public override bool Equals(object src)
            => src is IndexPtr<T> p && Equals(p);

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(IndexPtr<T> a, IndexPtr<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(IndexPtr<T> a, IndexPtr<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(IndexPtr<T> src)
            => src.Address;

        [MethodImpl(Inline)]
        public static T operator !(IndexPtr<T> src)
            => src.Cell;
    }
}