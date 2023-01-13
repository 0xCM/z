//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using System.Text;
    using dsl.intel;

    public class IntelCmd : WfAppCmd<IntelCmd>
    {
        IntelIntrinsics Intrinsics => Wf.IntelIntrinsics();

        IntelSdm Sdm => Wf.IntelSdm();

        XedRuntime Xed => GlobalServices.Instance.Injected<XedRuntime>();

        SdeSvc Sde => Wf.SdeSvc();

        [CmdOp("intel/inx")]
        void RunInxEtl()
        {
            var paths = Intrinsics.Paths();
            var xml = Intrinsics.LoadSourceDoc(paths);
            var defs = Intrinsics.ParseSouceDoc(xml);
            Intrinsics.EmitAlgorithms(paths, defs);
            var records = Intrinsics.EmitRecords(paths, defs);
        }


        [CmdOp("intel/etl")]
        void ImportIntrinsics()
        {
            Intrinsics.RunEtl(Intrinsics.Paths());
            Sdm.RunEtl();
            Sde.RunEtl();
            Xed.Start();
            Xed.RunEtl();
        }

        public static TextEncoding encoding()
            => new TextEncoding(Encoding.UTF8);

    }
}