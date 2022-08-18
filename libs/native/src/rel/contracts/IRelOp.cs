//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRelOp : INativeOpValue
    {
        MemRelKind RelKind {get;}
    }

    [Free]
    public interface IRelOp<T> : IRelOp, INativeOpValue<T>
        where T : unmanaged
    {
        MemRelKind IRelOp.RelKind
            => (MemRelKind)(byte)Size;
    }
}