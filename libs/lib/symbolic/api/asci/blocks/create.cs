//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = AsciSymbol;

    partial struct AsciBlocks
    {
        public static AsciBlock<N> alloc<N>(N n = default)
            where N : unmanaged, ITypeNat
                => new AsciBlock<N>(sys.alloc<S>(Typed.value<N>()));
    }
}