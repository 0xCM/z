//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline)]
        public static BitVector64<E> bv<E>(ulong src)
            where E : unmanaged, Enum
                => src;
    }
}