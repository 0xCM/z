//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SosCmd : WfAppCmd<SosCmd>
    {
        PdbIndexBuilder PdbIndexBuilder => Wf.PdbIndexBuilder();

        PdbSvc PdbSvc => Wf.PdbSvc();

        [CmdOp("sos/symbols")]
        void ReadSymbols()
        {
            var reader = SOS.SymbolReader.create();
            reader.ShowSymbolStore(data => Wf.Data(data));
        }
    }
}