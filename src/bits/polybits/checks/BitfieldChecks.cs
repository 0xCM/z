//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class BitfieldChecks : Checker<BitfieldChecks>
    {
        enum BF_A : byte
        {
            [Symbol("seg0")]
            Seg0 = 0,

            [Symbol("seg1")]
            Seg1 = 1,

            [Symbol("seg2")]
            Seg2 = 2,

            [Symbol("seg3")]
            Seg3 = 3
        }

        public void Run(IWfEventTarget log)
        {
            var segs = array(
                PolyBits.seg(BF_A.Seg0, 0, 1, Bitfields.mask(Bitfields.segwidth(0,1), 0)),
                PolyBits.seg(BF_A.Seg1, 2, 2, Bitfields.mask(Bitfields.segwidth(2,2), 2)),
                PolyBits.seg(BF_A.Seg2, 3, 5, Bitfields.mask(Bitfields.segwidth(3,5), 3)),
                PolyBits.seg(BF_A.Seg3, 6, 8, Bitfields.mask(Bitfields.segwidth(6,8), 6))
                );

            var emitter = text.emitter();
            var s0 = (byte)0b01_11_10_11;
            var field = Bitfields.create(PolyBits.origin(typeof(BF_A)), "test",segs,s0);
            var specs = field.SegSpecs;
            var count = specs.Length;
            emitter.Append("[");
            for(byte i=0; i<count; i++)
            {
                ref readonly var seg = ref skip(specs,i);
                var state = field.Extract(i);
                var j=0u;

                var bitstring = BitRender.gformat(state, (byte)seg.Width);
                emitter.Append(string.Format("{0}={1}",seg.Format(), bitstring));
                if(i !=count -1)
                    emitter.Append(" | ");
            }
            emitter.Append("]");

            log.Deposit(Events.row(emitter.Emit()));
        }

        protected override void Execute(IWfEventTarget log)
        {
            Run(log);
        }
    }
}