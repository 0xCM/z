//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;
    using System.Linq;

    class ArchiveCmd : WfAppCmd<ArchiveCmd>
    {
        public static void copy(IWfChannel channel, CmdArgs args)
            => copy(channel, FS.dir(args[0]), FS.dir(args[1]));
        
        public static Task<ExecToken> copy(IWfChannel channel, FolderPath src, FolderPath dst)
            => ProcExec.launch(channel, FS.path("robocopy.exe"), Cmd.args(src, dst, "/e"));

        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => Archives.symlink(Channel, args);

        [CmdOp("zip")]
        void Zip(CmdArgs args)
            => Archives.zip(Channel, args);

        [CmdOp("copy")]
        void Copy(CmdArgs args)
            => copy(Channel, args);

        [CmdOp("files")]
        void CatalogFiles(CmdArgs args)
            => Archives.catalog(Channel, args);

        [CmdOp("nuget/pkg")]
        void NugetFiles(CmdArgs args)
            => Archives.nupkg(Channel, args);

        [CmdOp("nuget/stage")]
        void DevPack(CmdArgs args)
            => DevPacks.stage(Channel, PackageKind.Nuget, FS.dir(arg(args,0)));

        [CmdOp("files/index")]
        void FileQuery(CmdArgs args)
        {
            var sources = FS.dir(args[0]);
            Archives.index(Channel, Archives.query(sources), EnvDb.Nested("indices", sources));
        }

        [CmdOp("api/servers")]
        void ApiCommandServices()
        {
            var providers = ApiServers.providers(ApiAssemblies.Components);
            var types = providers.ServiceTypes();
            var dst = dict<CmdUri,CmdMethod>();
            iter(types, t => {
                var method = t.StaticMethods().Public().Where(m => m.Name == "create").First();
                var service = (IApiService)method.Invoke(null, new object[]{Wf});
                iter(ApiServers.methods(service).Defs, m => dst.TryAdd(m.Uri, m));
            });

            var methods = dst.Values.ToSeq().Sort();
            iter(methods, m => Channel.Row(m.Uri));
        }
    }
}