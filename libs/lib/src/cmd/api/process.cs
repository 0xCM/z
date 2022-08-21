//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        [MethodImpl(Inline), Op]
        public static CmdProcess process(CmdLine cmd)
            => new CmdProcess(cmd);

        [Op]
        public static CmdProcess process(CmdLine cmd, CmdVars? vars)
        {
            var options = new CmdProcessOptions();
            CmdProcess.include(vars, options);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess process(CmdLine cmd, CmdVars? vars, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions();
            CmdProcess.include(vars, options);
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess process(CmdLine cmd, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions();
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess process(CmdLine cmd, TextWriter dst)
            => new CmdProcess(cmd, new CmdProcessOptions(dst));

        [Op]
        public static CmdProcess process(CmdLine cmd, TextWriter dst, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions(dst);
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        public static CmdProcess process(FS.FilePath path, CmdKind kind, string args)
            => process(Cmd.cmd(path,kind,args));

        [Op]
        public static CmdProcess process(CmdLine command, CmdProcessOptions config)
            => new CmdProcess(command, config);        
    }
}