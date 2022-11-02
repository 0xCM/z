//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static AppEnv.CommandNames;

    using M = AppEnv;

    public class AppEnv : AppService<M>, IWfModule<M>
    {
        public class CommandNames 
        {
            public const string EnvTools = "files/gather";
        }

    
        [CmdOp("env/tools")]
        public void Tools(CmdArgs args)
        {
            var buffer = bag<FilePath>();
            var paths = Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            iter(paths, path => iter(path.Files(FileKind.Exe,false), file => buffer.Add(file)), true);
            var tools = buffer.Array().Sort(new FileNameComparer());
            var counter = 0u;

            var emitter = text.emitter();
            foreach(var tool in tools)
            {               
                var info = string.Format("{0:D5} {1,-36} {2}", counter++, tool.FileName.WithoutExtension, tool); 
                emitter.AppendLine(info);
                Channel.Row(info);
            }

            var dir = Env.cd();
            var file = FS.file($"{dir.FolderName}.tools", FileKind.List);
            var dst = dir + file;
            Channel.FileEmit(emitter.Emit(), dst);
        }

        [Cmd(EnvTools)]
        public record struct ListTools(EnvVarKind kind, FileUri Target);       
    }
}