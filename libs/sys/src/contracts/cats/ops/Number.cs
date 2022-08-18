//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Defines the minimal aspects for a value to be considered a "real number"
        /// The dual contract, that subsumes every possible aspect of number, is
        /// defined via the Real trait. Note that every Number can be parameterized
        /// by any underlying primitive numeric type
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface INumber<T> :
                ISubtractive<T>,
                IAbsolutive<T>,
                IAdditiveGroup<T>,
                IMultiplicativeSemigroup<T>,
                ISemiring<T>,
                IDivisive<T>,
                IPoweredOps<T,int>
            where T : unmanaged

        {

        }
    }
}