//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class Events
    {
        [Op]
        public static StackFrame frame(int index)
            => new StackFrame(index);

        const NumericKind Closure = UInt64k;

        static string prefix(object title, Type host, string caller)
            => string.Concat(ExecutingPart.Name.Format(), Chars.FSlash, host.Name, Chars.FSlash, caller, Chars.LBrace, title, Chars.RBrace).PadRight(60);

        static IAppMsg message(object title, object msg, Type host, string caller, FlairKind flair)
            => AppMsg.colorize(string.Concat(prefix(title, host, caller), Chars.Pipe, Chars.Space, msg), flair);

        public static EventBroker broker(LogSettings config)
            => new EventBroker(new EventLogger(config), true);

        public static EventBroker broker(IEventSink target)
            => new EventBroker(target,false);

        [MethodImpl(Inline), Op]
        public static CallingMember caller([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new CallingMember(caller, file, line ?? 0);

        public static IAppMsg message<T>(Type host, string title, T content, LogLevel level = LogLevel.Status, FlairKind flair = FlairKind.Status, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            var origin = Events.originate(host, caller,file,line ?? 0);
            var data = new AppMsgData<IAppMsg>(message(title, content, host, caller, flair), "{0}", level, flair, origin);
            return AppMsg.define(data);            
        }

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink dst)
            => new EventSignal(dst, dst.Host);

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, Type host)
            => new EventSignal(sink, host);

        [Op, Closures(Closure)]
        public static BabbleEvent<T> babble<T>(Type host, T msg)
            => new BabbleEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static StatusEvent<T> status<T>(Type host, T msg, FlairKind flair = FlairKind.Status)
            => new StatusEvent<T>(host, msg, flair);

        [Op, Closures(Closure)]
        public static WarnEvent<T> warn<T>(Type host, T msg)
            => new WarnEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static WarnEvent<T> warn<T>(Type host, T msg, EventOrigin origin)
            => new WarnEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static ErrorEvent<T> error<T>(Type host, T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new ErrorEvent<T>(host, msg, originate(host, caller,file,line));

        [Op, Closures(Closure)]
        public static ErrorEvent<string> error(Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new ErrorEvent<string>(host, e, e.Message, originate(caller, caller,file, line ?? 0));

        [Op, Closures(Closure)]
        public static ErrorEvent<T> error<T>(T msg, EventOrigin origin, Type host)
            => new ErrorEvent<T>(host, msg, origin);

        [Op, Closures(Closure)]
        public static ErrorEvent<string> error(MethodInfo src, string msg)
            => new ErrorEvent<string>(src.DeclaringType, msg, originate(src.DeclaringType, src.DisplayName(), EmptyString, 0));

        [Op]
        public static EventOrigin originate(Type type, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => originate(type.Name, caller, file, line);

        [Op, Closures(UInt64k)]
        public static ErrorEvent<string> error(Type host, Exception e, EventOrigin source)
            => new ErrorEvent<string>(host, e, e.Message, source);

        [Op, Closures(UInt64k)]
        public static ErrorEvent<T> error<T>(Type host, T msg, EventOrigin source)
            => new ErrorEvent<T>(host, msg, source);

        [Op]
        public static EventOrigin originate(string name, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new EventOrigin(name, new CallingMember(caller, file, line ?? 0));

        [Op, Closures(Closure)]
        public static EmittingFileEvent emittingFile(Type host, FilePath dst)
            => new EmittingFileEvent(host, dst);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FilePath path, Count count)
            => new EmittedFileEvent(host, path, count);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FilePath path)
            => new EmittedFileEvent(host, path);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FilePath path, ByteSize size)
            => new EmittedFileEvent(host, path, (uint)size);

        [Op]
        public static EmittedFileEvent<T> emittedFile<T>(Type host, FilePath path, T msg)
            => new EmittedFileEvent<T>(host, path, msg);

        [Op]
        public static EmittingTableEvent emittingTable(Type host, Type src, FilePath dst)
            => new EmittingTableEvent(host, src, dst);

        [Op, Closures(Closure)]
        public static EmittingTableEvent<T> emittingTable<T>(Type host, FilePath dst)
            => new EmittingTableEvent<T>(host, dst);

        [Op, Closures(Closure)]
        public static EmittedTableEvent<T> emittedTable<T>(Type host, Count count, FilePath dst)
            => new EmittedTableEvent<T>(host, count, dst);

        [Op]
        public static EmittedTableEvent emittedTable(Type host, TableId table, Count count, FilePath dst)
            => new EmittedTableEvent(host, table, count, dst);

        [Op, Closures(Closure)]
        public static RunningEvent<T> running<T>(Type host, T msg)
            => new RunningEvent<T>(host, msg);

        [Op]
        public static RunningEvent running(Type host)
            => new RunningEvent(host);

        [Op, Closures(Closure)]
        public static RanEvent<T> ran<T>(Type host, T msg)
            => new RanEvent<T>(host, msg);

        [Op, Closures(Closure)]
        public static RanEvent<T> ran<T>(RunningEvent<T> prior, T msg = default)
            => new RanEvent<T>(prior, msg);

        [Op, Closures(Closure)]
        public static CreatingEvent creating(Type host)
            => new CreatingEvent(host);

        [Op, Closures(Closure)]
        public static CreatedEvent created(Type host)
            => new CreatedEvent(host);

        [Op, Closures(Closure)]
        public static CreatedEvent<T> created<T>(T data, Type host)
            => new CreatedEvent<T>(data,host);

        [Op, Closures(Closure)]
        public static CreatedEvent<T> created<T>(T data, CreatingEvent prior)
            => new CreatedEvent<T>(data, prior);

        [Op, Closures(Closure)]
        public static CreatedEvent created(CreatingEvent prior)
            => new CreatedEvent(prior);

        [Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data)
            => new DataEvent<T>(data);

        [Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data, FlairKind flair)
            => new DataEvent<T>(data, flair);

        [Op, Closures(Closure)]
        public static RowEvent<T> row<T>(T data, FlairKind flair)
            => new RowEvent<T>(data, flair);

        [Op, Closures(Closure)]
        public static RowEvent<T> row<T>(T data)
            => new RowEvent<T>(data, FlairKind.Data);

        [Op]
        public static DisposedEvent disposed(Type host)
            => new DisposedEvent(host);
    }
}