//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;

    public class SdeSvc : WfSvc<SdeSvc>
    {
        SdeCpuid SdeCpuid => Wf.CpuId();

        ReadOnlySeq<CpuIdRow> VerifyEquality(ReadOnlySeq<CpuIdRow> left, ReadOnlySeq<CpuIdRow> right)
        {
            var running = Channel.Running($"Verifying import process");
            var count = Require.equal(left.Count, right.Count);
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref left[i];
                ref readonly var b = ref right[i];
                var record = Require.equal(a,b);
            }
            Channel.Ran(running,$"Verified import process for {count} records");
            return left;
        }

        public void RunEtl()
        {
            var import = SdeCpuid.Import();
            var imported = SdeCpuid.Imported();
            var verified = VerifyEquality(import,imported);
        }
    }
}