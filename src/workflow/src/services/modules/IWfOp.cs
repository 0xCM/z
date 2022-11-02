//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IWfOp
    {
        CmdUri Uri {get;}
    }

    [Free]
    public interface IWfOp<D> : IWfOp
        where D : struct, IWfOp<D>
    {

    }
}