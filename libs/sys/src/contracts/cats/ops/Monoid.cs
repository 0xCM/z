//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes multiplicative monoidal operations
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IMultiplicativeMonoid<T> : IMultiplicativeSemigroup<T>, IUnital<T>
        {

        }

        /// <summary>
        /// Characterizes additive monoidal operations
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IAdditiveMonoid<T> : IAdditiveSemigroup<T>, INullaryOps<T>
        {

        }
    }

}