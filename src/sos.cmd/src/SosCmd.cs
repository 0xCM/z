//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SosCmd : WfAppCmd<SosCmd>
    {
        ApiMd ApiMd => Wf.ApiMd();

        PdbIndexBuilder PdbIndexBuilder => Wf.PdbIndexBuilder();

        PdbSvc PdbSvc => Wf.PdbSvc();

        // [CmdOp("api/emit/pdb-info")]
        // void EmitApiPdbInfo()
        //     => PdbSvc.EmitPdbInfo(ApiMd.Assemblies.Index().First);

        // [CmdOp("api/emit/pdb-index")]
        // void IndexApiPdbFiles()
        //     => PdbIndexBuilder.IndexComponents(ApiMd.Assemblies, new PdbIndex());

        [CmdOp("sos/symbols")]
        void ReadSymbols()
        {
            var reader = SOS.SymbolReader.create();
            reader.ShowSymbolStore(data => Wf.Data(data));
        }

        void GetMethodInfo()
        {
            // var path = Parts.Lib.Assembly.Location;
            // var catalog = Wf.ApiCatalog.PartCatalogs(PartId.Lib).Single();
            // var methods = catalog.Methods;
            // SOS.SymbolReader.InitializeSymbolReader("");
            // foreach(var method in methods)
            // {
            //     if(SOS.SymbolReader.GetInfoForMethod(path, method.MetadataToken, out var info))
            //     {
            //         var size = info.size;
            //         Wf.Data($"{method.Name} | {size}");
            //     }
            // }
        }
    }
}