//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;

    using K = ApiMdKind;

    public sealed class ApiMd : AppService<ApiMd>
    {
        IDbArchive ApiTargets()
            => AppDb.Service.ApiTargets();

        static IModuleArchive archive(FolderPath root)
            => new ModuleArchive(root);

        static IModuleArchive archive()
            => archive(FS.path(ExecutingPart.Assembly.Location).FolderPath);

        public static Assembly[] parts()
            => data("parts",() => archive().ManagedDll().Where(x => x.FileName.StartsWith("z0")).Map(x => x.Load()).Distinct().Array());

        public Assembly[] Parts
            => parts();

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