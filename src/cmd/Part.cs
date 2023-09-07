//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.ZCmd)]
[assembly: PartName("zcmd")]
namespace Z0.Parts
{
    public sealed class ZCmd : Part<ZCmd>
    {
        [ModuleInitializer]
        internal static void Init()
        {
            //AppData.init();
            NumRender.Service.RegisterFomatters();
        }
    }
}
