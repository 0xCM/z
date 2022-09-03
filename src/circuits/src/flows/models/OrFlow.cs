//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class OrFlow<T> : BinaryFlow<OrFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Or;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => GatedFlows.or(a,b);
    }
}