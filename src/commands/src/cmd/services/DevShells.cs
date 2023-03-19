//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class DevShells
    {
        public static void start(IWfChannel channel, CmdArgs args)
        {
            var profile = args[0].Value;
            var cwd = args.Count > 1 ? FS.dir(args[1]) : Env.cd();
            start(channel, profile, CmdArgs.Empty, cwd);  
        }

        public static EnvVars vars()
            => Env.merge(Env.vars(EnvVarKind.Machine), Env.vars(EnvVarKind.User));

        [Op]
        public static void start(IWfChannel channel, string profile, CmdArgs args, FolderPath cwd)
        {
            var flow = channel.Running($"Launching {profile} shell");
            var psi = new ProcessStartInfo
            {
                FileName = @"d:\tools\wt\wt.exe",
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = $"nt --profile {profile} -d {cwd}",
                RedirectStandardError = false,
                RedirectStandardOutput = false,
                RedirectStandardInput = false,
            };
            // psi.Environment.Clear();            
            // iter(vars(), v => psi.Environment.Add(v.Name, v.Value));
            var process = sys.process(psi);
            var result = process.Start();
            if(!result)
                channel.Error("Process creation failed");
            else
            {
                channel.Ran(flow, $"Launched {profile} shell: {process.Id}");
                

            }
        }
    }
}