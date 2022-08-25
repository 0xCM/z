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
        public static T create(IWfRuntime wf, params ICmdProvider[] src)
        {
            var emitter = wf.Emitter;
            var service = new T();            
            var running = emitter.Running($"Creating {typeof(T).DisplayName()} service with controller ${ExecutingPart.Assembly.GetSimpleName()} with image {FS.path(ExecutingPart.Assembly.Location).ToUri()}");
            service._Providers = src;
            service.Init(wf);
            wf.Babble($"Initialized application command service");
            wf.Babble($"Published commands");
            wf.Ran(running);
            return service;
        }

        protected virtual string PromptTitle {get;}

        ReadOnlySeq<ICmdProvider> _Providers = new();

        protected override void Install(ReadOnlySeq<ICmdProvider> src)
        {
            _Providers = src;
            _Dispatcher = Cmd.dispatcher((T)this, Emitter, src);
        }

        IAppCmdDispatcher _Dispatcher;

        protected AppCmdService()
        {
            PromptTitle = "cmd";
        }

        public override IAppCmdDispatcher Dispatcher
        {
            get => _Dispatcher;
        }

        public ref readonly ReadOnlySeq<ICmdProvider> Providers
        {
            [MethodImpl(Inline)]
            get => ref _Providers;
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
                    Dispatch(input);
                input = Next();
            }
        }
   }
}