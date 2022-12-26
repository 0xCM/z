//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    internal class WorkerLog : IWorkerLog
    {
        public readonly FilePath StatusPath;

        public readonly FilePath ErrorPath;

        readonly FileStream Status;

        public WorkerLog(LogSettings config)
        {
            StatusPath = config.StatusPath;
            ErrorPath = config.ErrorPath;
            Status = StatusPath.Stream();
        }

        public void Dispose()
        {
            Status?.Flush();
            Status?.Dispose();
        }

        public void LogStatus(string content)
        {
            try
            {
                FS.write(content + Eol, Status);
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public void LogError(string content)
        {
            try
            {
                ErrorPath.AppendLines(content);
                FS.write("[error] ", Status);
                FS.write(RP.PageBreak40 + Eol, Status);
                FS.write(content + Eol, Status);
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
        }
    }
}