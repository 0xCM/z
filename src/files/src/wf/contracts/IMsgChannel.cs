//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading.Channels;

    public interface IAtomicWriter<T>
    {
        void WriteItem(T item);
    }

    public interface IAtomicReader<T>
    {
        T ReadItem();
    }

    public interface IAtomicChannel<S,T> : IAtomicReader<S>, IAtomicWriter<T>
    {

    }

    public interface IAsyncWriter<T>
    {
        ValueTask PostItem(T item, CancellationToken? ct = null);
    
        ValueTask<uint> PostItems(IEnumerable<T> src, CancellationToken? ct = null);
    }

    public interface IAsyncReader<T>
    {
        ValueTask<T> ReadItem(CancellationToken? ct = null);

        IAsyncEnumerable<T> ReadItems(CancellationToken? ct = null);

    }

    public interface IAsyncChannel<S,T> : IAsyncReader<S>, IAsyncWriter<T> 
    {

    }

    public interface IChannelReader<T> : IAsyncReader<T>, IAtomicReader<T> 
    {

    }

    public interface IChannelWriter<T> : IAsyncWriter<T>, IAtomicWriter<T> 
    {

    }

    public interface IChannel<S,T> 
        where S : IChannelReader<S>
        where T : IChannelWriter<S>
    {
        S Reader {get;}

        T Writer {get;}
    }

    public interface IDiagnosticChannel
    {

    }
    public interface IErrorChannel
    {


    }

    public interface IMsgChannel
    {
        void Babble<T>(T content);

        void Babble(string pattern, params object[] args);

        void Status<T>(T content, FlairKind flair = FlairKind.Status);

        void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        void Row<T>(T content);

        void Row<T>(T content, FlairKind flair);

        void Write<T>(T content);

        void Write<T>(T content, FlairKind flair);

        void Write(string content, FlairKind flair);

        void Write<T>(string name, T value);
    }
}