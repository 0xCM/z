//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvMod.Commands;

    public class EnvMod : WfModule<EnvMod>
    {
        protected override Task<ExecToken> Start<C>(C cmd)
        {
            var flow = Channel.Running();
            try
            {
                switch(cmd)
                {
                    case ListTools spec:
                        
                    break;

                }
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }

            return sys.start(() => Channel.Ran(flow));            
        }

        [LiteralProvider(env)]
        public class Names
        {
            public const string EnvTools = "env/tools";
        }

        public class Commands
        {
            [Cmd(Names.EnvTools)]
            public record struct ListTools(EnvVarKind kind, FileUri Target);
        }

        public class Records
        {
            [Cmd(nameof(EnvTool))]
            public record struct EnvTool(uint Seq, string Name, FileUri Path);                
        }    
    }
}