//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiSet]
    public abstract record class ApiSet<T> : IApiSet<T>
        where T : ApiSet<T>, new()
    {

    }
}