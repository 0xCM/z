//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using M = WfEnv;
    using static WfEnv.CommandNames;

    public class WfEnv : WfSvc<M>, IWfModule<M>
    {
        public class CommandNames 
        {
            public const string EnvTools = "files/gather";
        }

        [CmdOp("env/tools")]
        public void Tools()
        {
            var dst = new ConcurrentSet<string>();
            var paths = Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            iter(paths, path => iter(path.Files(FileKind.Exe,false), file => dst.Add(file.ToUri().Format())), true);
            var tools = dst.ToSeq().Sort();
            var counter = 0u;
            foreach(var tool in tools)
                Write(string.Format("{0:D5} {1}", counter++, tool));
        }


        [Cmd(EnvTools)]
        public record struct ListTools(EnvVarKind kind, FileUri Target);
            
    }

}