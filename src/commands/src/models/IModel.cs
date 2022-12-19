//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public interface IModel
    {

    }

    public interface IModel<M> : IModel
        where M: IModel<M>, new()
    {


    }
}