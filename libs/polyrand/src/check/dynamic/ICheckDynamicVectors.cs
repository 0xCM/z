//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using static Root;
    using static BufferSeqId;
    using static CellDelegates;

    public interface ICheckDynamicVectors : ICheckAction, ITestDynamic, IBufferedChecker
    {
        TestCaseRecord Match<T>(BinaryOp<Vector128<T>> f, ApiCodeBlock bits)
            where T : unmanaged
        {
            var g = Dynamic.EmitFixedBinary(this[Main], w128, bits);
            return Match<T>(f, g, bits.OpUri.OpId);
        }

        TestCaseRecord Match<T>(BinaryOp<Vector256<T>> f, ApiCodeBlock bits)
            where T : unmanaged
        {
            var g = Dynamic.EmitFixedBinary(this[Main], w256, bits);
            return Match<T>(f, g, bits.OpUri.OpId);
        }

        /// <summary>
        /// Verifies that two 128-bit vectorized binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator, considered as a basline</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator, considered as the operation under test</param>
        /// <param name="gId">The identity of the second operator</param>
        TestCaseRecord Match<T>(BinaryOp<Vector128<T>> f, BinaryOp128 g, OpIdentity name)
            where T : unmanaged
        {
            void check()
            {
                var w = w128;
                var t = default(T);
                for(var i=0; i<RepCount; i++)
                {
                    var x = Random.CpuVector(w,t);
                    var y = Random.CpuVector(w,t);
                    gcpu.veq(f(x,y), g.Apply(x,y));
                }
            }

            return TestAction(check, name);
        }

        TestCaseRecord Match<T>(BinaryOp<Vector256<T>> f, BinaryOp256 g, OpIdentity name)
            where T : unmanaged
        {
            void check()
            {
                var w = w256;
                var t = default(T);
                for(var i=0; i<RepCount; i++)
                {
                    var x = Random.CpuVector(w,t);
                    var y = Random.CpuVector(w,t);
                    eq(f(x,y), g.Apply(x,y));
                }
            }

            return TestAction(check, name);
        }

        TestCaseRecord Match<T>(BinaryOp<Vector128<T>> f, OpIdentity fId, BinaryOp128 g, OpIdentity gId)
            where T : unmanaged
        {
            var w = w128;
            var t = default(T);

            void check()
            {
                for(var i=0; i<RepCount; i++)
                {
                    var x = Random.CpuVector(w,t);
                    var y = Random.CpuVector(w,t);
                    eq(f(x,y), g.Apply(x,y));
                }
            }

            return TestAction(check, match(fId, gId));
        }

        TestCaseRecord Match<T>(BinaryOp<Vector256<T>> f, OpIdentity fId, BinaryOp256 g, OpIdentity gId)
            where T : unmanaged
        {
            var w = w256;
            var t = default(T);

            void check()
            {

                for(var i=0; i<RepCount; i++)
                {
                    var x = Random.CpuVector(w,t);
                    var y = Random.CpuVector(w,t);
                    eq(f(x,y), g.Apply(x,y));
                }
            }

            return TestAction(check, match(fId, gId));
        }
    }
}