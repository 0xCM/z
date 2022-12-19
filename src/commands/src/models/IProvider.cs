//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    using System.Linq;

    public interface IProvider
    {
        IEnumerable<IModel> Models();
    }

    public interface IProvider<M> : IProvider
        where M: IModel<M>, new()
    {
        new IEnumerable<M> Models();

        IEnumerable<IModel> IProvider.Models()
            => from m in Models() select m as IModel;
    }
    
    public interface IProvider<P,M> : IProvider<M>
        where P : IProvider<P,M>
        where M: IModel<M>, new()
    {

    }
}