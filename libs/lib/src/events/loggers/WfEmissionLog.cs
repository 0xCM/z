//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    class WfEmissionLog : IWfEmissionLog
    {
        readonly FileStream Stream;

        readonly FS.FilePath Target;

        readonly IRecordFormatter<EmissionLogEntry> Formatter;

        bool Closed;

        public WfEmissionLog(FS.FilePath dst)
        {
            Closed = false;
            Target = dst;
            Target.EnsureParentExists().Delete();
            Stream = Target.Stream();
            Formatter = Tables.formatter<EmissionLogEntry>();
            FS.write(Formatter.FormatHeader() + Eol, Stream);
        }

        public bool IsEmpty
        {
            get => Target.IsEmpty;
        }

        public bool IsNonEmpty
        {
            get => Target.IsNonEmpty;
        }

        public string Format()
            => Target.ToUri().Format();
        
        public override string ToString()
            => Format();

        public void Close()
        {
            if(!Closed)
            {
                Stream.Flush();
                Stream.Dispose();
                Closed = true;
            }
        }

        public void Dispose()
        {
            Close();
        }

        public ref readonly FileWritten LogEmission(in FileWritten flow)
        {
            try
            {
                FS.write(Formatter.Format(Loggers.entry(flow, out _)) + Eol, Stream);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }

            return ref flow;
        }

        public ref readonly WfTableFlow<T> LogEmission<T>(in WfTableFlow<T> flow)
            where T : struct
        {
            try
            {
                FS.write(Formatter.Format(Loggers.entry(flow, out _)) + Eol, Stream);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
            return ref flow;
        }
    }
}