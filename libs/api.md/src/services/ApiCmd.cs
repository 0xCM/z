//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCmd : AppCmdService<ApiCmd>
    {
        ApiMd ApiMd => Wf.ApiMd();

        [CmdOp("api/packs/list")]
        void ListApiPacks()
        {
            var src = ApiPacks.discover();
            for(var i=0; i<src.Count; i++)
            {
                Write($"{i}", src[i].Timestamp);
            }
        }

        [CmdOp("api/pack/list")]
        Outcome ListApiPack(CmdArgs args)
        {
            var result = Outcome.Failure;
            var src = ApiPacks.discover();
            var pack = default(IApiPack);
            if(args.Count > 0)
            {
                result = DataParser.parse(arg(args,0), out int i);
                if(result)
                {
                    var count = src.Length;
                    if(i<count-1)
                    {
                        pack = src[i];
                        result = true;
                    }
                }
            }
            else
            {
                if(src.Count >= 0)
                {
                    pack = src.Last;
                    result = true;
                }
            }

            if(result)
            {
                var listing = ListedFiles.listing(pack.Files());
                var dst = AppDb.AppData().PrefixedTable<ListedFile>($"api.pack.{pack.Timestamp}");
                TableEmit(listing, dst);
            }

            return result;
        }


        // [CmdOp("api/emit/deps")]
        // void EmitApiDeps()
        //     => ApiMd.Emitter().EmitApiDeps();

        // [CmdOp("api/emit/literals")]
        // void EmitApiLiterals()
        //     => ApiMd.Emitter().EmitApiLiterals();

        // [CmdOp("api/emit/cmddefs")]
        // void EmitCmdDefs()
        //     => ApiMd.Emitter().EmitCmdDefs();

        // [CmdOp("api/emit/tokens")]
        // void EmitApiTokens()
        //     => ApiMd.Emitter().EmitApiTokens();

        // [CmdOp("api/emit/types")]
        // void EmitDataTypes()
        //     => ApiMd.Emitter().EmitDataTypes();
            
        [CmdOp("api/emit/impls")]
        void EmitImplMaps()
        {
            var src = Clr.impls(Z0.Parts.Lib.Assembly, Z0.Parts.Lib.Assembly);
            using var writer = AppDb.ApiTargets().Path("api.lib", FileKind.ImplMap).Utf8Writer();
            for(var i=0; i<src.Count; i++)
                src[i].Render(s => writer.WriteLine(s));
        }

        // [CmdOp("api/emit/heap")]
        // void ApiEmitHeaps()
        //     => ApiMd.Emitter().EmitHeap(Heaps.load(ApiMd.SymLits));

        // [CmdOp("api/emit/tables")]
        // void EmitApiTables()
        //     => ApiMd.Emitter().EmitApiTables();

        // [CmdOp("api/emit/symbols")]
        // void EmitApiSymbols()
        //     => ApiMd.Emitter().EmitApiSymbols();

        // [CmdOp("api/emit/partlist")]
        // void Parts()
        //     => ApiMd.Emitter().EmitPartList();

        // [CmdOp("api/emit/comments")]
        // void ApiEmitComments()
        //     => ApiMd.Emitter().EmitApiComments();
    }
}