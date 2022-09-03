//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct FPtr<D>
        where D : Delegate
    {
        public Ptr P;

        [MethodImpl(Inline)]
        public unsafe FPtr(void* src)
            => P = src;

        public readonly MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P.Address;
        }

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(FPtr<D> src)
            => src.P;
    }
}