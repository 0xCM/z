//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEventHubClient : IWfEventSinkDeprecated
    {
        IEventHub Hub {get;}

        void Connect();
    }
}