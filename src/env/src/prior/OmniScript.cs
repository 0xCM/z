//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class OmniScript : AppService<OmniScript>
    {
        public Outcome Run(FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<TextLine> response)
            => CmdProcess.run(
                new CmdLine(src.Format(PathSeparator.BS)),
                vars,
                quiet ? ReceiveCmdStatusQuiet : ReceiveCmdStatus, ReceiveCmdError,
                out response
                );

        [Op]
        static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        public Outcome Run(string content, out ReadOnlySpan<TextLine> response)
            => CmdProcess.run(cmd(content), ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(FilePath src, out ReadOnlySpan<TextLine> response)
            => CmdProcess.run(new CmdLine(src.Format(PathSeparator.BS)), CmdVars.Empty, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => CmdProcess.run(cmd, vars, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        void ReceiveCmdStatusQuiet(in string src)
        {

        }

        void ReceiveCmdStatus(in string src)
        {
            Channel.Write(src);
        }

        void ReceiveCmdError(in string src)
        {
            Channel.Write(src, FlairKind.Error);
        }
    }
}