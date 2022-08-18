//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IHostedApiMethod : IApiMethod
    {
        new IApiHost Host {get;}

        ApiHostUri IApiMethod.Host
            => Host.HostUri;
    }
}