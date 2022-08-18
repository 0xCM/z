//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Settings(Id)]
    public struct SymbolCollectorSettings : ISettings<SymbolCollectorSettings>
    {
        const string Id = "symbolics.collector.settings";

        [CmdFlag("--recurse-subdirectories")]
        public bool Recurse;
        
        [CmdFlag("--symbols")]
        public bool Symbols;
        
        [CmdFlag("--debugging")]
        public bool Debugging;
        
        [CmdFlag("--modules")]
        public bool Modules;
        
        [CmdFlag("--windows-pdbs")]
        public bool ForceWindowsPdbs;        

        [CmdFlag("--host-only")]
        public bool HostOnly;
        
        [CmdFlag("--verifycore")]
        public bool Verify;

        [CmdFlag("--diagnostics")]
        public bool Diagnostics;

        [CmdFlag("--microsoft-symbol-server")]
        public bool UseMsServer;

        [CmdFlag("--overwrite")]
        public bool Overwrite;

        [CmdArg("--internal-server")]
        public Uri InternalServer;

        [CmdArg("--server-path")]
        public FS.FilePath ServerPath;

        [CmdArg("--output")]
        public FS.FolderPath Target;
        
        [CmdFlag("--timeout")]
        public TimeSpan? Timeout;
                
        [CmdArg("--cache-directory")]
        public FS.FilePath Cache;        
    }
}
