//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using CCN = CmdContextNames;

    public abstract class CmdService<S> : WfSvc<S>, ICmdProvider, ICmdService
        where S : CmdService<S>, new()
    {
        public IAppCmdDispatcher Dispatcher 
            => AppData.Value<IAppCmdDispatcher>(nameof(IAppCmdDispatcher));

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
            => AppCmd.emit(AppCmd.catalog(Dispatcher), AppDb.AppData().Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv), Emitter);

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

        void ICmdService.Install(ReadOnlySeq<ICmdProvider> src)
            => AppData.Value(nameof(IAppCmdDispatcher), AppCmd.dispatcher((S)this, Emitter, src));

    }
}