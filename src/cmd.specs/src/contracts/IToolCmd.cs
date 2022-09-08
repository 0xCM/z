//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmd : ICmd
    {
        Tool Tool {get;}
        
        string Type {get;}

        ToolCmdArgs Args 
            => ToolCmdArgs.Empty;
    }

    [Free]
    public interface IToolCmd<T,C> : IToolCmd, ICmd<C>
        where T : ITool, new()
        where C : ICmd<C>, new()
    {
        CmdId ICmd.CmdId
            => CmdId.identify<C>();

        new T Tool => new T();

        Tool IToolCmd.Tool
            => new (Tool.Name);

        string IToolCmd.Type
            => typeof(T).DisplayName();
    }
}