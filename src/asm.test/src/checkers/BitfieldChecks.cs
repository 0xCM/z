//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ApiAtomic;

    public class CheckRunner : WfSvc<CheckRunner>
    {
        IEventTarget Target => Checkers.target(Wf.Channel);

        public void Run(bool pll, params IChecker[] src)
        {
            iter(src, checker => checker.Run(pll, Target), pll);
        }
    }

    [ApiHost]
    public class BitfieldChecks : Checker<BitfieldChecks>
    {
        DbArchive Targets => AppDb.DbOut().Targets(polybits);

        public void Check()
        {
            Targets.Delete();
            BitCheckers.run(Wf);
            var n = n8;
            var count = Numbers.count(n);
            var convert = BitConverters.converter(n);
            for(var i=0; i<count; i++)
            {
                ref readonly var hex = ref convert.Chars(base16, (ushort)i);
                ref readonly var bin = ref convert.Chars(base2, (ushort)i);
            }
        }

        public static ByteSpanSpec GenBits(W8 w, byte start = 0, byte end = byte.MaxValue)
        {
            var blocks = PolyBits.BitBlocks(w,start, end);
            var count = blocks.Count;
            var buffer = alloc<ByteSpanSpec>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = ByteSpans.specify(string.Format("Block{0:X2}", i), @bytes(blocks[i].Data).ToArray());
            var merge = ByteSpans.merge("CharBytes", buffer);
            var seg = merge.Segment(16,16);
            var chars = recover<char>(seg);
            return merge;
        }


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

        public void Run(IEventTarget log)
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

        protected override void Execute(IEventTarget log)
        {
            Run(log);
        }
    }
}