//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a numeric structure
    /// </summary>
    /// <typeparam name="S">The structure type</typeparam>
    /// <typeparam name="T">The underlying operand type</typeparam>
    public interface IRational<S> :
            ISubtractive<S>,
            IAbsolitive<S>,
            IAdditiveGroup<S>,
            IMultiplicativeSemigroup<S>,
            ISemiring<S>,
            IDivisive<S>,
            INaturallyPowered<S>
        where S : IRational<S>, new()
    {

    }
}