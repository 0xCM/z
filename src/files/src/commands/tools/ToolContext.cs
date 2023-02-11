//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolContext : IToolContext<ToolContext>
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
        public readonly Action<Process> ProcessCreated;

        /// <summary>
        /// Standard i/o redirection
        /// </summary>
        public readonly ISysIO IO;
        
        [MethodImpl(Inline)]
        public ToolContext(FolderPath wd, EnvVars src, Action<Process> create = null, ISysIO io = null)
        {
            WorkingDir = wd;
            Vars = src;
            ProcessCreated = create ?? (p => {});
            IO = io;
        }

        // public ToolContext Redirect(ISysIO io)
        //     => new ToolContext(WorkingDir, Vars, ProcessCreated, io);

        // public ToolContext WithVar(EnvVar var)
        //     => new ToolContext(WorkingDir, Vars.Replace(var), ProcessCreated, IO);

        FolderPath IToolContext.WorkingDir 
            => WorkingDir;

        EnvVars IToolContext.Vars 
            => Vars;

        public static ToolContext Default 
            => new ToolContext(FS.dir(Environment.CurrentDirectory), EnvVars.Empty);

        Action<Process> IToolContext.ProcessCreated 
            => ProcessCreated;

        ISysIO IToolContext.IO 
            => IO;
    }
}