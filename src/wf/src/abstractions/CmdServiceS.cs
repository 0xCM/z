//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CmdService<S> : WfSvc<S>, ICmdProvider, ICmdService
        where S : CmdService<S>, new()
    {
        public abstract IAppCmdDispatcher Dispatcher {get;}

        [CmdOp("commands")]
        protected void EmitCommands()
            => Cmd.emit(Cmd.catalog(Dispatcher), AppDb.AppData().Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv), Emitter);

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Error(result.Message);
        }

        public void RunCmd(string name, CmdArgs args)
        {
            Dispatcher.Dispatch(name, args);
        }

        public bool Dispatch(AppCmdSpec cmd)
            => Dispatcher.Dispatch(cmd.Name, cmd.Args);

        public void DispatchJobs(FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var content = ref lines[i].Content;
                if(Cmd.parse(content, out AppCmdSpec spec))
                    Dispatch(spec);
                else
                    Warn($"ParseFailure:'{content}'");
            }
        }

        protected abstract void Install(ReadOnlySeq<ICmdProvider> providers);

        void ICmdService.Install(ReadOnlySeq<ICmdProvider> providers)
            => Install(providers);
    }
}