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

        string IExpr.Format()
        {
            var count = Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }
    }

    [Free]
    public interface IToolCmd<T,C> : IToolCmd, ICmd<C>
        where T : ITool, new()
        where C : ICmd<C>, new()
    {
        new T Tool 
            => new T();

        CmdId ICmd.CmdId
            => CmdId.identify<C>();

        Tool IToolCmd.Tool
            => new (Tool.Name);

        string IToolCmd.Type
            => typeof(T).DisplayName();        

        string IExpr.Format()
        {
            var count = Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }
    }
}