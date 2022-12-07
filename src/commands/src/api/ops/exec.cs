
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CmdActorKind;

    partial class ApiCmd
    {
        public static Outcome exec(IWfChannel channel, ApiEffector effector, CmdArgs args)
        {
            var output = default(object);
            var result = Outcome.Success;
            try
            {
                switch(effector.Kind)
                {
                    case Pure:
                        effector.Definition.Invoke(effector.Host, new object[]{});
                        result = Outcome.Success;
                    break;
                    case Receiver:
                        effector.Definition.Invoke(effector.Host, new object[1]{args});
                        result = Outcome.Success;
                    break;
                    case CmdActorKind.Emitter:
                        output = effector.Definition.Invoke(effector.Host, new object[]{});
                    break;
                    case Func:
                        output = effector.Definition.Invoke(effector.Host, new object[1]{args});
                    break;
                    default:
                        result = new Outcome(false, $"Unsupported {effector.Definition}");
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
                var msg = AppMsg.format($"{effector.Uri} invocation error", e);
                var origin = AppMsg.orginate(effector.HostType.DisplayName(), effector.Definition.DisplayName(), 12);
                var error = Events.error(msg, origin, effector.HostType);
                channel.Error(error);
                result = (e,msg);
            }

           return result;
        }
    }
}