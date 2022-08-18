//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class XorFlow<T> : BinaryFlow<XorFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Xor;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => GatedFlows.xor(a,b);
    }
}