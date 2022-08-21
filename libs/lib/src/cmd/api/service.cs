//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        public static T service<T>(IWfRuntime wf, ReadOnlySeq<ICmdProvider> src)
            where T : ICmdService, new()
        {
            var emitter = Require.notnull(wf.Emitter);
            var msg = $"Creating {typeof(T).DisplayName()} service with controller {ExecutingPart.Assembly.GetSimpleName()} with image {FS.path(ExecutingPart.Assembly.Location).ToUri()}";
            var service = new T();            
            var running = emitter.Running(msg);
            service.Init(wf);
            service.Install(Require.notnull(src));
            wf.Ran(running);
            return service;
        }
    }
}