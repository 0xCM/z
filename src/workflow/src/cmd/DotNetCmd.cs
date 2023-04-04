//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;
    using static Workflows;

    sealed class DotNetCmd : WfAppCmd<DotNetCmd>
    {
        [CmdOp("dotnet/sdks/merge")]
        void SdkMerge(CmdArgs args)
            => sdkmerge(Channel,args).Wait();
        
        [CmdOp("dotnet/sdks/list")]
        void ListSdks(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var counter = 0u;
            iter(DotNetSdks(src),root => {
                Channel.Row(root.Format());
                counter++;
            });

            if(counter == 0)
            {
                Channel.Warn($"No sdks were found in {src}");
            }
        }
    }
}
