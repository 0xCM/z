//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaView
    {
        IEcmaReader Reader {get;}

    }

    public interface IEcmaView<C,R> : IEcmaView
        where R : unmanaged, IEcmaRow<R>
        where C : IEcmaView<C,R>
    {
    }    
}