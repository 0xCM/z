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

        
        [MethodImpl(Inline)]
        public CmdContext(FolderPath wd, params EnvVar[] src)
        {
            WorkingDir = wd;
            Vars = src;
        }

        public CmdContext WithVar(EnvVar var)
            => new CmdContext(WorkingDir, Vars.Replace(var));

        FolderPath ICmdContext.WorkingDir 
            => WorkingDir;

        EnvVars ICmdContext.Vars 
            => Vars;

        public static CmdContext Default => new CmdContext(Env.cd());
    }
}