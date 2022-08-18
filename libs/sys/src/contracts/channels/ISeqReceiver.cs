//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISeqReceiver<T>
    {
        void Deposit(ReadOnlySpan<T> src);

        Task Enqueue(ReadOnlySpan<T> src);
    }
}