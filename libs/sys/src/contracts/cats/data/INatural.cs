//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a reification structure over natural types S where
    /// s:S => s ∈ {1, … n} where n is some natural number subject to the
    /// bounds implied by the underlying data structure
    /// </summary>
    /// <typeparam name="S">The type of the realizing structure</typeparam>
    public interface INatural<S> : IIntegral<S>, INonNegative<S>
        where S : INatural<S>, new()
    {

    }
}