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
        

        CmdArgs Args 
            => CmdArgs.Empty;

        string IExpr.Format()
        {
            var count = Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                var arg = Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }
    }
}