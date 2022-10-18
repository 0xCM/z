//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfServices
    {   
        JsonDocument Serialize<A>(A src)
            where A : IWfAction<A>, new();

        A Materialize<A>(JsonText src)
            where A : IWfAction<A>, new();
    }
}