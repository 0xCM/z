//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public ref struct BinaryBitLogixCheck
    {
        ReadOnlySpan<bit> A;

        ReadOnlySpan<bit> B;

        uint Count;

        BinaryBitLogicKind Kind;

        Func<bit,bit,bit> Rule;

        SeqEval<bit> Result;

        BitLogix Service;

        readonly IWfRuntime Wf;

        [MethodImpl(Inline), Op]
        internal BinaryBitLogixCheck(IWfRuntime wf)
            : this()
        {
            Wf = wf;
        }

        [Op]
        public static BinaryBitLogixCheck create(IWfRuntime wf, BinaryBitLogicKind kind, Func<bit,bit,bit> rule, uint count, ISource source)
        {
            var dst = new BinaryBitLogixCheck(wf);
            dst.Kind = kind;
            dst.Rule = rule;
            dst.Count = count;
            dst.A = source.BitStream().Take(dst.Count).Array();
            dst.B = source.BitStream().Take(dst.Count).Array();
            dst.Result = EvalSeq.alloc<bit>(dst.Count,true);
            dst.Service = BitLogix.Service;
            return dst;
        }

        [Op]
        public SeqEval<bit> Run()
        {
            var dst = Result;
            var target = dst.Edit;
            ref var result = ref dst.Result;
            for(var i=0u; i<Count; i++)
            {
                ref readonly var a = ref skip(A,i);
                ref readonly var b = ref skip(B,i);
                var expect = Rule(a,b);
                var actual = Service.Evaluate(Kind, a, b);
                ref var judgement = ref seek(target, i);
                judgement = new BinaryEval<bit>(a,b, expect == actual);
                result &= judgement.Result;
            }
            return Result;
        }
    }
}