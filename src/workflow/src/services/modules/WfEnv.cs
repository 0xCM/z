//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static WfEnv.CommandNames;

    using M = WfEnv;
    
    public class WfEnv : WfSvc<M>, IWfModule<M>
    {
        public class CommandNames 
        {
            public const string EnvTools = "files/gather";
        }
    
        [CmdOp("env/tools")]
        public void Tools(CmdArgs args)
        {
            var dst = new ConcurrentSet<FilePath>();
            var paths = Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            iter(paths, path => iter(path.Files(FileKind.Exe,false), file => dst.Add(file)), true);
            var tools = dst.ToSeq().Sort();
            var counter = 0u;

            var emitter = text.emitter();
            foreach(var tool in tools)
            {               
                var info = string.Format("{0:D5} {1}", counter++, tool); 
                emitter.AppendLine(info);
                Channel.Row(info);
            }


            Channel.FileEmit(emitter.Emit(),AppDb.Catalogs().Scoped("commands").Path(ExecutingPart.Name.Format(), FileKind.List));
        }

        [Cmd(EnvTools)]
        public record struct ListTools(EnvVarKind kind, FileUri Target);           
    }
}