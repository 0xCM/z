//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        [MethodImpl(Inline)]
        public static unsafe E read<E,T>(in T scalar, E e = default)
            where E : unmanaged, Enum
            where T : unmanaged
                => Unsafe.Read<E>(sys.gptr<T,E>(scalar));
    }
}