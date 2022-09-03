//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDistributive<S> : ILeftDistributive<S>, IRightDistributive<S>
    {}

    public interface IDistributive<S,T> : IDistributive<S>, ILeftDistributive<S,T>, IRightDistributive<S,T>
        where S : IDistributive<S,T>,new() { }

}