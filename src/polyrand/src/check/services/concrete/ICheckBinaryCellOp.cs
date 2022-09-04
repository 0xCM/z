//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CellDelegates;

    using Test = TestFixedBinaryOp;

    public interface ICheckBinaryCellOp : ICheckAction, ITestRandom
    {
        /// <summary>
        /// Verifies that two 8-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        TestCaseRecord Match(BinaryOp8 f, _OpIdentity fId, BinaryOp8 g, _OpIdentity gId)
            => Test.Check(Random).Match(f, fId, g, gId);

        /// <summary>
        /// Verifies that two 16-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        TestCaseRecord Match(BinaryOp16 f, _OpIdentity fId, BinaryOp16 g, _OpIdentity gId)
            => Test.Check(Random).Match(f, fId, g, gId);

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        TestCaseRecord Match(BinaryOp32 f, _OpIdentity fId, BinaryOp32 g, _OpIdentity gId)
            => Test.Check(Random).Match(f, fId, g, gId);

        /// <summary>
        /// Verifies that two 64-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        TestCaseRecord Match(BinaryOp64 f, _OpIdentity fId, BinaryOp64 g, _OpIdentity gId)
            => Test.Check(Random).Match(f, fId, g, gId);

        /// <summary>
        /// Verifies that two 128-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        TestCaseRecord Match(BinaryOp128 f, _OpIdentity fId, BinaryOp128 g, _OpIdentity gId)
            => Test.Check(Random).Match(f, fId, g, gId);

        /// <summary>
        /// Verifies that two 128-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        TestCaseRecord Match(BinaryOp256 f, _OpIdentity fId, BinaryOp256 g, _OpIdentity gId)
            => Test.Check(Random).Match(f, fId, g, gId);
    }
}