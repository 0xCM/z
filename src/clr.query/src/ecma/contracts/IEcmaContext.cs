//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaContext
    {
        IEcmaReader Reader {get;}

    }

    public interface IEcmaContext<C,R> : IEcmaContext
        where R : unmanaged, IEcmaRecord<R>
        where C : IEcmaContext<C,R>
    {
    }    
}