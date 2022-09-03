//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a reification of the counterpoint to a nullary thing
    /// </summary>
    /// <typeparam name="F">The thing which cannot be empty</typeparam>
    [Free]
    public interface INonEmpty<F> : INullity
        where F : INonEmpty<F>, new()
    {
        bool INullity.IsEmpty
            => false;
    }

    /// <summary>
    /// Characterizes a T-parametric nonempty thing that provides evidence of non-absence
    /// </summary>
    /// <typeparam name="F">The thing which cannot be empty</typeparam>
    [Free]
    public interface INonEmpty<F,T> : INonEmpty<F>
        where F : INonEmpty<F,T>, new()
    {
        /// <summary>
        /// Proof
        /// </summary>
        T Individual {get;}
    }
}