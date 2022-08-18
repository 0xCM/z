//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public QueueCmd QueueCmd(IWfRuntime wf)
                => Service<QueueCmd>(wf);
        }

        static Svc Services = Svc.Instance;

        public static QueueCmd QueueCmd(this IWfRuntime wf)
            => Services.QueueCmd(wf);
    }
}
