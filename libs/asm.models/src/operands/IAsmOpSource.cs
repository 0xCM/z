//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmOpSource
    {
        AsmOpClass OpClass {get;}

        AsmOpKind OpKind {get;}

        byte OpCount {get;}
    }

    public interface IAsmOpSource<T> : IAsmOpSource
        where T : unmanaged, IAsmOp
    {
        T Next();

        bool Next(out T dst);
    }
}