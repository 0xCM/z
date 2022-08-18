//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    [ApiHost]
    public class CalcBuilder : AppService<CalcBuilder>
    {
        public static ClassChecks Checks(IWfRuntime wf) => ClassChecks.create(wf);

        public class ClassChecks : Checker<ClassChecks>
        {
            public void CheckSymNames()
            {
                var result = Outcome.Success;
                var classifier = Classifiers.classifier<AsciLetterLoSym,byte>();
                var symbols = Symbols.index<AsciLetterLoSym>();
                var classes = classifier.Classes;
                var count = classes.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var c = ref skip(classes,i);
                    ref readonly var s = ref symbols[i];
                    Z0.Require.equal(c.Index, i);
                    Z0.Require.equal(s.Key.Value, c.Index);
                    Z0.Require.equal(s.Expr.Format(), c.Symbol.Format());
                    Z0.Require.equal(s.Name, c.Name.Format());
                }
            }
        }

        const NumericKind Closure = Integers;

        PageBank16x4x4 PageBlocks;

        ByteSize BlockSize;

        public CalcBuilder()
        {
            PageBlocks = PageBank16x4x4.allocated();
            BlockSize = PageBank16x4x4.BlockSize;
        }

        public void Calc(W128 w)
        {
            var flow = Wf.Running(w.ToString());
            var size = RunCalc(w);
            Wf.Ran(flow, size);
        }

        [Op]
        ByteSize RunCalc(W128 w)
        {
            var sizes = 0ul;
            var cells = BlockSize/w.DataSize;
            ref var left = ref PageBlocks.Block(n0).Segment<Cell128>(0);
            ref var right = ref PageBlocks.Block(n1).Segment<Cell128>(1);
            ref var target = ref PageBlocks.Block(n2).Segment<Cell128>(2);
            var f = Calcs.vor<uint>(w);
            for(var i=0u; i<cells; i++)
            {
                ref var a = ref seek(left,i);
                a = cpu.vbroadcast(w,i);
                ref var b = ref seek(right,i);
                b = cpu.vbroadcast(w,i + Pow2.T12);
                seek(target,i) = f.Invoke(a,b);
                sizes += 3*16;
            }
            return sizes;
        }
    }
}