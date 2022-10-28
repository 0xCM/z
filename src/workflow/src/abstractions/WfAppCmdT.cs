//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using CCN = CmdContextNames;

    [CmdProvider]
    public abstract class WfAppCmd<T> : WfSvc<T>, IAppCmdSvc
        where T : WfAppCmd<T>, new()
    {
        public IWfDispatcher Dispatcher 
            => AppData.Value<IWfDispatcher>(nameof(IWfDispatcher));

        protected virtual string PromptTitle {get;}

        protected WfAppCmd()
        {
            PromptTitle = "cmd";
        }

        string Prompt()
            => string.Format("{0}> ", PromptTitle);

        AppCmdSpec Next()
        {
            var input = term.prompt(Prompt());
            if(WfCmd.parse(input, out AppCmdSpec cmd))
            {
                return cmd;
            }
            else
            {
                Error($"ParseFailure:{input}");
                return AppCmdSpec.Empty;
            }
        }

        [CmdOp(CCN.db)]
        protected void SetDbContext(CmdArgs args)
        {
            const string Name = CCN.db;
            if(args.Count != 0)
                ContextValue(Name, args.First);
            Channel.Write($"{Name}={ContextValue(Name)}");
        }

        [CmdOp(CCN.fs)]
        protected void SetFsContext(CmdArgs args)
        {
            const string Name = CCN.fs;
            if(args.Count != 0)
                ContextValue(Name, args.First);
            Channel.Write($"{Name}={ContextValue(Name)}");
        }

        [CmdOp(CCN.sln)]
        protected void SetSlnContext(CmdArgs args)
        {
            const string Name = CCN.sln;
            if(args.Count != 0)
                ContextValue(Name, args.First);
            Channel.Write($"{Name}={ContextValue(Name)}");
        }

        [CmdOp("commands")]
        protected void EmitCommands()
            => WfCmd.emit(Channel, WfCmd.catalog(Dispatcher), AppDb.AppData().Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Error(result.Message);
        }

        public void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        protected void RunCmd(AppCmdSpec cmd)
        {
            try
            {
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                Channel.Error(e);
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