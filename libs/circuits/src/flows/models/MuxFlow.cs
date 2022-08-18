//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class MuxFlow<T> : TernaryFlow<MuxFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Mux;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b, T c)
            => GatedFlows.mux(a,b,c);
    }
}