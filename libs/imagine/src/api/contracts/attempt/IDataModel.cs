//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDataModel
    {
        string Name {get;}
    }

    [Free]
    public interface IDataModel<M> : IDataModel
        where M : IDataModel<M>, new()
    {
        string IDataModel.Name
            => typeof(M).Name;
    }

    [Free]
    public interface IDataModel<M,K> : IDataModel<M>, IKinded<K>
        where M : struct, IDataModel<M,K>
        where K : unmanaged
    {

    }
}