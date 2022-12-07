//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a message that encapsulates application diagnostic/status/error message content
    /// </summary>
    [ApiHost]
    public class AppMsg : IAppMsg
    {
        public readonly AppMsgData Data;

        public static MsgPattern<FileUri> FileExists
            => "The path {0} exists and yet it shold not";

        public static MsgPattern<FileUri> FileMissing
            => "The path {0} does not exist and yet it should";

        public static MsgPattern<ByteSize,FileUri> EmittedBytes
            => "Emitted {0} bytes to {1}";

        public static MsgPattern<FileUri,Count,Count> CsvHeaderMismatch
            => "The records defined in {0} require {0} fields but {1} were found in the source";

        public static MsgPattern<Count,Count,string> CsvDataMismatch
            => "The target requires {0} fields but {1} were found in {2}";

        public static MsgPattern<Count,Count> FieldCountMismatch
            => "The target requires {0} fields but {1} were found in the source";

        public static MsgPattern<Count,Count,string> CellCountMismatch
            => "The target requires {0} fields but {1} were found in {2}";

        public static RenderPattern<TableId,Count,FileUri> EmittedTable
            => "Emitted <{1}> <{0}> rows to {2}";

        public static RenderPattern<TableId,FileUri> EmittingTable
            => "Emitting <{0}> to {1}";

        public static RenderPattern<FileUri> EmittingFile
            => "Emitting {0}";

        public static RenderPattern<FileUri> EmittedFile
            => "Emitted {0}";

        public static RenderPattern<object> UnhandledCase
            => "Unhandled Case: {0}";

        public static MsgCapture CapacityExceeded<S,T>(S input, T capacity)
        {
            MsgPattern<S,T> msg = "Input data {0} exceeds the target cpacity of {1}";
            return msg.Capture(input,capacity);
        }

        public static RenderPattern<Count,FileUri> EmittedFileLines
            => "Emitted <{0}> lines to {1}";

        public static MsgPattern<string,string> ParseFailure
            => "Could not parse {0} from {1}";

        public static MsgPattern<string> UriParseFailure
            => "Coult not parse {0} as a uri";

        public static MsgPattern<dynamic> NotFound
            => "{0} not found";

        public static MsgPattern<ApiHostUri> HostNotFound
            => "Host {0} not found";

        public static MsgPattern<string,Fence<char>> FenceNotFound
            => "The source text {0} is not fenced by {1}";

        public static StatusMsg<T> status<T>(T data)
            => new StatusMsg<T>(data);

        public static string format(string header, Exception e)
        {
            var message = $"{header}{Eol}";
            message += $"Summary: {e.Message}{Eol}";
            message += $"Detail: {Eol}";
            message += $"{e}{Eol}";
            return message;
        }
        

        [MethodImpl(Inline), Op]
        public static AppMsgSource orginate([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppMsgSource(caller, file, line);

        [MethodImpl(Inline), Op]
        public static AppMsg called(object content, LogLevel kind, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppMsg(content, kind, (FlairKind)kind, caller, file, line);

        [MethodImpl(Inline), Op]
        public static AppMsg error(object content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => define($"{content} {caller} {line} {file}", LogLevel.Error);

        [MethodImpl(Inline), Op]
        public static AppMsg error(Exception e)
            => define(e.ToString(), LogLevel.Error);

        [MethodImpl(Inline), Op]
        public static AppMsg babble(object content)
            => new AppMsg(content, LogLevel.Babble, FlairKind.Disposed, EmptyString, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsgSource source(string caller, string file, int? line)
            => new AppMsgSource(caller, file, line);

        [MethodImpl(Inline), Op]
        public static AppMsg define(object content, LogLevel kind)
            => new AppMsg(content, kind, (FlairKind)(kind), EmptyString, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsg define(AppMsgData src)
            => new AppMsg(src);

        [MethodImpl(Inline), Op]
        public static AppMsg colorize(object content, FlairKind color)
            => new AppMsg(content, LogLevel.Status, color, string.Empty, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsg info(object content)
            => new AppMsg(content, LogLevel.Status, FlairKind.Status, EmptyString, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsg warn(object content)
            => new AppMsg(content, LogLevel.Warning, FlairKind.Warning, EmptyString, EmptyString, null);

        [MethodImpl(Inline)]
        AppMsg(object content, LogLevel kind, FlairKind color, string caller, string file, int? line)
            => Data = new AppMsgData(content,"{0}", kind, color, AppMsgSource.define(caller, file, line));

        [MethodImpl(Inline)]
        AppMsg(AppMsgData data)
            => Data = data;

        /// <summary>
        /// The message classification
        /// </summary>
        public LogLevel Kind
            => Data.Kind;

        /// <summary>
        /// The message foreground color when rendered for display
        /// </summary>
        public FlairKind Flair
            => Data.Flair;

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        public static AppMsg Empty => new AppMsg(AppMsgData.Empty);
    }
}