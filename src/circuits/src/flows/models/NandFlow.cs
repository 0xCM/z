//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class NandFlow<T> : BinaryFlow<NandFlow<T>,T>
        where T : unmanaged
    {
        public override FlowGateKind Kind
            => FlowGateKind.Nand;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => GatedFlows.nand(a,b);
    }
}