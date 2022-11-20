//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDomain
    {

    }

    public partial class FileFlows
    {
        
    }

    [ApiHost]
    public partial class Tools
    {
        [MethodImpl(Inline), Op]
        public static CmdTool tool(string name)
            => new CmdTool(name);
            
        [MethodImpl(Inline)]
        public static ref readonly T tool<T>()
            where T : Tool<T>, new()
                => ref Tool<T>.Instance;


        public static ref readonly Zsh ztool => ref Zsh.Instance;

        public static ref readonly XedTool xed => ref XedTool.Instance;

        public static ref readonly BdDisasm bddisasm => ref BdDisasm.Instance;

    }

    partial class XTend
    {

    }
}