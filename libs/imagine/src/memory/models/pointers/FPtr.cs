//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe struct FPtr
    {
        public Ptr P;

        [MethodImpl(Inline)]
        public unsafe FPtr(void* src)
        {
            P = src;
        }

        [MethodImpl(Inline)]
        public FPtr(IntPtr src)
        {
            P = src;
        }

        public readonly MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P.Address;
        }

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(FPtr src)
            => src.P;

        [MethodImpl(Inline)]
        public static implicit operator FPtr(MemoryAddress src)
            => new FPtr(src);

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(FPtr src)
            => src.P;

        [MethodImpl(Inline)]
        public static implicit operator FPtr(IntPtr src)
            => new FPtr(src);
    }
}