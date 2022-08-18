//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class NorFlow<T> : BinaryFlow<NorFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Nor;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => GatedFlows.nor(a,b);
    }
}