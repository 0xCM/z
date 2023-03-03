//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolContext : IToolContext
    {
        /// <summary>
        /// The working folder, if any
        /// </summary>
        public readonly FolderPath WorkingDir;

        /// <summary>
        /// Environment variables to use, if any
        /// </summary>
        public readonly EnvVars Vars;
        
        /// <summary>
        /// Invoked upon process creation
        /// </summary>
        public readonly Action<Process> ProcessStart;

        public readonly Action<int> ProcessExit;
        
        [MethodImpl(Inline)]
        public ToolContext(FolderPath wd, EnvVars src, Action<Process> create = null, Action<int> exit = null)
        {
            WorkingDir = wd;
            Vars = src;
            ProcessStart = create ?? (p => {});
            ProcessExit = exit ?? (e => {});
        }

        FolderPath IToolContext.WorkingDir 
            => WorkingDir;

        EnvVars IToolContext.Vars 
            => Vars;

        public static ToolContext Default 
            => new ToolContext(FS.dir(Environment.CurrentDirectory), EnvVars.Empty);

        Action<Process> IToolContext.ProcessCreated 
            => ProcessStart;
    }
}