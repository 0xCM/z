//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IChannel : IDisposable
    {

    }

    public interface ISeqEmitter : IChannel
    {

    }

    public interface ISeqReceiver : IChannel
    {

    }

    public interface ISeqChannel : ISeqEmitter, ISeqReceiver, IDisposable
    {
        void Disposing()
        {

        }

        void Disposed()
        {

        }
        void IDisposable.Dispose()
        {
            Disposing();
            (this as ISeqEmitter).Dispose();
            (this as ISeqReceiver).Dispose();
            Disposed();
        }
    }

    public interface ISeqEmitter<P> : ISeqEmitter
        where P : unmanaged
    {
        void Write(ReadOnlySpan<P> src);

        Task BeginWrite(ReadOnlySpan<P> src);
    }

    public interface ISeqReceiver<P> : ISeqReceiver
    {
        ReadOnlySpan<P> Read();
    }

    public interface ISeqChannel<S,T> : ISeqEmitter<S>, ISeqReceiver<T>
        where S : unmanaged
        where T : unmanaged
    {


    }
}