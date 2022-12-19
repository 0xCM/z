//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public interface ITransport<P,M,R>
        where M: IModel<M>, new()
        where P : IProvider<P,M>
        where R : IModelReceiver<R,M>

    {
        void Flow(P src, R dst) 
            => dst.Accept(src.Models());
    }

}