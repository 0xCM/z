//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.Shell)]
namespace Z0.Parts
{
    public sealed class Shell : Part<Shell>
    {
        [ModuleInitializer]
        internal static void Init()
        {
            NumRender.Service.RegisterFomatters();
        }
    }
}
