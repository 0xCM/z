//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdContext : ICmdContext<CmdContext>
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
        public CmdContext(FolderPath wd, EnvVars src, Action<Process> create = null, ISysIO io = null)
        {
            WorkingDir = wd;
            Vars = src;
            ProcessCreated = create ?? (p => {});
            IO = io;
        }

        public CmdContext Redirect(ISysIO io)
            => new CmdContext(WorkingDir, Vars, ProcessCreated, io);

        public CmdContext WithVar(EnvVar var)
            => new CmdContext(WorkingDir, Vars.Replace(var), ProcessCreated, IO);

        FolderPath ICmdContext.WorkingDir 
            => WorkingDir;

        EnvVars ICmdContext.Vars 
            => Vars;

        public static CmdContext Default 
            => new CmdContext(FS.dir(Environment.CurrentDirectory), EnvVars.Empty);

        Action<Process> ICmdContext.ProcessCreated 
            => ProcessCreated;

        ISysIO ICmdContext.IO 
            => IO;
    }
}