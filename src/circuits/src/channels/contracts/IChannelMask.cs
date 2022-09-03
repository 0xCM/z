//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IChannelMask
    {
        ChannelMaskKind Kind {get;}

        ulong Value {get;}
    }

    [Free]
    public interface IChannelMask<T> : IChannelMask
        where T : unmanaged, IChannelMask<T>
    {
    }
}