//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using System.Text;

    public class IntelCmd : WfAppCmd<IntelCmd>
    {
        IntelIntrinsics Intrinsics => Wf.IntelIntrinsics();

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

    }
}