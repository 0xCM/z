//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Tooling
    {
        [Op]
        public static Task<ExecToken> run(IWfChannel channel, FilePath tool, CmdArgs args, ToolCmdSpec? spec = null)
        {
            var ctx = spec ?? ToolCmdSpec.Default;
            var psi = new ProcessStartInfo
            {
                FileName = tool.Format(),
                Arguments = Cmd.join(args),
                CreateNoWindow = true,
                WorkingDirectory = ctx.WorkingDir.Format(),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = false
            };

            iter(ctx.Vars, v => psi.Environment.Add(v.Name, v.Value));
            
            var token = ExecToken.Empty;
            ExecToken Run()
            {
                try
                {
                    using var process = sys.process(psi);
                    var channeled = channel.ChannelProcess(process, ctx);
                    token = channeled.Run(channel.Running($"Executing '{tool}' with arguments '{args}"));
                    term.cmd();
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
                return token;

            }   
            return sys.start(Run);
        }    

        public static Task<ExecToken> run(IWfChannel channel, CmdArgs args, ToolCmdSpec? spec = null)
            => run(channel, FS.path(args[0]), args.Skip(1), spec);

        static ExecStatus run(ToolCmdSpec context, Action<string> status, Action<string> error)
        {
            var psi = new ProcessStartInfo(context.ToolPath.Format(), context.Args.Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = context.WorkingDir.Format(PathSeparator.BS)
            };

            iter(context.Vars, v => psi.Environment.Add(v.Name, v.Value));

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

            var flow = default(ExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                context.ProcessStart(process);
                flow.StartTime = sys.now();
                flow.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                flow.HasExited = true;
                flow.ExitTime = sys.now();
                flow.Duration = flow.ExitTime - flow.StartTime;
                flow.ExitCode = process.ExitCode;
                context.ProcessExit(process.ExitCode);
            }
            catch(Exception e)
            {
                error(e.ToString());
            }
            return flow;
        }

        static ExecStatus run(ISysIO io, CmdArgs args, ToolCmdSpec context)
        {
            var values = args.Values();
            Demand.gt(values.Count, 0u);
            var name = values.First;
            var path = FS.path(values.First);            
            var psi = new ProcessStartInfo(path.Format(), args.Skip(1).Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = context.WorkingDir.Format(PathSeparator.BS)
            };

            iter(context.Vars, v => psi.Environment.Add(v.Name, v.Value));

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    io.Status(e.Data);
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    io.Error(e.Data);
            }

            var flow = default(ExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                context.ProcessStart(process);
                flow.StartTime = sys.now();
                flow.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                flow.HasExited = true;
                flow.ExitTime = sys.now();
                flow.Duration = flow.ExitTime - flow.StartTime;
                flow.ExitCode = process.ExitCode;
                context.ProcessExit(process.ExitCode);
            }
            catch(Exception e)
            {
                io.Error(e.ToString());
            }
            return flow;
        }

        // public static Task<ExecStatus> start(IToolFlow flow, ToolCmdSpec spec)
        //     => sys.start(() => run(flow, spec));
         
        public static Task<ExecStatus> start(IToolFlow flow, ToolCmd cmd)
            => sys.start(() => run(flow, cmd));

        static ExecStatus run(IToolFlow flow, ToolCmd cmd)
        {
            var i=0u;
            var j=0u;
            var psi = new ProcessStartInfo(cmd.ToolPath.Format(), cmd.Args.Format())
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = cmd.WorkingDir.Format(PathSeparator.BS)
            };

            iter(cmd.Vars, v => psi.Environment.Add(v.Name, v.Value));

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                {
                    inc(ref i);
                    flow.OnStatus((i,e.Data));
                }                    
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                {
                    inc(ref j);
                    flow.OnError((j,e.Data));
                }
            }

            var status = default(ExecStatus);
            var msg = string.Format("{0}:({1})", cmd.ToolPath, cmd.Args.Map(x => text.squote(x.Format())).Delimit());
            var running = flow.Running(msg);
            status.Token = running.Token;
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                flow.OnStart(running.Token);
                status.StartTime = sys.now();
                status.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                status.HasExited = true;
                status.ExitTime = sys.now();
                status.Duration = status.ExitTime - status.StartTime;
                status.ExitCode = process.ExitCode;
                flow.OnFinish(status);
                flow.Ran(running, msg);
            }
            catch(Exception e)
            {
                inc(ref j);
                status.ExitCode = -1;
                flow.OnError((j,e.ToString()));
                flow.OnFinish(status);
            }
            return status;
        }

        // static ExecStatus run(IToolFlow flow, ToolCmdSpec spec)
        // {
        //     var i=0u;
        //     var j=0u;
        //     var tool = spec.ToolPath;
        //     var args = spec.Args;
        //     var psi = new ProcessStartInfo(tool.Format(), args.Format())
        //     {
        //         UseShellExecute = false,
        //         RedirectStandardError = true,
        //         RedirectStandardOutput = true,
        //         ErrorDialog = false,
        //         CreateNoWindow = true,
        //         RedirectStandardInput = false,
        //         WorkingDirectory = spec.WorkingDir.Format(PathSeparator.BS)
        //     };

        //     iter(spec.Vars, v => psi.Environment.Add(v.Name, v.Value));

        //     void OnStatus(object sender, DataReceivedEventArgs e)
        //     {
        //         if(sys.nonempty(e.Data))
        //         {
        //             inc(ref i);
        //             flow.OnStatus((i,e.Data));
        //         }                    
        //     }
    
        //     void OnError(object sender, DataReceivedEventArgs e)
        //     {
        //         if(sys.nonempty(e.Data))
        //         {
        //             inc(ref j);
        //             flow.OnError((j,e.Data));
        //         }
        //     }

        //     var status = default(ExecStatus);
        //     var running = flow.Running($"{tool}:{args}");
        //     status.Token = running.Token;
        //     try
        //     {                
        //         using var process = sys.process(psi);
        //         process.OutputDataReceived += OnStatus;
        //         process.ErrorDataReceived += OnError;
        //         process.Start();
        //         flow.OnStart(running.Token);
        //         status.StartTime = sys.now();
        //         status.Id = process.Id;
        //         process.BeginOutputReadLine();
        //         process.BeginErrorReadLine();
        //         process.WaitForExit();
        //         status.HasExited = true;
        //         status.ExitTime = sys.now();
        //         status.Duration = status.ExitTime - status.StartTime;
        //         status.ExitCode = process.ExitCode;
        //         flow.OnFinish(status);
        //         flow.Ran(running);
        //     }
        //     catch(Exception e)
        //     {
        //         inc(ref j);
        //         status.ExitCode = -1;
        //         flow.OnError((j,e.ToString()));
        //         flow.OnFinish(status);

        //     }
        //     return status;
        // }

    }
}