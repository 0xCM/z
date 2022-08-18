//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct VImm8UnaryResolvers
    {
        public static V128Imm8UnaryResolver<T> create<T>(Type host, W128 w)
            where T : unmanaged
                => new V128Imm8UnaryResolver<T>(host);

        public static V256Imm8UnaryResover<T> create<T>(Type host, W256 w)
            where T : unmanaged
                => new V256Imm8UnaryResover<T>(host);
    }
}