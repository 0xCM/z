//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CmdRunner
    {
        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args, CmdContext? context = null)
            => start(channel, FS.path(args[0]), args.Skip(1), context);

        [Op]
        public static Task<ExecToken> start(IWfChannel channel, FilePath path, CmdArgs args, CmdContext? context = null)
        {
            void OnStatus(DataReceivedEventArgs e)
            {
                if(e != null && nonempty(e.Data))
                    channel.Row(e.Data);
            }

            void OnError(DataReceivedEventArgs e)
            {
                if(e != null && nonempty(e.Data))
                    channel.Error(e.Data);                
            }

            var info = new ProcessStartInfo
            {
                FileName = path.Format(),
                Arguments = Cmd.join(args),
                CreateNoWindow = true,
                WorkingDirectory = context?.WorkingDir.Format() ?? Environment.CurrentDirectory,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = false
            };

            var ctx = context ?? CmdContext.Default;
            iter(ctx.EnvVars, v => info.Environment.Add(v.Name, v.Value));

            var cmdline = new CmdLine($"{info.FileName} {info.Arguments}");
            var ts = Timestamp.Zero;
            var token = ExecToken.Empty;
            var executing = ExecutingProcess.Empty;

            ExecToken Run()
            {
                try
                {
                    using var process = new Process {StartInfo = info};
                    process.OutputDataReceived += (s,d) => OnStatus(d);
                    process.ErrorDataReceived += (s,d) => OnError(d);
                    var flow = channel.Running(cmdline);
                    process.Start();
                    executing = new (cmdline, process);
                    ProcessState.enlist(executing);
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    channel.Babble($"Enlisted process {process.Id}");
                    process.WaitForExit();
                    ts = now();
                    token = channel.Ran(flow, $"Process {process.Id} finished");
                    term.cmd();
                    ProcessState.remove(new (executing, ts, token));
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
                return token;

            }   
            return sys.start(Run);
        }    
    }
}
