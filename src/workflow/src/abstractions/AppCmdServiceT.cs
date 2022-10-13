//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdProvider]
    public abstract class AppCmdService<T> : CmdService<T>, IAppCmdSvc
        where T : AppCmdService<T>, new()
    {
        protected virtual string PromptTitle {get;}

        protected AppCmdService()
        {
            PromptTitle = "cmd";
        }

        string Prompt()
            => string.Format("{0}> ", PromptTitle);

        AppCmdSpec Next()
        {
            var input = term.prompt(Prompt());
            if(Cmd.parse(input, out AppCmdSpec cmd))
            {
                return cmd;
            }
            else
            {
                Error($"ParseFailure:{input}");
                return AppCmdSpec.Empty;
            }
        }

        public virtual void Run()
        {
            var input = Next();
            while(input.Name != ".exit")
            {
                if(input.IsNonEmpty)
                    RunCmd(input);
                input = Next();
            }
        }
   }
}