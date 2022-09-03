//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FlowGateInfo
    {
        public readonly FlowGateKind Kind;

        public readonly byte PinWidth;

        public readonly byte InputCount;

        public readonly byte OutputCount;

        [MethodImpl(Inline)]
        public FlowGateInfo(FlowGateKind kind, byte width, byte ins, byte outs)
        {
            Kind = kind;
            InputCount = ins;
            OutputCount = outs;
            PinWidth = width;
        }
    }
}