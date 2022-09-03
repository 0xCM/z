//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class XnorFlow<T> : BinaryFlow<XnorFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Xnor;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => GatedFlows.xnor(a,b);
    }
}