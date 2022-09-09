//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Launchers
    {
        static AppDb AppDb => AppDb.Service;

        public static FilePaths paths()
            => DbArchive.match(AppDb.Control("launch").Root, FS.Cmd);
    }
}