//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CodeLauncher : Launcher<CodeLauncher>
    {
        Task<ExecToken> VsCode<T>(T target, ToolContext context)
            => ProcessLauncher.launch(Channel, FS.path("code.exe"), Cmd.args(target), context);

        static Option<FolderPath> dir(CmdArgs src, string name)
        {
            var result = Option.none<FolderPath>();
            for(var i=0; i<src.Count; i++)
            {
                var arg = src[i];
                if(arg.Name == name)
                {
                    var dir = FS.dir(arg.Value);
                    if(dir.Exists)
                    {
                        result = dir;
                        break;
                    }                    
                }                
            }            
            return result;
        }

        public override void Launch(CmdArgs args, Action<Process> launched)
        {
            var cd = Env.cd();
            var context = ProcessLauncher.context(cd, EnvVars.Empty, launched);
            var token = ExecToken.Empty;
            var wsroot = dir(args,"wsroot");
            if(wsroot)
            {
                VsCode(wsroot.Value, context).Wait();                
            }
            else
            {                
                var launcher = cd + FS.file("develop", FileKind.Cmd);
                if(launcher.Exists)
                    ProcessLauncher.launch(Channel, Cmd.args(launcher), context).Wait(); 
                else
                {
                    var bin = cd + FS.folder("node_modules/.bin");             
                    if(bin.Exists)
                    {
                        var path =  Env.PATH().Value;
                        var j=0;
                        EnvPath result = sys.alloc<FolderPath>(path.Count + 1);
                        result[j++] = bin;
                        for(var i=0; i<path.Count; i++)
                            result[j++] = path[i];

                        Channel.Babble(result.Format());
                        context = ProcessLauncher.context(cd, new EnvVar(EnvTokens.PATH, result.Format()));
                    }
                        
                    var workspaces = cd.Files(FS.ext("code-workspace"));
                    if(workspaces.IsNonEmpty)
                        VsCode(cd + workspaces[0].FileName, context).Wait();
                    else
                        VsCode(cd, context).Wait();
                }
            }
        }
    }
}