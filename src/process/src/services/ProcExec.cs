//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed partial record class ProcExec
    {

        static AppDb AppDb => AppDb.Service;

        [Op]
        public static ProcessAdapter start(ProcessStartSpec spec)
            => Process.Start(spec);


        public static ExecToken run(FilePath src, FilePath dst, WfEmit channel, bool babble = true)
            => run(Cmd.args(src), dst, channel);

        public static ExecToken run(CmdArgs spec, FilePath dst, WfEmit channel, bool babble = true)
        {
            var running = channel.Running($"Executing command '{spec}");
            var token = ExecToken.Empty;
            var buffer = list<string>();
            buffer.Add($"# {spec}");

            void OnData(string src)
            {
                if(nonempty(src))
                {
                    buffer.Add(src);
                    if(babble)
                        channel.Row(src);
                }
            }

            void OnError(string src)
            {
                if(nonempty(src))
                    buffer.Add(src);                
                channel.Error(src);
            }

            try
            {
                var outcome = run(spec, OnData, OnError);
                var @event = outcome.ExitCode != 0 ? 
                    (IWfEvent)Events.error(typeof(CmdScript), $"Process exited with code {outcome.ExitCode}") 
                    : (IWfEvent)Events.babble(typeof(CmdScript), $"Process completed:{outcome}");

                channel.Raise(@event);
                channel.FileEmit(text.join('\n', buffer.ViewDeposited()), dst);                
                token = channel.Ran(running);
            }
            catch(Exception e)
            {
                token = channel.Ran(running,e);
            }
            return token;            
        }

        public static CmdExecStatus run(CmdArgs spec, Action<string> status, Action<string> error)
        {
            var values = spec.Values();
            var name = values.First;
            var args = values.ToSpan().Slice(1).ToArray();
            var psi = new ProcessStartInfo(values.First, text.join(Chars.Space,args))
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = Environment.CurrentDirectory
            };

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    status(e.Data);
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    error(e.Data);
            }

            var outcome = default(CmdExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                outcome.StartTime = sys.now();
                outcome.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExitAsync().Wait();                
                outcome.HasExited = true;
                outcome.ExitTime = sys.now();
                outcome.Duration = (ulong)outcome.ExitTime - (ulong)outcome.StartTime;
                outcome.ExitCode = process.ExitCode;
            }
            catch(Exception e)
            {
                error(e.ToString());
            }
            return outcome;
        }

        [MethodImpl(Inline), Op]
        public static CmdScript script(string name, CmdScriptExpr src)
            => new CmdScript(name, src);

        public static CmdLine cmdline(FilePath src)
        {
            if(src.Is(FileKind.Cmd))
                return cmd(src);
            else if(src.Is(FileKind.Ps1))
                return pwsh(src);
            else
                return sys.@throw<CmdLine>();
        }

        [Op]
        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        [Op]
        public static bool arg(ToolCmdArgs src, string name, out ToolCmdArg dst)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src[i];
                if(string.Equals(arg.Name, name, NoCase))
                {
                    dst=arg;
                    return true;
                }
            }
            dst = ToolCmdArg.Empty;
            return false;
        }
    }
}