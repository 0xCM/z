//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    class EmissionLog : IWfEmissions
    {
        readonly FileStream Stream;

        readonly FilePath Target;

        readonly ICsvFormatter<EmissionLogEntry> Formatter;

        bool Closed;

        public EmissionLog(FilePath dst)
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

        public ref readonly FileEmission LogEmission(in FileEmission flow)
        {
            try
            {
                FS.write(Formatter.Format(Loggers.entry(flow, out _)) + Eol, Stream);
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }

            return ref flow;
        }

        public ref readonly TableFlow<T> LogEmission<T>(in TableFlow<T> flow)
        {
            try
            {
                FS.write(Formatter.Format(Loggers.entry(flow, out _)) + Eol, Stream);
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
            return ref flow;
        }
    }
}