//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Agent]
public class DirectoryMonitor : IAgent
{        
    public static IAgent create(IDbArchive src, IDbArchive dst)
        => new DirectoryMonitor(src, dst);

    readonly IWorkerLog Log;

    readonly IDbArchive Sources;

    RunningEvent<string> Running;

    readonly IDbArchive Watched;


    readonly FileSystemWatcher Watcher;

    readonly EventHandler<FileChangeEvent> Handler;

    event EventHandler<FileChangeEvent> Listener;

    protected DirectoryMonitor(IDbArchive src, IDbArchive dst)
    {
        var ts = Timestamp.now();
        var id = FS.identifier(src.Root);
        Watched = src;
        Watcher = new (Watched.Root.Format(), "*.*"){
            InternalBufferSize = Pow2.T14,
            IncludeSubdirectories = true
        };
        Handler = SignalChange;
        Listener += OnChange;
        Log = WorkerLog.open(new LogSettings(dst.Path($"{id}.{ts}",FileKind.Log), dst.Path($"{ts}.errors", FileKind.Log)));
        Sources = src;
        Subscribe();
    }

    void SignalChange(FileChangeEvent change)
    {
        try
        {
            Task.Factory.StartNew(() => Listener.Invoke(change));
        }
        catch(Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }

    [MethodImpl(Inline)]
    static FileChangeEvent change(FileSystemEventArgs e)
        => new (FS.path(e.FullPath), (FileChangeKind)e.ChangeType);

    void Subscribe()
    {
        Watcher.Created += Created;
        Watcher.Deleted += Deleted;
        Watcher.Changed += Changed;
        Watcher.Renamed += Renamed;
        Watcher.Error += Error;
    }

    void Error(object sender, ErrorEventArgs e)
        => Console.Error.WriteLine(e.GetException());

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

    void Ran()
        => term.emit(Events.ran(Running, $"Finished monitoring {Sources.Root}/*.*"));

    public void Dispose()
    {
        Watcher?.Dispose();
        Log?.Dispose();

        Ran();
    }

    protected virtual void OnChange(FileChangeEvent e)
    {
        var message = e.Format();
        term.babble(message);
        Log?.LogStatus(message);       
    }

    public Task Start()
    {
        return sys.start(
            () => {
                Watcher.EnableRaisingEvents = true;
                Running = Events.running(GetType(), $"Initializing monitor over {Sources.Root}/*.*");
                term.emit(Running);
            });
    }

    public Task Stop()
    {
        return sys.start(() => Watcher.EnableRaisingEvents = false);
    }
}
