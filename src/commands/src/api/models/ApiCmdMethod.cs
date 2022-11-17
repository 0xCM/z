
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CmdActorKind;

    public class ApiCmdMethod : IApiCmdMethod
    {
        public readonly ApiOp Op;

        public ApiCmdMethod(Name name, object host, MethodInfo method)
        {
            Op = new ApiOp(name, Cmd.classify(method), Require.notnull(method), Require.notnull(host));
        }

        public ref readonly object Host
        {
            [MethodImpl(Inline)]
            get => ref Op.Host;
        }

        public ref readonly MethodInfo Definiton
        {
            [MethodImpl(Inline)]
            get => ref Op.Definition;
        }

        public ref readonly CmdActorKind ActionKind
        {
            [MethodImpl(Inline)]
            get => ref Op.Kind;
        }

        public ref readonly CmdUri Uri
        {
            [MethodImpl(Inline)]
            get => ref Op.Uri;
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => Op.Host.GetType();
        }

        ApiOp IApiCmdMethod.Def
            => Op;

        public Outcome Run(IWfChannel channel, CmdArgs args)
        {
            var output = default(object);
            var result = Outcome.Success;
            try
            {
                switch(ActionKind)
                {
                    case Pure:
                        Definiton.Invoke(Host, new object[]{});
                        result = Outcome.Success;
                    break;
                    case Receiver:
                        Definiton.Invoke(Host, new object[1]{args});
                        result = Outcome.Success;
                    break;
                    case Emitter:
                        output = Definiton.Invoke(Host, new object[]{});
                    break;
                    case Func:
                        output = Definiton.Invoke(Host, new object[1]{args});
                    break;
                    default:
                        result = new Outcome(false, $"Unsupported {Definiton}");
                    break;
                }

                if(output != null)
                {
                    if(output is bool x)
                        result = Outcome.define(x, output, x ? "Win" : "Fail");
                    else if(output is Outcome y)
                    {
                        result = Outcome.success(y.Data, y.Message);
                        if(sys.nonempty(y.Message))
                        {
                            if(y.Fail)
                                channel.Error(y.Message);
                            else
                                channel.Babble(y.Message);
                        }
                    }
                    else
                        result = Outcome.success(output);
                }
            }
            catch(Exception e)
            {
                var msg = AppMsg.format($"{Uri} invocation error", e);
                var origin = AppMsg.orginate(HostType.DisplayName(), Definiton.DisplayName(), 12);
                var error = Events.error(msg, origin, HostType);
                channel.Error(error);
                result = (e,msg);
            }

           return result;
        }
    }
}