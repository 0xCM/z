//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct CpuIdDataset
    {
        public readonly ReadOnlySeq<CpuIdSpec> CpuIdSpecs;

        public readonly ReadOnlySeq<InstIsaSpec> InstIsaSpecs;

        public CpuIdDataset(ReadOnlySeq<CpuIdSpec> cpuid, ReadOnlySeq<InstIsaSpec> instisa)
        {
            CpuIdSpecs = cpuid;
            InstIsaSpecs = instisa;
        }
    }
}
