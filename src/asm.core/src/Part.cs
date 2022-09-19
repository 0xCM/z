//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.native;
[assembly: PartId(PartId.AsmCore)]
namespace Z0.Parts
{
    public sealed partial class AsmCore : Part<AsmCore>
    {
        public static AsmCoreAssets Assets = new();
    }

    public sealed class AsmCoreAssets : Assets<AsmCoreAssets>
    {
        public Asset StanfordAsmCatalog() => Asset("stanford-asm-catalog.csv");
    }
}
