//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        [Op]
        public static async Task<int> start(ToolCmdSpec cmd, CmdContext context, Action<string> status, Action<string> error)
        {
            var info = new ProcessStartInfo
            {
                FileName = cmd.Tool.Format(),
                Arguments = cmd.Format(),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            var process = new Process {StartInfo = info};

            if (!context.WorkingDir.IsNonEmpty)
                process.StartInfo.WorkingDirectory = context.WorkingDir.Name;

            iter(context.EnvVars, v => process.StartInfo.Environment.Add(v.Name, v.Value));
            process.OutputDataReceived += (s,d) => status(d.Data ?? EmptyString);
            process.ErrorDataReceived += (s,d) => error(d.Data ?? EmptyString);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return await wait(process);

            static async Task<int> wait(Process process)
            {
                return await Task.Run(() => {
                    process.WaitForExit();
                    return Task.FromResult(process.ExitCode);
                });
            }
        }
    }
}