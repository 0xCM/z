//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class OmniScript : AppService<OmniScript>
    {
        public Outcome Run(FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<TextLine> response)
            => ProcessControl.run(
                new CmdLine(src.Format(PathSeparator.BS)),
                vars,
                quiet ? ReceiveCmdStatusQuiet : ReceiveCmdStatus, ReceiveCmdError,
                out response
                );

        public Outcome Run(string content, out ReadOnlySpan<TextLine> response)
            => ProcessControl.run(Cmd.cmd(content), ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(FilePath src, out ReadOnlySpan<TextLine> response)
            => ProcessControl.run(new CmdLine(src.Format(PathSeparator.BS)), CmdVars.Empty, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => ProcessControl.run(cmd, vars, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

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