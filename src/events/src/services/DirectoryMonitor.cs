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

        readonly IWorkerLog Target;

        readonly IDbArchive Sources;

        readonly IArchiveMonitor Service;

        readonly RunningEvent<string> Running;

        readonly ReadOnlySeq<IFileChangeReceiver> Receivers;

        DirectoryMonitor(IDbArchive src, IDbArchive dst, params IFileChangeReceiver[] receivers)
        {
            Receivers = receivers;
            var ts = Timestamp.now();
            var id = FS.identifier(src.Root);
            var settings = new LogSettings(dst.Path($"{id}.{ts}",FileKind.Log), dst.Path($"{ts}.errors", FileKind.Log));
            Target = Loggers.worker(settings);
            Sources = src;
            Service = ArchiveMonitor.start(Sources, Change);
            Running = Events.running(GetType(), $"Initializing monitor over {Sources.Root}/*.*");
            term.emit(Running);
        }

        void Ran()
            => term.emit(Events.ran(Running, $"Finished monitoring {Sources.Root}/*.*"));

        public void Dispose()
        {
            Service?.Dispose();
            Target?.Dispose();
            Ran();
        }

        void Change(FileChangeEvent e)
        {
            var message = e.Format();
            term.babble(message);
            Target.LogStatus(message);
            Brodcast(e);
        }

        void Brodcast(FileChangeEvent e)
        {
            sys.start(() => sys.iter(Receivers, r => r.Deposit(e)));
        }

        public void Stop()
        {
            Dispose();
        }
    }
}