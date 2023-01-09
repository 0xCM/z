//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CodeLauncher : Launcher<CodeLauncher>
    {
        Task<ExecToken> VsCode<T>(T target, CmdContext context)
            => ProcessControl.start(Channel, FS.path("code.exe"), Cmd.args(target), context);

        public override void Launch(CmdArgs args, Action<Process> launched)
        {
            var cd = Env.cd();
            var context = ProcessControl.context(cd);
            var launcher = cd + FS.file("develop", FileKind.Cmd);
            if(launcher.Exists)
                ProcessControl.start(Channel, Cmd.args(launcher), context).Wait(); 
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
                    {
                        result[j++] = path[i];
                    }

                    Channel.Babble(result.Format());
                    context = ProcessControl.context(cd, new EnvVar(EnvTokens.PATH, result.Format()));
                }
                
                var workspaces = cd.Files(FS.ext("code-workspace"));
                if(workspaces.IsNonEmpty)
                {
                    VsCode(cd + workspaces[0].FileName, context);
                }                 
                else
                {
                    VsCode(cd, context);
                }
            }
        }
    }
}