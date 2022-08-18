//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    
    [Free]
    public unsafe class MemCmd : CmdService<MemCmd>
    {
        ImageRegions Regions => Wf.ImageRegions();

        IApiPack Dst => ApiPacks.create();

        [CmdOp("memory/regions")]
        void EmitRegions()
            => Regions.EmitRegions(Process.GetCurrentProcess(), Dst);

        [CmdOp("env/modules")]
        void ListModules()
        {
            var src = ImageMemory.modules(ExecutingPart.Process);
            var dst = AppDb.App().Targets(tables).Path($"process.modules.{timestamp()}", FileKind.Csv);
            var formatter = Tables.formatter<ProcessModuleRow>();
            for(var i=0; i<src.Length; i++)
                Row(formatter.Format(src[i]));
            TableEmit(src, dst);
        }

        // [CmdOp("api/emit/impls")]
        // void EmitImplMaps()
        // {
        //     var src = Clr.impls(Parts.Lib.Assembly, Parts.Lib.Assembly);
        //     using var writer = AppDb.ApiTargets().Path("api.impl.maps", FileKind.Map).Utf8Writer();
        //     for(var i=0; i<src.Count; i++)
        //         src[i].Render(s => writer.WriteLine(s));
        // }
    }
}