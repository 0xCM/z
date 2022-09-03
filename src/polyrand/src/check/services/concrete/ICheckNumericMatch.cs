//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckNumericMatch : ICheckAction, ICheckNumeric, ITestRandom
    {
        /// <summary>
        /// Evaluates a pair of unary operators and asserts their equality over a random sequence
        /// </summary>
        /// <param name="label">The case label</param>
        /// <param name="f">The first operator, often interpreted as the reference implementation</param>
        /// <param name="g">The second operator, often interpreted as the operator under test</param>
        /// <typeparam name="T">The operator domain type</typeparam>
        TestCaseRecord MatchNumeric<T>(string label, UnaryOp<T> f, UnaryOp<T> g)
            where T :unmanaged
        {
            void check()
            {
                for(var i=0; i<RepCount; i++)
                {
                    var x = Random.Next<T>();
                    NumEq(f(x),g(x));
                }
            }

            return TestAction<T>(check, label);
        }

        /// <summary>
        /// Evaluates a pair of binary operators and asserts their equality over a random sequence
        /// </summary>
        /// <param name="label">The case label</param>
        /// <param name="f">The first operator, often interpreted as the reference implementation</param>
        /// <param name="g">The second operator, often interpreted as the operator under test</param>
        /// <typeparam name="T">The operator domain type</typeparam>
        TestCaseRecord MatchNumeric<T>(string label, BinaryOp<T> f, BinaryOp<T> g)
            where T :unmanaged
        {
            void check()
            {
                for(var i=0; i<RepCount; i++)
                {
                    var x = Random.Next<T>();
                    var y = Random.Next<T>();
                    NumEq(f(x,y),g(x,y));
                }
            }

            return TestAction<T>(check, label);
        }
    }
}