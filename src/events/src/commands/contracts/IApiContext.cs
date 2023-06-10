//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiContext
    {
        ApiCmdMethod Method {get;}
    }

    readonly struct ApiContext : IApiContext
    {
        public ApiCmdMethod Method {get;}

        public ApiContext(ApiCmdMethod method)
        {
            Method = method;
        }
    }
}