//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class AsmOpCodes
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct MapName
    {
        public readonly asci2 Indicator;

        public readonly asci4 Selector;

        public readonly asci8 Depictor;

        [MethodImpl(Inline)]
        public MapName(asci2 indicator, asci4 selector, asci8 depictor)
        {
            Indicator = indicator;
            Selector = selector;
            Depictor = depictor;
        }

        public string Format()
            => Depictor.Format();

        public override string ToString()
            => Format();
    }
}
