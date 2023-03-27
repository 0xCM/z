// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static sys;
    
//     public class DevShells
//     {
//         public static ExecToken shell(IWfChannel channel, CmdArgs args)
//         {
//             var profile = args[0].Value;
//             var cwd = args.Count > 1 ? FS.dir(args[1]) : Env.cd();
//             return shell(channel, profile, CmdArgs.Empty, cwd);  
//         }

//         [Op]
//         public static ExecToken shell(IWfChannel channel, string profile, CmdArgs args, FolderPath cwd)
//         {
//             var flow = channel.Running($"Launching {profile} shell");
//             var psi = new ProcessStartInfo
//             {
//                 FileName = @"d:\tools\wt\wt.exe",
//                 CreateNoWindow = false,
//                 UseShellExecute = false,
//                 Arguments = $"nt --profile {profile} -d {cwd}",
//                 RedirectStandardError = false,
//                 RedirectStandardOutput = false,
//                 RedirectStandardInput = false,
//             };
//             var process = sys.process(psi);
//             var result = process.Start();
//             var token = ExecToken.Empty;
//             if(!result)
//                 channel.Error("Process creation failed");
//             else
//                 token = channel.Ran(flow, $"Launched {profile} shell: {process.Id}");
//             return token;
//         }
//     }
// }