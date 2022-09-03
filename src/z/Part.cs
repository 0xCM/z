//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.Z)]
namespace Z0.Parts
{
    public sealed class Z : Part<Z>
    {
        [ModuleInitializer]
        internal static void Init()
        {
            //AppData.init();
            NumRender.Service.RegisterFomatters();
        }
    }
}
