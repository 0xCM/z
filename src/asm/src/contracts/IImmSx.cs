//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Free]
    public interface IImmSx<I,S,X> : ISignExtension<S,X>, IDataType<I>
        where S : unmanaged, IImmOp<S>
        where X : unmanaged, IImmOp<X>
        where I : unmanaged, IImmSx<I,S,X>
    {

    }
}