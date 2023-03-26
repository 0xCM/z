//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EtlContext
    {
        static AppDb AppDb => AppDb.Service;

        public static FilePath table<T>(string name)
            where T : struct
                => AppDb.EtlTargets(name).Path(FS.file(string.Format("{0}.{1}", name, TableId.identify<T>()),FS.Csv));

        public static FilePath table<T>(string name, string scope)
            where T : struct
                => AppDb.EtlTargets(name).Targets(scope).Path(FS.file(string.Format("{0}.{1}", name, TableId.identify<T>()),FS.Csv));
    }
}