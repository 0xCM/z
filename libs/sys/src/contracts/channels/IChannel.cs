//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IChannel
    {
        void Transmit(dynamic src, IReceiver dst)
            => dst.Deposit(src);
    }

    [Free]
    public interface IChannel<S,T> : IChannel
        where T : IReceiver<S>
    {
        void Transmit(in S src, T dst)
            => dst.Deposit(src);        
    }    
}