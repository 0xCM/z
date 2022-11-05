//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvModule : WfModule<EnvModule>
    {
        protected override Task<ExecToken> Start<C>(C cmd)
        {
            var flow = Channel.Running();
            try
            {
                
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }

            return sys.start(() => Channel.Ran(flow));            
        }

        public class Commands
        {
            [Cmd(EnvNames.EnvTools)]
            public record struct ListTools(EnvVarKind kind, FileUri Target);
        }

        public class Records
        {
            [Cmd(nameof(EnvTool))]
            public record struct EnvTool(uint Seq, string Name, FileUri Path);                
        }    
    }
}