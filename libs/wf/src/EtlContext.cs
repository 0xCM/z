//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EtlContext
    {
        static AppDb AppDb => AppDb.Service;

        public static FS.FilePath table<T>(ProjectId src)
            where T : struct
                => AppDb.EtlTargets(src).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId src, string scope)
            where T : struct
                => AppDb.EtlTargets(src).Targets(scope).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));
    }
}