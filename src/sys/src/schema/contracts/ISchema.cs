//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISchema
    {


    }

    public interface ISchema<S> : ISchema
        where S : ISchema<S>, new()
    {

    }
}