//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using CCN = CmdContextNames;

    [CmdProvider]
    public abstract class WfAppCmd<T> : WfSvc<T>, IApiCmdSvc
        where T : WfAppCmd<T>, new()
    {
        protected ApiCmd ApiCmd => Wf.ApiCmd();

        protected WfAppCmd()
        {
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

        // [CmdOp("commands")]
        // protected void EmitCommands()
        //     => ApiCmd.emit(Channel, ApiCmd.catalog(), AppDb.AppData().Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));

        public void RunCmd(string name)
            => ApiCmd.RunCmd(name);

        public void RunCmd(string name, CmdArgs args)
            => ApiCmd.RunCmd(name,args);

        protected void RunCmd(ApiCmdSpec cmd)
            => ApiCmd.RunCmd(cmd);

        public virtual void Loop()
            => ApiLoop.start(Channel).Wait();
   }
}