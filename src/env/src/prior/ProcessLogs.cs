//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProcessLogs
    {
        static AppDb AppDb => AppDb.Service;

        public static FilePath errors(Timestamp ts, string name)
            => AppDb.Logs("process").Path(FS.file($"{name}.errors.{ts}",FileKind.Log));

        public static FilePath status(Timestamp ts, string name)
            => AppDb.Logs("process").Path(FS.file($"{name}.{ts}", FileKind.Log));
    }
}