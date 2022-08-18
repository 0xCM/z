//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = CpuWorkers;

    public struct CpuCycleInfo : ITextual
    {
        public uint CpuCore;

        public uint WorkerId;

        public ulong MaxCycles;

        public ulong CompletedCycles;

        public ulong CpuUsage;

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();
    }
}