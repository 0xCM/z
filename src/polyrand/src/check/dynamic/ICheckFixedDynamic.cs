//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BufferSeqId;
    using static core;

    public interface ICheckFixedDynamic : ITestRandom, ICheckNull, ICheckDynamic, IBufferedChecker
    {
        Index<UnaryPairEval<UnaryOperatorClass,F,bit>> EvalEquality<F>(UnaryOperatorClass k, ApiCodeBlock a, ApiCodeBlock b)
            where F : unmanaged, IDataCell
        {
            var count = RepCount;
            var points = Random.Cells<F>((uint)count).View;
            var f = Dynamic.EmitFixedUnary<F>(Tokens[Left], a);
            var g = Dynamic.EmitFixedUnary<F>(Tokens[Right], b);
            var checker = CheckEqual.Checker;
            var buffer = alloc<UnaryPairEval<UnaryOperatorClass,F,bit>>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(points,i);
                var y = f(x);
                var r1 = EvalResults.unary(k, x, y);

                var z = g(x);
                var r2 = EvalResults.unary(k, x, z);

                bit eq = object.Equals(y,z);
                seek(dst,i) = EvalResults.pair(r1,r2,eq);
            }
            return buffer;
        }
    }
}