//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class OmniScript : WfSvc<OmniScript>
    {
        public Outcome Run(FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<TextLine> response)
            => ProcExec.run(
                new CmdLine(src.Format(PathSeparator.BS)),
                vars,
                quiet ? ReceiveCmdStatusQuiet : ReceiveCmdStatus, ReceiveCmdError,
                out response
                );

        public Outcome Run(string content, out ReadOnlySpan<TextLine> response)
            => ProcExec.run(Cmd.cmd(content), ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(FilePath src, out ReadOnlySpan<TextLine> response)
            => ProcExec.run(new CmdLine(src.Format(PathSeparator.BS)), CmdVars.Empty, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => ProcExec.run(cmd, vars, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        void ReceiveCmdStatusQuiet(in string src)
        {

        }

        void ReceiveCmdStatus(in string src)
        {
            Write(src);
        }

        void ReceiveCmdError(in string src)
        {
            Write(src, FlairKind.Error);
        }
    }
}