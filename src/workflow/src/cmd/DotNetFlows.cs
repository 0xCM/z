//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System.Linq;

    using static sys;

    public sealed class DotNetFlows : WfAppCmd<DotNetFlows>
    {
        public static IEnumerable<IDbArchive> sdks(IDbArchive root)
            => from f in root.Folders(true, ".dotnet") select f.DbArchive();
            
        public static Task<ExecToken> sdkmerge(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var src = FS.archive(args[0]);
                var dotnet = src.Path("dotnet", FileKind.Exe);
                var token = ExecToken.Empty;
                if(!dotnet.Exists)
                {
                    channel.Error($"Not found:{dotnet}");
                }
                else
                {
                    token = ArchiveFlows.copy(channel, src, AppSettings.Publications("dotnet/root")).Result;
                }
                return token;
            }
            return sys.start(Run);
        }

        [CmdOp("dotnet/sdks/merge")]
        void SdkMerge(CmdArgs args)
            => sdkmerge(Channel,args);
        
        [CmdOp("dotnet/sdks/list")]
        void DotNetSdks(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var counter = 0u;
            iter(sdks(src),root => {
                Channel.Row(root.Format());
                counter++;
            });

            if(counter == 0)
            {
                Channel.Warn($"No sdks were foundf in {src}");
            }
        }
    }
}
