//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class DemuxFlow<T> : GatedFlow<DemuxFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Nand;

        [MethodImpl(Inline)]
        public Pair<T> Flow(T a, T b)
            => GatedFlows.demux(a,b);
    }
}