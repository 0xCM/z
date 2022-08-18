
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CmdActorKind;

    public class AppCmdRunner : IAppCmdRunner
    {
        public static CmdActorKind classify(MethodInfo src)
        {
            var dst = CmdActorKind.None;
            var arity = src.ArityValue();
            var @void = src.HasVoidReturn();
            switch(arity)
            {
                case 0:
                    switch(@void)
                    {
                        case false:
                            dst = CmdActorKind.Pure;
                        break;
                        case true:
                            dst = CmdActorKind.Emitter;
                        break;
                    }
                break;
                case 1:
                    switch(@void)
                    {
                        case true:
                            dst = CmdActorKind.Receiver;
                        break;
                        case false:
                            dst = CmdActorKind.Func;
                        break;
                    }
                break;
            }
            return dst;
        }

        public readonly AppCmdDef Def;

        public AppCmdRunner(string name, object host, MethodInfo method)
        {
            Def = new AppCmdDef(name, classify(method), Require.notnull(method), Require.notnull(host));
        }

        public ref readonly object Host
        {
            [MethodImpl(Inline)]
            get => ref Def.Host;
        }

        public ref readonly MethodInfo Method
        {
            [MethodImpl(Inline)]
            get => ref Def.Method;
        }

        public ref readonly CmdActorKind ActionKind
        {
            [MethodImpl(Inline)]
            get => ref Def.Kind;
        }

        public ref readonly CmdUri Uri
        {
            [MethodImpl(Inline)]
            get => ref Def.Uri;
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => Def.Host.GetType();
        }

        AppCmdDef IAppCmdRunner.Def
            => Def;

        public Outcome Run(CmdArgs args, WfEmit channel)
        {
            var output = default(object);
            var result = Outcome.Success;
            try
            {
                switch(ActionKind)
                {
                    case Pure:
                        Method.Invoke(Host, new object[]{});
                        result = Outcome.Success;
                    break;
                    case Receiver:
                        Method.Invoke(Host, new object[1]{args});
                        result = Outcome.Success;
                    break;
                    case Emitter:
                        output = Method.Invoke(Host, new object[]{});
                    break;
                    case Func:
                        output = Method.Invoke(Host, new object[1]{args});
                    break;
                    default:
                        result = new Outcome(false, $"Unsupported {Method}");
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
                var origin = AppMsg.orginate(HostType.DisplayName(), Method.DisplayName(), 12);
                var error = Events.error(msg, origin, HostType);
                channel.Error(error);
                result = (e,msg);
            }

           return result;
        }
    }
}