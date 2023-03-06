//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DirectoryMonitor : IMonitor
    {        
        public static IMonitor start(IDbArchive src, IDbArchive dst, params IFileChangeReceiver[] receivers)
            => new DirectoryMonitor(src, dst);

        readonly IWorkerLog Log;

        readonly IDbArchive Sources;

        readonly IArchiveMonitor Service;

        readonly RunningEvent<string> Running;

        readonly ReadOnlySeq<IFileChangeReceiver> Receivers;

        protected DirectoryMonitor(IDbArchive src, IDbArchive dst, params IFileChangeReceiver[] receivers)
        {
            Receivers = receivers;
            var ts = Timestamp.now();
            var id = FS.identifier(src.Root);
            Log = Loggers.worker(new LogSettings(dst.Path($"{id}.{ts}",FileKind.Log), dst.Path($"{ts}.errors", FileKind.Log)));
            Sources = src;
            Service = ArchiveMonitor.start(Sources, OnChange);
            Running = Events.running(GetType(), $"Initializing monitor over {Sources.Root}/*.*");
            term.emit(Running);
        }

        void Ran()
            => term.emit(Events.ran(Running, $"Finished monitoring {Sources.Root}/*.*"));

        public void Dispose()
        {
            Service?.Dispose();
            Log?.Dispose();
            Ran();
        }

        protected virtual void OnChange(FileChangeEvent e)
        {
            var message = e.Format();
            term.babble(message);
            Log?.LogStatus(message);
            sys.start(() => sys.iter(Receivers, r => r.Deposit(e)));
        }

        public void Start()
        {
            Service?.Stop();
        }

        public void Stop()
        {
            Service?.Stop();
        }
    }
}