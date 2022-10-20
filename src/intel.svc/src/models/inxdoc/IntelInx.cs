//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using System.Text;
    using dsl.intel;

    public class IntelInxCmd : WfAppCmd<IntelInxCmd>
    {
        IntelInx Intrinsics => Wf.IntelIntrinsics();

        IntelSdm Sdm => Wf.IntelSdm();

        XedRuntime Xed => GlobalServices.Instance.Injected<XedRuntime>();

        SdeSvc Sde => Wf.SdeSvc();

        [CmdOp("intel/etl")]
        void ImportIntrinsics()
        {
            Intrinsics.RunEtl();
            Sdm.RunEtl();
            Sde.RunEtl();
            Xed.Start();
            Xed.RunEtl();
        }

        public static TextEncoding encoding()
            => new TextEncoding(Encoding.UTF8);

        [CmdOp("intel/int/algs")]
        void EmitAlgs()
        {
            var asset = IntrinsicAssets.AssetData.Algorithms();
            Utf8.decode(asset.ResBytes, out var doc);
            FileEmit(doc, AppDb.DbTargets("intrinsics").Path("algs",FileKind.Txt), TextEncodingKind.Utf8);
        }
    }
}