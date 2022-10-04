//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Toolsets : WfSvc<Toolsets>
    {
        public static void help(IWfChannel channel, CmdArgs args, FilePath dst)
        {
            var emitting = channel.EmittingFile(dst);
            var tool = args[0].Value;
            using var status = dst.Utf8Writer(true);
            var cmd = "--help";
            status.WriteLine(RP.PageBreak120);
            status.WriteLine($"# {tool} {cmd}");
            status.WriteLine(RP.PageBreak120);
            var counter = 0u;
            void OnStatus(string msg)
            {
                status.WriteLine(msg);
                counter++;
            }

            void OnError(string msg)
                => channel.Error(msg);

            ProcExec.run(Cmd.args(tool,cmd), new StdIO(OnStatus,OnError), dst.FolderPath);
            channel.EmittedFile(emitting, counter);
        }
    }
}