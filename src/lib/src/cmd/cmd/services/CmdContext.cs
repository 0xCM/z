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
        public readonly EnvVars<string> EnvVars;

        [MethodImpl(Inline)]
        public CmdContext(FolderPath wd, params EnvVar<string>[] src)
        {
            WorkingDir = wd;
            EnvVars = src;
        }
    }
}