//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class NotFlow<T> : UnaryFlow<NotFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Not;

        [MethodImpl(Inline)]
        public override T Flow(T a)
            => GatedFlows.not(a);
    }
}