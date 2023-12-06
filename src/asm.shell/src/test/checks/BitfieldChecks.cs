//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

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

    [CmdOp("bitcheckers/run")]
    void RunChecks()
    {
        BitCheckers.run(Wf, true);            
    }

    [CmdOp("checkers/run")]
    void CheckBits()
    {
        CheckRunner.create(Wf).Run(PllExec, 
            BitfieldChecks.create(Wf),
            PbChecks.create(Wf)
        );
    }    

    public void Check()
    {
        Targets.Delete();
        BitCheckers.run(Wf);
        var n = n8;
        var count = BitConverters.count(n);
        var convert = BitConverters.converter(n);
        for(var i=0; i<count; i++)
        {
            ref readonly var hex = ref convert.Chars(base16, (ushort)i);
            ref readonly var bin = ref convert.Chars(base2, (ushort)i);
        }
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
            Bitfields.segdef(BF_A.Seg0, NativeSize.W8, 0, 1),
            Bitfields.segdef(BF_A.Seg1, NativeSize.W8, 2, 2),
            Bitfields.segdef(BF_A.Seg2, NativeSize.W8, 3, 5),
            Bitfields.segdef(BF_A.Seg3, NativeSize.W8, 6, 8)
            );

        var emitter = text.emitter();
        var s0 = (byte)0b01_11_10_11;
        var field = Bitfields.create("test",segs,s0);
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
