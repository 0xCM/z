//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiCall
    {
        ApiKey Api {get;}
    }

    [Free]
    public interface IApiCall<H> : IApiCall, IRecord<H>
        where H : unmanaged, IApiCall<H>
    {
    }

    [Free]
    public interface IApiCall<H,R> : IApiCall<H>
        where H : unmanaged, IApiCall<H,R>
        where R : unmanaged
    {
        R Result {get;}
    }
}