//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WinSdk : AppService<WinSdk>
    {
        public IDbArchive Root()
            => AppSettings.Default.Sdk("windows");

        public IDbArchive Kit()
            => Root().Scoped("kit");

        public IDbArchive Wdk()
            => Root().Scoped("wdk");

        public IEnumerable<FilePath> DebuggerFiles(FileKind kind)
            => Kit().Scoped("10/Debuggers/x64").Enumerate(true, kind);        
    }
}