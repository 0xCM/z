//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class EnvSvc : AppService<EnvSvc>
    {
        public void EmitReports(IDbArchive dst)
        {
            var flow = Channel.Running();
            var src = Env.reports();
            var id = EnvId.Current;
            iter(src, report => Env.emit(Channel,report, dst));
            Channel.Ran(flow);
        }

        public ExecToken EmitReport(EnvVarKind kind, IDbArchive dst)
            => Env.EmitReport(Channel, kind, dst);
    }
}