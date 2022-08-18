//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public class ArchiveMonitor : IArchiveMonitor
    {
        public static IArchiveMonitor start(IDbSources target, FileChanged listener, bool recursive = true, string filter = null)
            => new ArchiveMonitor(target, listener, recursive, filter);

        public readonly IDbSources Target;

        readonly FileSystemWatcher Watcher;

        readonly FileChanged Handler;

        event FileChanged Listener;

        public ArchiveMonitor(IDbSources target, FileChanged listener, bool recursive = true, string filter = null, ushort capacity = Pow2.T14)
        {
            Target = target;
            Watcher = new FileSystemWatcher(target.Root.Format(), filter ?? "*.*");
            Watcher.InternalBufferSize = capacity;
            Watcher.IncludeSubdirectories = recursive;
            Handler = SignalChange;
            Listener += listener;
            Subscribe();
            Start();
        }


        public void Dispose()
            => Watcher?.Dispose();

        void SignalChange(FileChangeEvent change)
        {
            try
            {
                Task.Factory.StartNew(() => Listener.Invoke(change));
            }
            catch(Exception e)
            {
                term.error(e);
            }
        }

        [MethodImpl(Inline)]
        static FileChangeEvent change(FileSystemEventArgs e)
            => new FileChangeEvent(FS.path(e.FullPath), (FileChangeKind)e.ChangeType);

        [MethodImpl(Inline)]
        void Created(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        [MethodImpl(Inline)]
        void Deleted(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        [MethodImpl(Inline)]
        void Changed(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        [MethodImpl(Inline)]
        void Renamed(object sender, FileSystemEventArgs e)
            => Handler(change(e));

        void Subscribe()
        {
            Watcher.Created += Created;
            Watcher.Deleted += Deleted;
            Watcher.Changed += Changed;
            Watcher.Renamed += Renamed;
            Watcher.Error += Error;
        }

        [MethodImpl(Inline)]
        public void Start()
            => Watcher.EnableRaisingEvents = true;

        [MethodImpl(Inline)]
        public void Stop()
            => Watcher.EnableRaisingEvents = false;

        void Error(object sender, ErrorEventArgs e)
            => term.error(e.GetException());

        IDbSources IMonitor<IDbSources>.Target
            => Target;
    }
}