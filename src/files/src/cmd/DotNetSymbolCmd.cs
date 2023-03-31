//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd(CommandName)]
    public record class DotNetSymbolCmd : Command<DotNetSymbolCmd>
    {        
        public const string CommandName = "dotnet/symbol";
    
        [CmdArg]
        public FilePath Source;

        [CmdFlag("--recurse-subdirectories")]
        public bit Recurse;
        
        [CmdFlag("--symbols")]
        public bit Symbols;
        
        [CmdFlag("--debugging")]
        public bit Debugging;
        
        [CmdFlag("--modules")]
        public bit Modules;
        
        [CmdFlag("--windows-pdbs")]
        public bit ForceWindowsPdbs;        

        [CmdFlag("--host-only")]
        public bit HostOnly;
        
        [CmdFlag("--verifycore")]
        public bit Verify;

        [CmdFlag("--diagnostics")]
        public bit Diagnostics;

        [CmdFlag("--microsoft-symbol-server")]
        public bit UseMsServer;

        [CmdFlag("--overwrite")]
        public bit Overwrite;

        [CmdArg("--internal-server")]
        public Uri InternalServer;

        [CmdArg("--server-path")]
        public FilePath ServerPath;

        [CmdArg("--output")]
        public FolderPath Target;
        
        [CmdFlag("--timeout")]
        public TimeSpan? Timeout;
                
        [CmdArg("--cache-directory")]
        public FilePath Cache;        
    }
}
