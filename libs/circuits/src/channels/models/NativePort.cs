//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativePort : INativePort
    {
        readonly Index<NativeChannel> Ins;

        readonly Index<NativeChannel> Outs;

        [MethodImpl(Inline)]
        public NativePort(NativeChannel[] ins, NativeChannel[] outs)
        {
            Ins = ins;
            Outs = outs;
        }

        public ReadOnlySpan<NativeChannel> Inputs
        {
            [MethodImpl(Inline)]
            get => Ins.View;
        }

        public ReadOnlySpan<NativeChannel> Outputs
        {
            [MethodImpl(Inline)]
            get => Outs.View;
        }
    }
}