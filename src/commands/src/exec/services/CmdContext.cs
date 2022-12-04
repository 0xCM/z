//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdContext
    {
        /// <summary>
        /// The working folder, if any
        /// </summary>
        public readonly FolderPath WorkingDir;

        /// <summary>
        /// Environment variables to use, if any
        /// </summary>
        public readonly EnvVars EnvVars;

        [MethodImpl(Inline)]
        public CmdContext(FolderPath wd, params EnvVar[] src)
        {
            WorkingDir = wd;
            EnvVars = src;
        }

        public static CmdContext Default => new CmdContext(Env.cd());
    }
}