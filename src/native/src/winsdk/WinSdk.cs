//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WinSdk : WfSvc<WinSdk>
    {
        public IDbArchive Root()
            => AppSettings.Sdk("windows");

        public IDbArchive Kit()
            => Root().Scoped("kit");

        public IDbArchive Wdk()
            => Root().Scoped("wdk");

        public IEnumerable<FilePath> DebuggerFiles(FileKind kind)
            => Kit().Scoped("10/Debuggers/x64").Enumerate(true, kind);        
    }
}