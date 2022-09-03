//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AndFlow<T> : BinaryFlow<AndFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.And;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => GatedFlows.and(a,b);
    }
}