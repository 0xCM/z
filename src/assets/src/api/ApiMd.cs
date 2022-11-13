//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using K = ApiMdKind;

    public sealed class ApiMd : AppService<ApiMd>
    {
        IDbArchive ApiTargets()
            => AppDb.Service.ApiTargets();

        public static Assembly[] parts()
            => ModuleArchives.parts();

        public Assembly[] Parts
            => ModuleArchives.parts();

        public Index<Type> ApiTableTypes
            => data(K.ApiTables, () => Parts.Types().Tagged<RecordAttribute>().Index());

        ReadOnlySeq<IApiHost> CalcApiHosts()
        {
            var dst = sys.bag<IApiHost>();
            iter(Parts, a => iter(ApiRuntime.hosts(a), h => dst.Add(h)), PllExec);
            return dst.Array();
        }

        public ReadOnlySeq<IApiHost> ApiHosts
            => data(K.ApiHosts, CalcApiHosts);

        public new ApiMdEmitter Emitter()
            => ApiMdEmitter.init(Wf);
    }
}