//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ProcessLogs
    {
        public static FilePath errors(FolderPath root, Timestamp ts, string name)
            => root + FS.file($"{name}.errors.{ts}",FileKind.Log);

        public static FilePath status(FolderPath root, Timestamp ts, string name)
            => root + FS.file($"{name}.{ts}", FileKind.Log);
    }
}