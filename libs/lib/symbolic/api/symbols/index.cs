//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Symbols
    {
        [MethodImpl(Inline)]
        public static Symbols<E> index<E>()
            where E : unmanaged, Enum
                => SymCache<E>.get();
    }
}