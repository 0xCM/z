//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    using System.Linq;

    public interface IModelReceiver
    {
        void Accept(IEnumerable<IModel> src);
    }

    public interface IModelReceiver<M> : IModelReceiver
        where M: new()
    {
        void Accept(IEnumerable<M> src);

        void IModelReceiver.Accept(IEnumerable<IModel> src)
            => Accept(from m in src select m);
    }

    public interface IModelReceiver<R,M> : IModelReceiver<M>
        where R : IModelReceiver<R,M>
        where M : new()
    {
    }



}