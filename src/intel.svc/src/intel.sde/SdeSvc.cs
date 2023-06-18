//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public class SdeSvc : WfSvc<SdeSvc>
    {
        CpuIdSvc CpuId => Wf.CpuId();

        public void RunEtl()
        {
            var sources = AppDb.DbIn("intel").Sources("sde.cpuid");
            var targets = AppDb.AsmDb("sde");
            var src = CpuId.Import(
            sources.Root,
            targets.Path("sde.cpuid.records", FileKind.Csv),
            targets.Path("sde.cpuid.bits", FileKind.Csv)
            );
        }
    }
}