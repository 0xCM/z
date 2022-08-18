//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate void FileChanged(FileChangeEvent change);

    public interface IMonitor : IDisposable
    {
        void Stop();
    }

    public interface IMonitor<T> : IMonitor
    {
        T Target {get;}
    }

    [Free]
    public interface IArchiveMonitor : IMonitor<IDbSources>
    {

    }
}