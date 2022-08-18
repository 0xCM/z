//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISeqChannel<S,T> 
        where T : ISeqReceiver<S>         
    {
        void Deposit(ReadOnlySpan<S> src, T dst)
            => dst.Deposit(src);
        
        Task Transmit(ReadOnlySpan<S> src, T dst)
            => dst.Enqueue(src);
    }
}