//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiService<T> : AppService<T>, IApiService<T>
        where T : ApiService<T>, new()
    {
        protected AppDb AppDb => AppDb.Service;

        protected ApiCmd ApiCmd => Wf.ApiCmd();
    }
}