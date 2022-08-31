//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public interface IChannel
    {
        IChannelEmitter Emitter {get;}
        
        IChannelReceiver Receiver {get;}

    }


    public interface IChannelReceiver
    {

    }

    public interface IChannelEmitter
    {
        EventId Emit<T>(EventPayload<T> src);
    }


}