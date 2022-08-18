//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        /// <summary>
        /// Creates a <see cref='CmdLine'/> that represents 'cmd.exe /c '<paramref name='spec'/>'
        /// </summary>
        /// <param name="spec">The command to execute</param>
        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        [Op, MethodImpl(Inline)]
        public static AppCmdSpec app(string name, CmdArgs args)
            => new AppCmdSpec(name, args);

        public static CmdLine cmd(FS.FilePath src, string args)
            => string.Format("cmd.exe /c {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine cmd(FS.FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

        public static CmdLine cmdline(FS.FilePath path, CmdKind kind)
        {
            return kind switch{
                CmdKind.Cmd => Cmd.cmd(path),
                CmdKind.Tool => Cmd.cmd(path),
                CmdKind.Pwsh => Cmd.pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine cmdline(FS.FilePath path, CmdKind kind, string args)
        {
            return kind switch{
                CmdKind.Cmd => Cmd.cmd(path, args),
                CmdKind.Tool => Cmd.cmd(path, args),
                CmdKind.Pwsh => Cmd.pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }
    }
}