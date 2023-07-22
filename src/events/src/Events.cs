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
        public static EventOrigin origin(string name, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new (name, new CallingMember(caller, file, line ?? 0));

        [Op]
        public static StackFrame frame(int index)
            => new (index);

        const NumericKind Closure = UInt64k;

        static string prefix(object title, Type host, string caller)
            => string.Concat(ExecutingPart.Name.Format(), Chars.FSlash, host.Name, Chars.FSlash, caller, Chars.LBrace, title, Chars.RBrace).PadRight(60);

        static AppMsg message(object title, object msg, Type host, string caller, FlairKind flair)
            => AppMsg.colorize(string.Concat(prefix(title, host, caller), Chars.Pipe, Chars.Space, msg), flair);

        public static EventBroker broker(LogSettings config)
            => new (new EventLogger(config), true);

        public static EventBroker broker(IEventSink target)
            => new (target,false);

        [MethodImpl(Inline), Op]
        public static CallingMember caller([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new (caller, file, line ?? 0);

        public static IAppMsg message<T>(Type host, string title, T content, LogLevel level = LogLevel.Status, FlairKind flair = FlairKind.Status, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            var origin = originate(host, caller,file,line ?? 0);
            var data = new AppMsgData<IAppMsg>(message(title, content, host, caller, flair), "{0}", level, flair, origin);
            return AppMsg.define(data);            
        }

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink dst)
            => new (dst, dst.Host);

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, Type host)
            => new (sink, host);

        [Op, Closures(Closure)]
        public static BabbleEvent<T> babble<T>(Type host, T msg)
            => new (host, msg);

        [Op, Closures(Closure)]
        public static StatusEvent<T> status<T>(Type host, T msg, FlairKind flair = FlairKind.Status)
            => new (host, msg, flair);

        [Op, Closures(Closure)]
        public static WarnEvent<T> warn<T>(Type host, T msg)
            => new (host, msg);

        [Op, Closures(Closure)]
        public static WarnEvent<T> warn<T>(Type host, T msg, EventOrigin origin)
            => new (host, msg);

        [Op, Closures(Closure)]
        public static ErrorEvent<T> error<T>(Type host, T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new (host, msg, originate(host, caller,file,line));

        [Op, Closures(Closure)]
        public static ErrorEvent<string> error(Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new (host, e, e.Message, originate(caller, caller,file, line ?? 0));

        [Op, Closures(Closure)]
        public static ErrorEvent<T> error<T>(T msg, EventOrigin origin, Type host)
            => new (host, msg, origin);

        [Op, Closures(Closure)]
        public static ErrorEvent<string> error(MethodInfo src, string msg)
            => new (src.DeclaringType, msg, originate(src.DeclaringType, src.DisplayName(), EmptyString, 0));

        [Op]
        public static EventOrigin originate(Type type, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => originate(type.Name, caller, file, line);

        [Op, Closures(UInt64k)]
        public static ErrorEvent<string> error(Type host, Exception e, EventOrigin source)
            => new (host, e, e.Message, source);

        [Op, Closures(UInt64k)]
        public static ErrorEvent<T> error<T>(Type host, T msg, EventOrigin source)
            => new (host, msg, source);

        [Op]
        public static EventOrigin originate(string name, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new (name, new CallingMember(caller, file, line ?? 0));

        [Op, Closures(Closure)]
        public static EmittingFileEvent emittingFile(Type host, FilePath dst)
            => new (host, dst);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FilePath path, Count count)
            => new (host, path, count);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FilePath path)
            => new (host, path);

        [Op]
        public static EmittedFileEvent emittedFile(Type host, FilePath path, ByteSize size)
            => new (host, path, (uint)size);

        [Op]
        public static EmittedFileEvent<T> emittedFile<T>(Type host, FilePath path, T msg)
            => new (host, path, msg);

        [Op]
        public static EmittingTableEvent emittingTable(Type host, Type src, FilePath dst)
            => new (host, src, dst);

        [Op, Closures(Closure)]
        public static EmittingTableEvent<T> emittingTable<T>(Type host, FilePath dst)
            => new (host, dst);

        [Op, Closures(Closure)]
        public static EmittedTableEvent<T> emittedTable<T>(Type host, Count count, FilePath dst)
            => new (host, count, dst);

        [Op]
        public static EmittedTableEvent emittedTable(Type host, TableId table, Count count, FilePath dst)
            => new (host, table, count, dst);

        [Op, Closures(Closure)]
        public static RunningEvent<T> running<T>(Type host, T msg)
            => new (host, msg);

        [Op]
        public static RunningEvent running(Type host)
            => new (host);

        [Op, Closures(Closure)]
        public static RanEvent<T> ran<T>(Type host, T msg)
            => new (host, msg);

        [Op, Closures(Closure)]
        public static RanEvent<T> ran<T>(RunningEvent<T> prior, T msg = default)
            => new (prior, msg);

        [Op, Closures(Closure)]
        public static CreatingEvent creating(Type host)
            => new (host);

        [Op, Closures(Closure)]
        public static CreatedEvent created(Type host)
            => new (host);

        [Op, Closures(Closure)]
        public static CreatedEvent<T> created<T>(T data, Type host)
            => new (data,host);

        [Op, Closures(Closure)]
        public static CreatedEvent<T> created<T>(T data, CreatingEvent prior)
            => new (data, prior);

        [Op, Closures(Closure)]
        public static CreatedEvent created(CreatingEvent prior)
            => new (prior);

        [Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data)
            => new (data);

        [Op, Closures(Closure)]
        public static DataEvent<T> data<T>(T data, FlairKind flair)
            => new (data, flair);

        [Op, Closures(Closure)]
        public static RowEvent<T> row<T>(T data, FlairKind flair)
            => new (data, flair);

        [Op, Closures(Closure)]
        public static RowEvent<T> row<T>(T data)
            => new (data, FlairKind.Data);

        [Op]
        public static DisposedEvent disposed(Type host)
            => new (host);
    }
}