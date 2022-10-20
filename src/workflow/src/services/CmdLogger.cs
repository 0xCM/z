//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public readonly struct CmdLogger : IDisposable
    {
        readonly FilePath Target;

        readonly Stream LogStream;

        [MethodImpl(Inline)]
        public CmdLogger(FilePath dst)
        {
            Target = dst;
            LogStream = new FileStream(dst.CreateParentIfMissing().Name, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);;
        }

        public void Dispose()
        {
            LogStream.Dispose();
        }

        public void Log(in ErrorEvent<Exception> error)
        {
            Log(LogLevel.Error, error.Format());
        }

        /// <summary>
        /// Log a line of text to the logging file, with string.Format arguments.
        /// </summary>
        public void Log(LogLevel kind, params object[] args)
            => Log(kind, string.Join("| ", args));

        /// <summary>
        /// Log a line of text to the logging file.
        /// </summary>
        /// <param name="kind">The message kind</param>
        /// <param name="content">The message content</param>
        public void Log(LogLevel kind, string content)
        {
            const string Pattern = "| {0,-10} | {1}";
            var entry = string.Format(Pattern, kind, content);
            var data = text.utf8(entry + Eol);
            LogStream.Seek(0, SeekOrigin.End);
            LogStream.Write(data, 0, data.Length);
            LogStream.Flush();
        }

        public void Error(string content)
            => Log(LogLevel.Error, content);

        public void Error(string format, params object[] args)
            => Log(LogLevel.Error, args);
    }
}