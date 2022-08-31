//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdLauncher
    {
        static void include(CmdVars? src, CmdProcessOptions dst)
        {
            if(src != null)
            {
                var count = src.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var v = ref src[i];
                    if(v.IsNonEmpty && v.Name.IsNonEmpty)
                        dst.AddEnvironmentVariable(v.Name,v.Value);
                }
            }
        }

        [Op]
        public static CmdProcess process(CmdLine cmd, CmdVars? vars)
        {
            var options = new CmdProcessOptions();
            include(vars, options);
            return new CmdProcess(cmd, options);
        }


        [Op]
        public static CmdProcess process(CmdLine cmd, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions();
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

 

        [MethodImpl(Inline), Op]
        public static CmdProcess start(CmdLine cmd)
            => new CmdProcess(cmd);

        [Op]
        public static CmdProcess start(CmdLine cmd, CmdVars? vars)
        {
            var options = new CmdProcessOptions();
            include(vars, options);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess start(CmdLine cmd, CmdVars? vars, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions();
            include(vars, options);
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess start(CmdLine cmd, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions();
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess start(CmdLine cmd, TextWriter dst)
            => new CmdProcess(cmd, new CmdProcessOptions(dst));

        [Op]
        public static CmdProcess start(CmdLine cmd, TextWriter dst, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions(dst);
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        public static CmdProcess start(FilePath path, CmdKind kind, string args)
            => start(Cmd.cmd(path,kind,args));

        [Op]
        public static CmdProcess start(CmdLine command, CmdProcessOptions config)
            => new CmdProcess(command, config);        
    }
}