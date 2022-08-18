//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Record(TableId)]
    public struct CpuFeature
    {
        public const string TableId = "llvm.cpu.feature";

        [Render(8)]
        public uint Seq;

        [Render(16)]
        public string Processor;

        [Render(16)]
        public string FeatureName;
    }
}
